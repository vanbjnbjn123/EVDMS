using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a promotional offer that can be applied to vehicle purchases.
/// Contains promotion details including name, code, discount type (percentage/fixed amount),
/// validity period, and status. Promotions provide discounts or special offers to customers.
/// </summary>
public class Promotion : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty; // Promotion code for customers
    
    // Promotion Type and Value
    public string Type { get; set; } = string.Empty; // Percentage, FixedAmount, Gift
    public decimal DiscountPercentage { get; set; }
    public decimal DiscountAmount { get; set; }
    
    // Validity Period
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; } = true;
}