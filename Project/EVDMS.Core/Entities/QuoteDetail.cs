using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a line item detail for a quote in the EVDMS.
/// Contains specific product information, quantities, pricing, and line-specific details
/// for each product included in a dealer's quote to a customer.
/// </summary>
public class QuoteDetail : Auditable
{
    public Guid QuoteId { get; set; }
    public Guid ProductId { get; set; }
    
    // Quantity and Pricing
    public int Quantity { get; set; }
    public decimal BasePrice { get; set; }
    public decimal LineTotal { get; set; } // Quantity * BasePrice
    public decimal? DiscountAmount { get; set; }
    public decimal FinalLineTotal { get; set; } // LineTotal - DiscountAmount
    
    // Navigation properties
    public Quote Quote { get; set; } = null!;
    public Product Product { get; set; } = null!;
}