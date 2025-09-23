namespace BookMyShow.Payment;

public interface IPaymentStrategy
{
    bool Pay(double amount, string userId);
}