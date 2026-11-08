using System;
namespace ApplianceRepairCenter
{
 public class Refrigerator1: HomeDevice
 
 {
     public double CapacityLiters
     {
        get;
        set;
     }
     public bool HasSmartScreen
     {
        get;
        set;
     }  
     public Refrigerator1(string serialNumber, string make, double standardPrice, string status, double capacity,bool hasSmartScreen)
     : base(serialNumber , make, standardPrice ,status)
     {
        CapacityLiters = capacity;
        HasSmartScreen = hasSmartScreen;
     }
     public override double
     ComputePrice()
     {
        double baseprice =  StandardPrice + (CapacityLiters*15);
        if(HasSmartScreen)
        {
            basePrice+=1000.0;
        }
        return basePrice;
     }
     public override string PrintInfo()
     {
        string screenStatus = HasSmartScreen?"Yes" : "No";
        return base.PrintInfo() + 
        $" Capacity:{CapacityLiters}L," +
        $"Smart Screen: {screenStatus}," +
         $"Total Price:{ComputePrice()} ل.س";
     }
 }

}
