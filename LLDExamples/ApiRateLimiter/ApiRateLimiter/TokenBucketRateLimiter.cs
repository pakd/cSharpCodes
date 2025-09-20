using System.Collections.Concurrent;

namespace ApiRateLimiter;

public class TokenBucketRateLimiter
{
    private readonly int _capacity; // x max tokens
    private readonly TimeSpan _period; // y seconds
    private readonly double _refillRatePerSecond; // tokens per second
    private readonly ConcurrentDictionary<string, Bucket> _customers = new();


    public TokenBucketRateLimiter(int capacity, TimeSpan period)
    {
        this._capacity = capacity;
        this._period = period;
        _refillRatePerSecond = capacity / period.TotalSeconds;
    }

    public RateLimitingResult CheckRequest(string customerId)
    {
        var now = DateTime.UtcNow;
        
        var bucket = this._customers.GetOrAdd(customerId, new Bucket(_capacity, now));

        lock (bucket.Lock)
        {
            var timeElapsed = (now - bucket.LastRefill).TotalSeconds;

            if (timeElapsed > 0)
            {
                var refillAmount = timeElapsed * this._refillRatePerSecond;
                var tokenToBeAdded = Math.Min(_capacity, bucket.RemainingTokens + refillAmount);
                bucket.RemainingTokens = tokenToBeAdded;
                bucket.LastRefill = now;
            }

            if (bucket.RemainingTokens >= 1)
            {
                bucket.RemainingTokens -= 1;
                return new RateLimitingResult(true, _capacity, (int)Math.Floor(bucket.RemainingTokens));
            }
            else
            {
                return new RateLimitingResult(false, _capacity, 0);
            }
        }
    }
    
}