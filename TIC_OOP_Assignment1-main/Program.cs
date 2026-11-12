using System;
using System.Text;

namespace ApplianceRepairCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            DeviceManager manager = new DeviceManager();

            Console.WriteLine("= 1) إضافة الأجهزة =");

            HomeDevice fridge = new Refrigerator("R-001", "Samsung", 5000, "قيد الصيانة", 400, true);
            HomeDevice washer = new WashingMachine("W-001", "LG", 3000, "قيد الصيانة", 8, true);
            HomeDevice airCon = new AirConditioner("A-001", "Gree", 4000, "Repaired", 1.5, false);

            manager.AddDevice(fridge);
            manager.AddDevice(washer);
            manager.AddDevice(airCon);

            Console.WriteLine("\n= 2) اختبار التحقق من الرقم التسلسلي =");
            try
            {
                HomeDevice invalid = new Refrigerator("123", "Test", 1000, "قيد الصيانة", 200, false);
                manager.AddDevice(invalid);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"خطأ متوقع: {ex.Message}");
            }

            try
            {
                HomeDevice badPrice = new WashingMachine("W-002", "Bosch", -50, "قيد الصيانة", 7, false);
                manager.AddDevice(badPrice);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"خطأ متوقع: {ex.Message}");
            }

            Console.WriteLine("\n= 3) قائمة الأجهزة قبل التحديث =");
            manager.DisplaySortedDevices();

            Console.WriteLine("\n=== 4) تحديث حالة الأجهزة ===");
            manager.UpdateDeviceStatus("R-001", "Repaired");
            manager.UpdateDeviceStatus("W-001", "قيد الصيانة");
            manager.UpdateDeviceStatus("X-999", "Repaired");

            Console.WriteLine("\n= 5) البحث بالرقم التسلسلي =");
            HomeDevice found = manager.SearchBySerial("w-001");
            if (found != null)
            {
                Console.WriteLine(found.PrintInfo());
            }
            else
            {
                Console.WriteLine("الجهاز غير موجود.");
            }

            Console.WriteLine("\n= 6) قائمة الأجهزة بعد التحديث =");
            manager.DisplaySortedDevices();

            Console.WriteLine("\n= 7) ملخص الأجهزة =");
            Console.WriteLine($"الإجمالي: {HomeDevice.TotalDevice}");
            Console.WriteLine($"تم إصلاحها: {HomeDevice.RepairedCount}");
            Console.WriteLine($"قيد الصيانة: {HomeDevice.UnderMaintenanceCount}");

            Console.WriteLine("\nاضغط أي زر للخروج");
            Console.ReadKey();
        }
    }
}