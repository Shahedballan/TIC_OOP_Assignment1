using System;
namespace ApplianceRepairCenter
{
 public class WashingMachine1:HomeDevice
 
 {
     public int DrumCapacityKg
     {
        get;
        set;
     }
     public WashingMachine1(string serialNumber,string make,double standardPrice,string status, int drumCapacity,bool hasDryer)

     
     : base(serialNumber,make,standardPrice,status)
     {
        DrumCapacityKg = drumCapacity;
        hasDryer = hasDryer;
     }
     public override double
     ComputePrice()
     {
        double baseprice =  StandardPrice + (DrumCapacityKg*20);
        if(hasDryer)
        {
            basePrice+=1500.0;
        }
        return basePrice;
     }
     public override string PrintInfo()
     {
        string dryerStatus = HasDryer?"Yes" : "No";
        return base.PrintInfo() + 
        $"Drum Capacity:{DrumCapacityKg}Kg,-" +
        $"Dryer:{dryerStatus},-" + 
        $"Total Price:{ComputePrice()} ل.س";
     }
 }
 
}
