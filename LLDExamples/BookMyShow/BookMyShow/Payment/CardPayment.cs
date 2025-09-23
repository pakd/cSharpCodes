namespace BookMyShow.Payment;

public class CardPayment : IPaymentStrategy
{
    private readonly string _cardNumber;

    public CardPayment(string cardNumber)
    {
        _cardNumber = cardNumber;
    }

    public bool Pay(double amount, string userId)
    {
        Console.WriteLine($"Processing Card payment of {amount} for User {userId} via card {_cardNumber}");
        // Mock external Card API call here
        return true; // assume payment success
    }
}