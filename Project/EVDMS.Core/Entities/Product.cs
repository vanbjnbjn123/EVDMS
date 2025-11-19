using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents an electric vehicle product available for sale in the dealership.
/// Contains vehicle specifications including brand, model, year, technical details,
/// pricing information, and availability status. Products can be quoted, ordered, and sold.
/// </summary>
public class Product : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string VehicleType { get; set; } = string.Empty; // Sedan, SUV, Hatchback, etc.
    public decimal Price { get; set; }
    
    // Electric Vehicle Specific Properties
    public double BatteryCapacity { get; set; } // in kWh
    public int Range { get; set; } // in kilometers
    public int ChargingTime { get; set; } // in minutes (0-80%)
    public string ChargingType { get; set; } = string.Empty; // Type 2, CCS, CHAdeMO
    public int MotorPower { get; set; } // in kW
    public int MaxSpeed { get; set; } // in km/h
    public string DriveType { get; set; } = string.Empty; // FWD, RWD, AWD
    
    // General Vehicle Properties
    public int SeatingCapacity { get; set; }
    public string Color { get; set; } = string.Empty;
    public string InteriorMaterial { get; set; } = string.Empty; // Leather, Fabric, etc.
    public double Weight { get; set; } // in kg
    public double Length { get; set; } // in meters
    public double Width { get; set; } // in meters
    public double Height { get; set; } // in meters
    
    // Business Properties
    public string Description { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
    public string[] ImageUrl { get; set; } = Array.Empty<string>();
    
    // Navigation properties
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    // public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public ICollection<TestDriveAppointment> TestDriveAppointments { get; set; } = new List<TestDriveAppointment>();
}
