using System;
namespace TIC_OOP_Assignment1
{
 public class Refrigerator1:
 HomeDevice1,IServiceable1
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
     public Refrigerator1(string serialNumber,string make,double standardPrice,double capacity,bool hasSmartScreen)
     : base(serialNumber,make,standardPrice)
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
     public double CalculateRebairCost()
     {
        return 200.0 + (ComputePrice()*0.20);
     }
     public string GetApplianceDetails()
     {
        string screenStatus = HasSmartScreen?"Yes" : "No";
        return $"Refrigerator - Make :{Make}, Capacity :{CapacityLiters}L,Smart Screen: {screenStatus}, Total Price:{ComputePrice()} S.P";
     }
 }
 
}
