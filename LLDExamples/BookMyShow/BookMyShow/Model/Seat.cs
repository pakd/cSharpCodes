namespace BookMyShow.Model;

public enum SeatType
{
    Normal,
    Premium
}

public abstract class Seat
{
    public string SeatId { get; set; }
    public decimal SeatPrice { get; set; }
    public SeatType SeatType { get; set; }
}

public class NormalSeat : Seat
{
    public NormalSeat()
    {
        base.SeatType = SeatType.Normal;
    }
}

public class PremiumSeat : Seat
{
    public PremiumSeat()
    {
        base.SeatType = SeatType.Premium;
    }
}

