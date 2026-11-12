using System;
using System.Text.RegularExpressions;

namespace ApplianceRepairCenter
{
    
    public static class DeviceValidator
    {
        //   (R-001 الرقم التسلسلي: 1-3 أحرف كبيرة + شرطة + 3-6 أرقام (مثل )
        public static bool IsValidSerialNumber(string serial)
        {
            return !string.IsNullOrWhiteSpace(serial) &&
                   Regex.IsMatch(serial, @"^[A-Z]{1,3}-\d{3,6}$");
        }

        public static bool IsValidDate(DateTime date)
        {
            return date != default(DateTime) && date <= DateTime.Now;
        }

      
        public static bool IsRepairedStatus(string status)
        {
            return status == "Repaired" || status == "تم الإصلاح";
        }
    }
}