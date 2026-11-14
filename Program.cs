using System;
using System.Text;

namespace ApplianceRepairCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            DeviceManager manager = new DeviceManager();

            Console.WriteLine(" 1) ADD DEVICE ");

            HomeDevice fridge = new Refrigerator("R-001", "Samsung", 5000, "under maintance", 400, true);
            HomeDevice washer = new WashingMachine("W-001", "LG", 3000, "under maintance", 8, true);
            HomeDevice airCon = new AirConditioner("A-001", "Samsung", 4000, "Repaired", 1.5, false);

            manager.AddDevice(fridge);
            manager.AddDevice(washer);
            manager.AddDevice(airCon);

            Console.WriteLine("\n 2) Serial Number Verification Test ");
            try
            {
                HomeDevice invalid = new Refrigerator("123", "Test", 1000, "under maintance", 200, false);
                manager.AddDevice(invalid);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Expected error: {ex.Message}");
            }

            try
            {
                HomeDevice badPrice = new WashingMachine("W-002", "Bosch", -50, "under maintance", 7, false);
                manager.AddDevice(badPrice);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Expected error: {ex.Message}");
            }

            Console.WriteLine("\n 3) List of devices before the update ");
            manager.DisplaySortedDevices();

            Console.WriteLine("\n 4) Device status update ");
            manager.UpdateDeviceStatus("R-001", "Repaired");
            manager.UpdateDeviceStatus("W-001", "under maintance");
            manager.UpdateDeviceStatus("X-999", "Repaired");

            Console.WriteLine("\n 5) Search by serial number ");
            HomeDevice found = manager.SearchBySerial("w-001");
            if (found != null)
            {
                Console.WriteLine(found.PrintInfo());
            }
            else
            {
                Console.WriteLine("The device does not exist");
            }

            Console.WriteLine("\n 6) List of devices after the update ");
            manager.DisplaySortedDevices();

            Console.WriteLine("\n 7) Device Summary ");
            Console.WriteLine($"Total Device: {HomeDevice.TotalDevice}");
            Console.WriteLine($"Repaired: {HomeDevice.RepairedCount}");
            Console.WriteLine($"under maintance": {HomeDevice.UnderMaintenanceCount}");

            Console.WriteLine("\n Press any button to exit");
            Console.ReadKey();
        }
    }
}