namespace Splitwise;

public class Expense
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public User AddedBy { get; set; }
    public DateTime Date { get; set; }
    public List<Split> Splits { get; set; }

    public Expense(string description, decimal amount, User addedBy, List<Split> splits)
    {
        this.Description = description;
        this.Amount = amount;
        this.AddedBy = addedBy;
        this.Splits = splits;
    }
}