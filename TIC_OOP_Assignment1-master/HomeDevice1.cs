using System;
namespace ApplianceRepairCenter
{
    public abstract class HomeDevice : IServiceable
    {
        private readonly string _serialNumber;
        private string _make;
        private double _standardPrice;
        private string _status;

        private int _totalcount;
        private int _repairedcount;

        public event devicesatuschange statchanged; // حدث عند تغيير حالة الجهاز 

        public static int totaldevice => _totalcount;
        public static int repairedcount => _repairedcount;
        public static int undermaintancecount => _totalcount - _repairedcount;



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
        public DateTime EntryDate { get; } = DateTime.Now;

        public string Status
        {
            get { return _status; }
            set { 
                 bool wasrepaired=DeviceValidator.IsRepairedStatus(_status);
                bool nowrepaired = DeviceValidator.IsRepairedStatus(value);
                string oldstatus=_status
                _status = value;

                if (!wasRepaired && nowRepaired) _repairedCount++;
                else if (wasRepaired && !nowRepaired) _repairedCount--;

                // إطلاق الحدث عند الانتقال إلى "تم الإصلاح" فقط
                if (!wasrepaired && nowrepaired)
                    Onstatchanged(oldstatus, value);

            }
        }
        

        protected HomeDevice(string serialNumber, string make, double standardPrice, string status)
        {
            if (!devicevalidator.IsValidSerialNumber(serialNumber))
                throw new ArgumentException("Invalid serial number format (e.g. R-001).");

            _serialNumber = serialNumber;
            _make = make;
            StandardPrice = standardPrice;   // يمر عبر التحقق من السعر
            _status = status;                // مباشرة حتى لا يُطلق الحدث

            _totalCount++;
            if (devicevalidator.IsRepairedStatus(status))
                _repairedCount++;
        }

        public abstract double ComputePrice();

        public virtual string PrintInfo()
        {
            return
            $"Serial Namber: {_serialNumber} " +
            $"Make: {_make} " +
            $"Standar Price: {_standardPrice} " +
            $"Status: {_status}ل.س";
        }

        protected virtual void Onstatchanged(string oldstat, string newstat)
        {
            statchanged?.Invoke(this, oldstat, newstat);

        }

    }

}
