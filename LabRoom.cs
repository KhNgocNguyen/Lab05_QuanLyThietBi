/****************/  
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/****************/ 
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
public class LabRoom
{
    public string RoomId { get; set; }
    public string RoomName { get; set; }
    public int Capacity { get; set; }

    private List<Device> _devices = new List<Device>();

    public LabRoom(string roomId, string roomName, int capacity)
    {
        RoomId= roomId;
        RoomName=roomName;
        Capacity = capacity;
    }
    public IReadOnlyList<Device> Devices => _devices.AsReadOnly();
    public void AddDevice (Device device)
    {
        if (device == null) throw new ArgumentNullException("Thiết bị không được null.");
        if (_devices.Any(d => d.DeviceId == device.DeviceId))
            throw new InvalidOperationException($"Thiết bị có mã {device.DeviceId} đã tồn tại trong phòng.");
        
        _devices.Add(device);
    }
    public bool RemoveDevice(string deviceId)
    {
        var dev = FindDevice(deviceId);
        if (dev != null)
        {
            _devices.Remove(dev);
            return true;
        }
        return false;
    }
    public Device FindDevice(string deviceId)
    {
        return _devices.FirstOrDefault(d => d.DeviceId == deviceId);
    }
    public decimal CalculateAnnualMaintenanceCost()
    {
        return _devices.Sum(d => d.CalculateAnnualMaintenanceCost());
    }
    public List<Device> GetDevicesRequiringMaintenance()
    {
        return _devices.Where(d => d.Status == DeviceStatus.UnderMaintenance || d.GetYearInUse() >5).ToList();
    }
}