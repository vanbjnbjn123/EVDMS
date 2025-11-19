using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a line item detail for an order in the EVDMS.
/// Contains specific product information, quantities, pricing, and line-specific details
/// for each product included in a customer's order.
/// </summary>
public class OrderDetail : EntityBase
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    
    // Quantity and Pricing
    public int Quantity { get; set; }
    public decimal BasePrice { get; set; } // Base product price
    public decimal LineTotal { get; set; } // Quantity * BasePrice
    public decimal DiscountAmount { get; set; }
    public decimal FinalLineTotal { get; set; } // LineTotal - DiscountAmount
    
    // Line Item Status
    public string Status { get; set; } = "Pending"; // Pending, Confirmed, Delivered, Cancelled
    public DateTime? DeliveryDate { get; set; }
    
    // Navigation properties
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}