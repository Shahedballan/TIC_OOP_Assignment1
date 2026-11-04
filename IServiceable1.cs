namespace ApplianceRepairCenter
{
    public interface IRepairable
    {
        double CalculateRebairCost();
        string GetApplianceDetails();
    }
}