namespace Splitwise;

public class Transaction
{
    public User From { get; set; }
    public User To { get; set; }
    public decimal Amount { get; set; }

    public Transaction(User from, User to, decimal amount)
    {
        this.From = from;
        this.To = to;
        this.Amount = amount;
    }
}