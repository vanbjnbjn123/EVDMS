using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents an authorized electric vehicle dealership in the EVDMS.
/// Contains dealer information including name, license, contact details, and location.
/// Dealers create quotes, process orders, sign contracts, and manage vehicle sales operations.
/// </summary>
public class Dealer : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    // Address Information
    public string Address { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    
    // Business Information
    public bool IsActive { get; set; } = true;
    public string Tax { get; set; } = string.Empty;
    
    // Navigation properties
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    public ICollection<TestDriveAppointment> TestDriveAppointments { get; set; } = new List<TestDriveAppointment>();
    public ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
    public ICollection<UserOrganization> UserOrganizations { get; set; } = new List<UserOrganization>();
}