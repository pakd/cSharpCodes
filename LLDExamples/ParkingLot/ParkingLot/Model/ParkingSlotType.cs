namespace ParkingLot
{
    using System;
    
    public enum ParkingSlotType
    {
        TwoWheeler,
        Compact,
        Medium,
        Large
    }

    public static class ParkingSlotPricing
    {
        public static double GetPriceForParking(this ParkingSlotType type, long duration)
        {
            return type switch
            {
                ParkingSlotType.TwoWheeler => duration * 0.05,
                ParkingSlotType.Compact => duration * 0.075,
                ParkingSlotType.Medium => duration * 0.09,
                ParkingSlotType.Large => duration * 0.10,
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Unsupported ParkingSlotType: {type}")
            };
        }
    }
}