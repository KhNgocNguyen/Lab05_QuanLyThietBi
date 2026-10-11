/****************/  
// Mã sinh viên: 202418955
// Họ tên: Nguyễn Khánh Ngọc
/****************/
using System;
using System.Runtime.CompilerServices;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding=System.Text.Encoding.UTF8;
        Computer pc1 = new Computer ("PC01", "Dell Optiplex", 2021, 15000000, DeviceStatus.Active, 16, "i7", true);
        Computer pc2 = new Computer("PC02", "HP ProDesk", 2023, 10000000, DeviceStatus.Active, 8, "i5", false);
        Printer pr1 = new Printer("PR01", "Canon 2900", 2020, 3000000, DeviceStatus.UnderMaintenance, PrinterType.Laser, 120000, false); 
        NetworkPrinter pr2 = new NetworkPrinter("PR02", "Epson L805", 2024, 7000000, DeviceStatus.Active, PrinterType.Inkjet, 5000, true);
        
        Projector pj1 = new Projector("PJ01", "Sony VPL", 2018, 20000000, DeviceStatus.Active, 3500, 3200); 

        LabRoom lab1 = new LabRoom("L01", "Phòng Thực hành Phần mềm", 30);
        LabRoom lab2 = new LabRoom("L02", "Phòng Thực hành Mạng", 25);
        try
        {
            lab1.AddDevice(pc1);
            lab1.AddDevice(pr1);
            lab1.AddDevice(pj1);
            lab2.AddDevice(pc2);
            lab2.AddDevice(pr2);
            Console.WriteLine("--- THÊM THIẾT BỊ BỊ TRÙNG MÃ ---");
            lab1.AddDevice(pc1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
        Console.WriteLine("\n--- DANH SÁCH THIẾT BỊ PHÒNG L01 ---");
        foreach (var d in lab1.Devices) Console.WriteLine(d.ToString());

        Console.WriteLine($"\nTổng chi phí bảo trì dự kiến L01: {lab1.CalculateAnnualMaintenanceCost():N0} VNĐ");

        Console.WriteLine("\n--- THIẾT BỊ CẦN BẢO TRÌ (L01) ---");
        foreach (var d in lab1.GetDevicesRequiringMaintenance()) Console.WriteLine(d.DeviceName);

        Console.WriteLine("\n--- KẾT NỐI MẠNG ---");
        foreach (var device in lab1.Devices)
        {
            if (device is Inetworkable networkDevice)
            {
                networkDevice.Connect("192.168.1." + new Random().Next(10, 99));
                Console.WriteLine($"Đã kết nối {device.DeviceName} tại IP {networkDevice.IpAddress}");
            }
        }
    }
}