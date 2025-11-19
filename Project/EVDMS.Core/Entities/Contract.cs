using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a legal contract for vehicle purchase between a customer and dealer.
/// Contains contract details including contract number, value, type (Sale/Lease/Finance),
/// contract date, signing status, and notes. Contracts finalize the vehicle purchase process.
/// </summary>
public class Contract : EntityBase
{
    public string ContractNumber { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public Guid OrderId { get; set; }
    public Guid DealerId { get; set; }
    public Guid StaffId { get; set; }
    
    // Contract Details
    public DateTime ContractDate { get; set; }
    public string ContractType { get; set; } = string.Empty; // Sale, Lease, Finance
    
    public DateTime? SignedAt { get; set; }

    // File and Document Management
    public string[]? Files { get; set; } // URLs or paths to contract documents
    
    // Navigation properties
    public Customer Customer { get; set; } = null!;
    public Order Order { get; set; } = null!;
    public Dealer Dealer { get; set; } = null!;
    public User Staff { get; set; } = null!;
}