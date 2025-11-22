using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents the inventory of electric vehicles available at a specific dealership.
/// Tracks stock levels, individual vehicle details (VIN, color, condition),
/// and availability status for sales and test drives.
/// </summary>
public class Inventory : EntityBase
{
    public Guid? DealerId { get; set; }
    public Guid ProductId { get; set; }
    
    // Stock Information
    public int QuantityInStock { get; set; }
    public int MinimumStock { get; set; }
    public int MaximumStock { get; set; }
    
    // Vehicle Specific Information
    // public string VehicleColor { get; set; } = string.Empty;
    // public string InteriorType { get; set; } = string.Empty;
    // public string AdditionalFeatures { get; set; } = string.Empty;
    // public string VIN { get; set; } = string.Empty; // Vehicle Identification Number
    // public string EngineNumber { get; set; } = string.Empty;
    // public string ChassisNumber { get; set; } = string.Empty;
    
    // Location and Storage
    // public string StorageLocation { get; set; } = string.Empty; // Showroom, Warehouse, Yard
    // public string StorageSection { get; set; } = string.Empty;
    // public string StoragePosition { get; set; } = string.Empty;
    
    // Status and Condition
    // public string Status { get; set; } = "Available"; // Available, Reserved, Sold, InTransit, Damaged, Maintenance
    // public string Condition { get; set; } = "New"; // New, Used, Damaged, Demo
    // public DateTime? ReceivedDate { get; set; }
    // public DateTime? LastInspectionDate { get; set; }
    // public string InspectionNotes { get; set; } = string.Empty;

    
    // Manufacturer Information
    // public string ManufacturerOrderNumber { get; set; } = string.Empty;
    // public DateTime? ManufacturerDeliveryDate { get; set; }
    // public string ManufacturerInvoiceNumber { get; set; } = string.Empty;
    
    
    // Navigation properties
    public Dealer? Dealer { get; set; }
    public Product? Product { get; set; }
    public ICollection<TestDriveAppointment>? TestDriveAppointments { get; set; }
}