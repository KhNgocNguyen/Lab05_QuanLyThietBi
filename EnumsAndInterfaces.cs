/****************/  
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/****************/  
using System;
public enum DeviceStatus
{
    Active,
    UnderMaintenance,
    Retired
}
public enum PrinterType
{
    Laser,
    Inkjet
}
public interface Inetworkable
{
    string IpAddress { get; }
    bool IsConnected { get; }
    void Connect (string ipAddress);
    void Disconnect();

}