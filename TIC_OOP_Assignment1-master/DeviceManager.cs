using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplianceRepairCenter
{
    public class DeviceManager
    {
       
        private List<HomeDevice> devices = new List<HomeDevice>();

        
        public void AddDevice(HomeDevice device)
        {
            if (device != null && DeviceValidator.IsValidDate(device.EntryDate)
            {
                devices.Add(device);
                device.StatusChanged += OnStatusChanged;
                Console.WriteLine($"Added device with Serial Number: {device.SerialNumber} successfully.");
            }
        }

        

        
        public HomeDevice SearchBySerial(string serialNumber)
        {
           
            return devices.FirstOrDefault(d => d.SerialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateDeviceStatus(string serialNumber, string newStatus)
        {
            HomeDevice device = SearchBySerial(serialNumber);
            if (device != null)
            {
                device.Status = newStatus;
                Console.WriteLine($"Device {serialNumber} status updated to: {newStatus}");
            }
            else
            {
                Console.WriteLine("Device not found.");
            }
        }

        public void DisplaySortedDevices()
        {
            //الاجهزة قيد الاصلاح اولا ثم التي تم تصليحها،وبحسب تاريخ ادخال الجهاز
            var sortedDevices = devices
                .OrderBy(d => d.Status.Contains("تم الاصلاح") || d.Status.Equals("Repaired", StringComparison.OrdinalIgnoreCase)) 
                .ThenBy(d => d.EntryDate) 
                .ToList();

            Console.WriteLine("\n--- Appliance Repair Center: Sorted Device List ---");
            foreach (var device in sortedDevices)
            {
                
                Console.WriteLine(device.PrintInfo());
                Console.WriteLine(new string('-', 40));
            }
        }


        public void displaysummary()
        {
            Console.WriteLine($"total:{HomeDevice.TotalDevices}|"+
                $"Under maintance:{HomeDevice.UnderMaintenanceCount}|" +
                $"+$\"repaired:{HomeDevice.RipairedCount}")
        }






                 //الحدث:إشعار عند اكتمال الاصلاح
        private void OnStatusChanged(homedevice device, string oldStatus, string newStatus)
        {
            Console.WriteLine($"[إشعار]الجهاز {device.serialnumber} تغيرت حالته من" + 
                $"{oldstatus}الى {newstatus}جهازك جاهز للتسليم");

        }





    }
}