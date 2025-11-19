using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a customer in the Electric Vehicle Dealer Management System.
/// Contains essential customer information including personal details, contact information, 
/// and address. Customers can receive quotes, place orders, sign contracts, and book test drives.
/// </summary>
public class Customer : EntityBase
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    
    // Address Information
    public string Address { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    
    // Status
    public string Status { get; set; } = "Active"; // Active, Inactive
    
    // Navigation properties
    public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    public ICollection<TestDriveAppointment> TestDriveAppointments { get; set; } = new List<TestDriveAppointment>();
}