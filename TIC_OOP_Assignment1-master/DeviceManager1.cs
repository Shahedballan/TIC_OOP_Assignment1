using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplianceRepairCenter
{
    public class DeviceManager
    {
        // ŞÇÆãÉ áÊÎÒíä ÌãíÚ ÇáÃÌåÒÉ ÈÛÖ ÇáäÙÑ Úä ÃäæÇÚåÇ ÊØÈíŞ ãÈÏÃ ÊÚÏÏ ÇáÃÔßÇáPolymorphism 
        private List<HomeDevice> devices = new List<HomeDevice>();

        // 1. ÅÖÇİÉ ÌåÇÒ ÌÏíÏ Åáì ÇáäÙÇã
        public void AddDevice(HomeDevice device)
        {
            if (device != null)
            {
                devices.Add(device);
                Console.WriteLine($"Added device with Serial Number: {device.SerialNumber} successfully.");
            }
        }

        // 2. ÇáÈÍË Úä ÌåÇÒ ÈäÇÁğ Úáì ÇáÑŞã ÇáÊÓáÓáí (Serial Number)
        public HomeDevice SearchBySerial(string serialNumber)
        {
            // ÇÓÊÎÏÇã LINQ ááÈÍË ÇáÓÑíÚ æÇáÏŞíŞ
            return devices.FirstOrDefault(d => d.SerialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
        }

        // 3. ÊÍÏíË ÍÇáÉ ÇáÕíÇäÉ ááÌåÇÒ ãÚ ÊØÈíŞ ÇáãäØŞ ÇáãØáæÈ ááÊÑÊíÈ
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

        // 4. ÚÑÖ ÇáÃÌåÒÉ ãÑÊÈÉ ÍÓÈ ÇáÔÑØ :
        // - ÇáÃÌåÒÉ ÇáÊí ÍÇáÊåÇ "ŞíÏ ÇáÕíÇäÉ" ÊÙåÑ ÃæáÇğ¡ ãÑÊÈÉ ÊÕÇÚÏíÇğ ÍÓÈ ÊÇÑíÎ ÇáÏÎæá ÇáÃŞÏã
        // - ÇáÃÌåÒÉ ÇáÊí Êã ÅÕáÇÍåÇ  ÊäÊŞá ÊáŞÇÆíÇğ áÊÙåÑ İí äåÇíÉ ÇáŞÇÆãÉ
        public void DisplaySortedDevices()
        {
            var sortedDevices = devices
                .OrderBy(d => d.Status.Contains("Êã ÇáÅÕáÇÍ") || d.Status.Equals("Repaired", StringComparison.OrdinalIgnoreCase)) // íÖÚ "Êã ÇáÅÕáÇÍ" İí ÇáäåÇíÉ (False Ëã True)
                .ThenBy(d => d.EntryDate) // ÊÑÊíÈ ÊÕÇÚÏí ÍÓÈ ÊÇÑíÎ ÇáÏÎæá ÇáÃŞÏã ááÃÌåÒÉ ÇáÊí ŞíÏ ÇáÕíÇäÉ
                .ToList();

            Console.WriteLine("\n--- Appliance Repair Center: Sorted Device List ---");
            foreach (var device in sortedDevices)
            {
                // ÇÓÊÏÚÇÁ ÏÇáÉ PrintInfo ÇáãØæÑÉ İí ßá ÌåÇÒ (Polymorphism)
                Console.WriteLine(device.PrintInfo());
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}