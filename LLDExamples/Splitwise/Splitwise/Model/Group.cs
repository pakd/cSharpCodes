namespace Splitwise;

public class Group
{
    public string Name { get; set; }
    public List<User> Members { get; set; }
    public List<Expense> Expenses { get; set; }

    public Group(string name)
    {
        this.Name = name;
        this.Members = new List<User>();
        this.Expenses = new List<Expense>();
    }

    public void AddMember(User user)
    {
        this.Members.Add(user);
    }

    public void AddExpense(Expense expense)
    {
        this.Expenses.Add(expense);
    }

    public List<Transaction> Simplify()
    {
        var balances = new Dictionary<int, decimal>();
        var userIdToUser = new Dictionary<int, User>();

        // Step 1: Compute net balances
        foreach (var expense in this.Expenses)
        {
            foreach (var split in expense.Splits)
            {
                if (!balances.ContainsKey(split.User.Id))
                {
                    balances[split.User.Id] = 0;
                    userIdToUser[split.User.Id] = split.User;
                }

                if (split.SplitType == SplitType.PAID)
                    balances[split.User.Id] += split.Amount;

                if (split.SplitType == SplitType.OWED)
                    balances[split.User.Id] -= split.Amount;
            }
        }

        // Step 2: Build priority queues
        var creditors = new PriorityQueue<int, decimal>(); // max queue
        var debtors = new PriorityQueue<int, decimal>(); // min queue

        foreach (var kvp in balances)
        {
            if (kvp.Value > 0)
                creditors.Enqueue(kvp.Key, -kvp.Value); // max-heap by negating
            else if (kvp.Value < 0)
                debtors.Enqueue(kvp.Key, kvp.Value);    // already negative → min-heap
        }

        // Step 3: Settlement
        var transactions = new List<Transaction>();

        while (creditors.Count > 0 && debtors.Count > 0)
        {
            creditors.TryDequeue(out int creditorId, out decimal credAmount);
            debtors.TryDequeue(out int debtorId, out decimal debtAmount);

            var credit = -credAmount;   // convert back to positive
            var debit = -debtAmount;    // debtAmount is negative, so flip

            var settlement = Math.Min(credit, debit);

            transactions.Add(new Transaction(
                userIdToUser[debtorId], 
                userIdToUser[creditorId], 
                settlement));

            credit -= settlement;
            debit -= settlement;

            if (credit > 0)
                creditors.Enqueue(creditorId, -credit);

            if (debit > 0)
                debtors.Enqueue(debtorId, -debit);
        }

        return transactions;
    }

}