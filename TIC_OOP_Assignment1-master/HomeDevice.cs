using System;
namespace ApplianceRepairCenter
{
    public abstract class HomeDevice : IServiceable
    {
        private readonly string _serialNumber;
        private string _make;
        private double _standardPrice;
        private string _status;
        private readonly DateTime _entryDate = DateTime.Now;

        private static int _totalCount;
        private static int _repairedCount;

        public event DeviceStatusChange StatusChanged; //   حدث عند تغيير حالة الجهاز الى تم الاصلاح

        public static int TotalDevice => _totalCount;
        public static int RepairedCount => _repairedCount;
        public static int UnderMaintenanceCount => _totalCount - _repairedCount;



        public string SerialNumber
        {
            get { return _serialNumber; }
        }

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }

        public double StandardPrice
        {
            get { return _standardPrice; }
            set
            {
                if (value >= 0)
                    _standardPrice = value;
                else
                    throw new ArgumentException("price cannot be negative.");
            }

        }
        public DateTime EntryDate
        {

            get { return _entryDate; }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                bool wasRepaired = DeviceValidator.IsRepairedStatus(_status);
                bool nowRepaired = DeviceValidator.IsRepairedStatus(value);
                string oldStatus = _status;
                _status = value;

                if (!wasRepaired && nowRepaired) _repairedCount++;
                else if (wasRepaired && !nowRepaired) _repairedCount--;

                // إطلاق الحدث عند الانتقال إلى "تم الإصلاح" فقط
                if (!wasRepaired && nowRepaired)
                    OnStatusChanged(oldStatus, value);

            }
        }


        protected HomeDevice(string serialNumber, string make, double standardPrice, string status)
        {
            if (!DeviceValidator.IsValidSerialNumber(serialNumber))
                throw new ArgumentException("Invalid serial number format (e.g. R-001).");

            _serialNumber = serialNumber;
            _make = make;
            StandardPrice = standardPrice;   // يمر عبر التحقق من السعر
            _status = status;                // مباشرة حتى لا يُطلق الحدث

            _totalCount++;
            if (DeviceValidator.IsRepairedStatus(status))
                _repairedCount++;
        }

        public abstract double ComputePrice();

        public virtual string PrintInfo()
        {
            return
            $"Serial Number: {_serialNumber}, " +
            $"Make: {_make} ," +
            $"Standar Price: {_standardPrice}ل.س, " +
            $"Status: {_status},";
        }

        protected virtual void OnStatusChanged(string oldStatus, string newStatus)
        {
            StatusChanged?.Invoke(this, oldStatus, newStatus);

        }

    }

}
