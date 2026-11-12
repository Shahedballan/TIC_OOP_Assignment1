using System;
namespace ApplianceRepairCenter
{
    public class AirConditioner : HomeDevice
    {
        public double HorsePower { get; set; }
        public bool HasHeating { get; set; }

        public AirConditioner(string serialNumber, string make, double standardPrice,
                              string status, double horsePower, bool hasHeating)
            : base(serialNumber, make, standardPrice, status)
        {
            HorsePower = horsePower;
            HasHeating = hasHeating;
        }

        public override double ComputePrice()
        {
            double basePrice = StandardPrice + (HorsePower * 60.0);
            if (HasHeating)
                basePrice += 2000.0;
            return basePrice;
        }

        public override string PrintInfo()
        {
            string heatingStatus = HasHeating ? "Yes" : "No";
            return base.PrintInfo() +
                   $" Horsepower: {HorsePower}HP, " +
                   $"Heating: {heatingStatus}, " +
                   $"Total Price: {ComputePrice()} ل.س";
        }
    }
}