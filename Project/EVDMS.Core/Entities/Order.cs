using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a confirmed vehicle order placed by a customer.
/// Contains order details including total amount, payment tracking, delivery information,
/// and current status. Orders are typically created from accepted quotes and lead to contracts.
/// </summary>
public class Order : EntityBase
{
    public string OrderNumber { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public Guid DealerId { get; set; }
    public Guid? QuoteId { get; set; } // Reference to accepted quote
    
    // Order Details
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Confirmed, Delivered, Cancelled
    public DateTime? DeliveryDate { get; set; }
    
    // Payment Information
    public decimal PaidAmount { get; set; } // Amount paid so far
    public bool IsFullyPaid { get; set; } = false; // True if total amount is paid
    
    // Navigation properties
    public Customer Customer { get; set; } = null!;
    public Dealer Dealer { get; set; } = null!;
    public Quote? Quote { get; set; }
    public Contract? Contract { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}