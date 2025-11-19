using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a scheduled test drive appointment for a customer to experience an electric vehicle.
/// Contains appointment details including date/time, duration, customer and vehicle information,
/// and appointment status. Helps customers evaluate vehicles before making purchase decisions.
/// </summary>
public class TestDriveAppointment : EntityBase
{
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public Guid DealerId { get; set; }
    
    // Appointment Details
    public DateTime ScheduledDate { get; set; }
    public TimeSpan ScheduledTime { get; set; }
    public int EstimatedDuration { get; set; } // in minutes
    
    // Status
    public string Status { get; set; } = "Scheduled"; // Scheduled, Confirmed, Completed, Cancelled
    
    // Notes
    public string Notes { get; set; } = string.Empty;
    
    // Navigation properties
    public Customer Customer { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public Dealer Dealer { get; set; } = null!;
}