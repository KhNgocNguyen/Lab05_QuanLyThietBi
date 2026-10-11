/****************/  
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/****************/ 
using System;
public abstract class Device
{
    public string DeviceId {get; init;}
    public string DeviceName {get; set;}
    private int _yearOfUse;
    public int YearOfUse
    {
        get => _yearOfUse;
        set
        {
            if (value>DateTime.Now.Year)
            throw new ArgumentException("Năm sử dụng không được lớn hơn năm hiện tại.");
            _yearOfUse = value;
        }
    }private decimal _purchasePrice;
    public decimal PurchasePrice
    {
        get => _purchasePrice;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Giá mua phải lớn hơn bằng 0.");
            _purchasePrice=value;
        }
    }
    public DeviceStatus Status { get; set;}
    protected Device(string deviceId, string deviceName, int yearOfUse, decimal _purchasePrice, DeviceStatus status)
    {
        if (string.IsNullOrWhiteSpace(deviceId))
            throw new ArgumentException("Mã thiết bị không được rỗng.");
        DeviceId = deviceId;
        DeviceName = deviceName;
        YearOfUse = yearOfUse;
        PurchasePrice=_purchasePrice;
        Status = status;
    }
    public int GetYearInUse()
    {
        return DateTime.Now.Year - YearOfUse;
    }
    public abstract decimal CalculateAnnualMaintenanceCost();
    public override string ToString()
    {
        return $"[{DeviceId}] {DeviceName} - Tình trạng: {Status}";
    }
}