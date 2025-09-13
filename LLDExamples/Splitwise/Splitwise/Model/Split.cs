namespace Splitwise;


public enum SplitType
{
    PAID,
    OWED
}
public class Split
{
    public User User { get; set; }
    public decimal Amount { get; set; }
    public SplitType SplitType { get; set; }

    public Split(User user, decimal amount, SplitType splitType)
    {
        this.User = user;
        this.Amount = amount;
        this.SplitType = splitType;
    }
}