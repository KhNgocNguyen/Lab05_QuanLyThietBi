/****************/  
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/****************/ 
using System;
// --- MÁY TÍNH ---
public class Computer : Device, INetworkable
{
    public int RamCapacityGB { get; set; }
    public string ProcessorType { get; set; }
    public bool HasDedicatedGpu { get; set; }

    public string IpAddress { get; private set; }
    public bool IsConnected { get; private set; }

    public Computer(string id, string name, int year, decimal price, DeviceStatus status, int ram, string cpu, bool gpu) 
        : base(id, name, year, price, status)
    {
        RamCapacityGB = ram;
        ProcessorType = cpu;
        HasDedicatedGpu = gpu;
    }

    public override decimal CalculateAnnualMaintenanceCost()
    {
        decimal cost = PurchasePrice * 0.05m;
        if (HasDedicatedGpu) cost += PurchasePrice * 0.02m;
        if (GetYearsInUse() > 5) cost += PurchasePrice * 0.01m;
        return cost;
    }

    public void Connect(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress)) throw new ArgumentException("IP không được rỗng.");
        if (IsConnected) throw new InvalidOperationException("Thiết bị đang kết nối.");
        IpAddress = ipAddress;
        IsConnected = true;
    }

    public void Disconnect()
    {
        IpAddress = null;
        IsConnected = false;
    }

    public override string ToString() => base.ToString() + $" | PC (RAM: {RamCapacityGB}GB, IP: {IpAddress ?? "None"})";
}

// --- MÁY IN BÌNH THƯỜNG ---
public class Printer : Device
{
    public PrinterType Type { get; set; }
    public int PrintedPages { get; set; }
    public bool IsColor { get; set; }

    public Printer(string id, string name, int year, decimal price, DeviceStatus status, PrinterType type, int pages, bool isColor) 
        : base(id, name, year, price, status)
    {
        Type = type;
        PrintedPages = pages;
        IsColor = isColor;
    }

    public override decimal CalculateAnnualMaintenanceCost()
    {
        decimal cost = PurchasePrice * 0.04m;
        if (PrintedPages > 100000) cost += 500000m;
        if (IsColor) cost += 300000m;
        return cost;
    }

    public override string ToString() => base.ToString() + $" | Máy in {Type} - Số trang: {PrintedPages}";
}

// --- MÁY IN CÓ MẠNG ---
public class NetworkPrinter : Printer, INetworkable
{
    public string IpAddress { get; private set; }
    public bool IsConnected { get; private set; }

    public NetworkPrinter(string id, string name, int year, decimal price, DeviceStatus status, PrinterType type, int pages, bool isColor) 
        : base(id, name, year, price, status, type, pages, isColor) { }

    public void Connect(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress)) throw new ArgumentException("IP không được rỗng.");
        if (IsConnected) throw new InvalidOperationException("Đang kết nối rồi.");
        IpAddress = ipAddress;
        IsConnected = true;
    }

    public void Disconnect()
    {
        IpAddress = null;
        IsConnected = false;
    }
}

// --- MÁY CHIẾU ---
public class Projector : Device
{
    public int BrightnessLumens { get; set; }
    public int LampHoursUsed { get; set; }

    public Projector(string id, string name, int year, decimal price, DeviceStatus status, int lumens, int lampHours) 
        : base(id, name, year, price, status)
    {
        BrightnessLumens = lumens;
        LampHoursUsed = lampHours;
    }

    public override decimal CalculateAnnualMaintenanceCost()
    {
        decimal cost = PurchasePrice * 0.03m;
        if (LampHoursUsed > 3000) cost += 1500000m;
        return cost;
    }

    public override string ToString() => base.ToString() + $" | Máy chiếu ({BrightnessLumens} lumens, Đèn: {LampHoursUsed}h)";
}