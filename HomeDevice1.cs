using System;
namespace ApplianceRepairCenter
{
    public abstract class HomeDevice : IServiceable
    {
        private readonly string _serialNumber;
        private string _make;
        private double _standardPrice;
        private string _status;

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
            }      throw new ArgumentException("price cannot be negative.");
                  
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }


        protected HomeDevice(string serialNumber, string make, double standardPrice, string status)
        {
            _serialNumber = serialNumber;
            _make = make;
            StandardPrice = standardPrice;
            _status = status;
        }

        public abstract double ComputePrice();

        public virtual string PrintInfo()
        {
            return
            $"Serial Namber: {_serialNumber}  - " +
            $"Make: {_make} - " +
            $"Standar Price: {_standardPrice} ل.س - " +
             $"Status: {_status}";
        }

    }

}