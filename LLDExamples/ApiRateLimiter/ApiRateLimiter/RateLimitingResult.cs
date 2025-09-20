namespace ApiRateLimiter;

public class RateLimitingResult
{
    public bool Allowed { get;  }
    public int Limit { get;  }
    public int Remaining { get;  }

    public RateLimitingResult(bool Allowed, int Limit, int Remaining)
    {
        this.Allowed = Allowed;
        this.Limit = Limit;
        this.Remaining = Remaining;
    }

    public override string ToString()
    {
        return $"Allowed={Allowed}, X-RateLimit-Limit={Limit}, X-RateLimit-Remaining={Remaining}";
    }
}