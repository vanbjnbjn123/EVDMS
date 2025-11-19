using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a price proposal for an electric vehicle provided by a dealer to a customer.
/// Contains pricing information (base price, discounts, total), validity period, and status.
/// Quotes can be accepted to become orders in the vehicle purchasing workflow.
/// </summary>
public class Quote : EntityBase
{
    public string QuoteNumber { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public Guid DealerId { get; set; }
    public Guid? OrderId { get; set; } // Linked order if quote is accepted
    
    // Quote Details
    public decimal BaseTotalPrice { get; set; }
    public decimal TotalDiscountAmount { get; set; }
    public decimal TotalPrice { get; set; }
    
    // Quote Status and Validity
    public string Status { get; set; } = "Draft"; // Draft, Sent, Accepted, Rejected, Expired
    
    // Navigation properties
    public Customer Customer { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public Dealer Dealer { get; set; } = null!;
    public Order? Order { get; set; }
    public ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();
}