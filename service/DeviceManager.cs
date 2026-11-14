using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplianceRepairCenter
{
    public class DeviceManager
    {
        private List<HomeDevice> _devices = new List<HomeDevice>();

        public void AddDevice(HomeDevice device)
        {
            if (device != null && DeviceValidator.IsValidDate(device.EntryDate))
            {
                _devices.Add(device);
                device.StatusChanged += OnStatusChanged;
                Console.WriteLine($"Added device with Serial Number: {device.SerialNumber} successfully.");
            }
        }

        public HomeDevice SearchBySerial(string serialNumber)
        {
            return _devices.FirstOrDefault(d =>
                d.SerialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
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

        //الاجهزة قيد الاصلاح اولا ثم التي تم تصليحها،وبحسب تاريخ ادخال الجهاز
        public void DisplaySortedDevices()
        {
            var sortedDevices = _devices
                .OrderBy(d => DeviceValidator.IsRepairedStatus(d.Status))
                .ThenBy(d => d.EntryDate)
                .ToList();

            Console.WriteLine("\n--- Appliance Repair Center: Sorted Device List ---");
            foreach (HomeDevice device in sortedDevices)
            {
                Console.WriteLine(device.PrintInfo());
                Console.WriteLine(new string('-', 40));
            }
        }

        // معالج الحدث:إشعار عند اكتمال الاصلاح
        private void OnStatusChanged(HomeDevice device, string oldStatus, string newStatus)
        {
            Console.WriteLine($"[notfy]  device {device.SerialNumber} status changed from " +   $"{oldStatus} to {newStatus}، your device is ready");
        }
    }
}