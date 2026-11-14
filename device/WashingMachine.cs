using System;
namespace ApplianceRepairCenter
{
    public class WashingMachine : HomeDevice
    {
        public int DrumCapacityKg 
        { get; set; }

        public bool HasDryer 
        { get; set; }

        public WashingMachine(string serialNumber, string make, double standardPrice,
                              string status, int drumCapacity, bool hasDryer)
            : base(serialNumber, make, standardPrice, status)
        {
            DrumCapacityKg = drumCapacity;
            HasDryer = hasDryer;
        }

        public override double ComputePrice()
        {
            double basePrice = StandardPrice + (DrumCapacityKg * 20);
            if (HasDryer)
                basePrice += 1500.0;
            return basePrice;
        }

        public override string PrintInfo()
        {
            string dryerStatus = HasDryer ? "Yes" : "No";
            return base.PrintInfo() +
                   $" Drum Capacity: {DrumCapacityKg}Kg, " +
                   $"Dryer: {dryerStatus}, " +
                   $"Total Price: {ComputePrice()} S.P";
        }
    }
}