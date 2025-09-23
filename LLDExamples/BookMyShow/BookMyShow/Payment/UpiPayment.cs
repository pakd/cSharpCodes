namespace BookMyShow.Payment;

public class UpiPayment : IPaymentStrategy
{
    private readonly string _upiId;

    public UpiPayment(string upiId)
    {
        _upiId = upiId;
    }

    public bool Pay(double amount, string userId)
    {
        Console.WriteLine($"Processing UPI payment of {amount} for User {userId} via {_upiId}");
        // Mock external UPI API call here
        return true; // assume payment success
    }
}