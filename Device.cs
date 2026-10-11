/****************/  
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/****************/ 
using System;
using System.Data;
using System.Net.WebSockets;
public abstract class DeviceStatus
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
    public decimal _purchasePrice
    {
        get => _purchasePrice;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Giá mua phải lớn hơn bằng 0.");
            _purchasePrice=Value;
        }
    }
    public DeviceStatus Status { get; set;}
    protected Device(string deviceId, string devicename, int yearOfUse, decimal _purchasePrice, DeviceStatus status)
    {
        if (string.IsNullOrWhiteSpace(deviceId))
            throw new ArgumantException("Mã thiết bị không được rỗng.");
        DeviceId = deviceId;
        DeviceName = devicename;
        YearOfUse = yearOfUse;
        _purchasePrice=_purchasePrice;
        Status = status;
    }
    public int GetYearInUse()
    {
        return DataSetDateTime.Now.Year - YearOfUse;
    }
    public abstract decimal CalculateAnnualMaintenceCost();
    public override string ToString()
    {
        return $"[{DeviceId}] {DeviceName} - Tình trạng: {Status}";
    }
}