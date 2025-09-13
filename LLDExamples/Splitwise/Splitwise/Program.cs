using Splitwise;

class Program
{
    static void Main()
    {
        var alice = new User(1, "Alice", "alice@test.com");
        var bob = new User(2, "Bob", "bob@test.com");
        var charlie = new User(3, "Charlie", "charlie@test.com");

        var group = new Group("Friends Trip");
        group.AddMember(alice);
        group.AddMember(bob);
        group.AddMember(charlie);

        // Expense 1: Dinner - Alice paid 90, shared equally
        group.AddExpense(new Expense("Dinner", 90,  alice, new List<Split>
        {
            new Split(alice, 90, SplitType.PAID),
            new Split(alice, 30, SplitType.OWED),
            new Split(bob, 30, SplitType.OWED),
            new Split(charlie, 30, SplitType.OWED)
        }));

        // Expense 2: Taxi - Bob paid 60, shared equally
        group.AddExpense(new Expense("Taxi", 60, alice, new List<Split>
        {
            new Split(bob, 60, SplitType.PAID),
            new Split(alice, 20, SplitType.OWED),
            new Split(bob, 20, SplitType.OWED),
            new Split(charlie, 20, SplitType.OWED)
        }));

        // Simplify
        var transactions = group.Simplify();

        Console.WriteLine("Settlement:");
        foreach (var t in transactions)
        {
            Console.WriteLine($"From : {t.From.Name}, To: {t.To.Name}, Amount: {t.Amount}");
        }
    }
}