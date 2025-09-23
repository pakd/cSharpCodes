using BookMyShow.Model;

namespace BookMyShow.Payment;

public class PaymentFactory
{
    public static IPaymentStrategy GetPaymentStrategy(PaymentType type, string paymentDetail)
    {
        return type switch
        {
            PaymentType.UPI => new UpiPayment(paymentDetail),       // paymentDetail = UPI ID
            PaymentType.Card => new CardPayment(paymentDetail),     // paymentDetail = Card Number
            _ => throw new ArgumentException("Invalid payment type")
        };
    }
}