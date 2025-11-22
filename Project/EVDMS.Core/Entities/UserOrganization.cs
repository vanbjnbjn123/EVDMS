using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents the relationship between a user and their organization (Dealer or Manufacturer).
/// Determines which organization a user belongs to and their role within that organization.
/// </summary>
public class UserOrganization : Auditable
{
    public Guid UserId { get; set; }
    public string OrganizationType { get; set; } = string.Empty; // "Dealer" or "Manufacturer"
    
    // Organization IDs - only one should be populated based on OrganizationType
    public Guid? DealerId { get; set; } // Populated if OrganizationType = "Dealer"

    // Navigation properties
    public User User { get; set; } = null!;
    public Dealer? Dealer { get; set; }
}