namespace ApplianceRepairCenter    //تغير حالة الجهاز
{
    public delegate void DeviceSatusChange( HomeDevice device, string oldStatus, string newStatus);
}

