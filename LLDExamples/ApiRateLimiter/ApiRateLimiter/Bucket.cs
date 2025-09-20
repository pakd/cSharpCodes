namespace ApiRateLimiter;

public class Bucket
{
    public double RemainingTokens;
    public DateTime LastRefill;
    public readonly object Lock = new object();

    public Bucket(double tokens, DateTime lastRefill)
    {
        this.RemainingTokens = tokens;
        this.LastRefill = lastRefill;
    }
}