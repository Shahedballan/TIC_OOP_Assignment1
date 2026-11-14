namespace ApplianceRepairCenter    //تغير حالة الجهاز
{
    public delegate void DeviceStatusChange( HomeDevice device, string oldStatus, string newStatus);
}

