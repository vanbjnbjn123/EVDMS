using System;
using System.Collections.Generic;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a vehicle manufacturer (hãng xe) in the system.
/// Contains manufacturer information, credentials, and business relationships.
/// </summary>
public class Manufacturer : EntityBase
{
    public string ManufacturerName { get; set; } = string.Empty;
    public string ManufacturerCode { get; set; } = string.Empty; // Unique identifier, ex: "TESLA", "NISSAN"
    public string BrandName { get; set; } = string.Empty; // Commercial brand name, ex: "Tesla", "Nissan"

    //navigation properties
    public ICollection<UserOrganization> UserOrganizations { get; set; } = new List<UserOrganization>();
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}