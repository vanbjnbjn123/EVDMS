using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a specific permission in the EVDMS security system.
/// Defines granular access rights for resources and actions (e.g., "Create Orders", "View Reports").
/// Permissions are assigned to roles, which are then assigned to users.
/// </summary>
public class Permission : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Resource { get; set; } = string.Empty; // e.g., "User", "Product", "Order", "Report"
    public string Action { get; set; } = string.Empty; // e.g., "Create", "Read", "Update", "Delete"
    public bool IsActive { get; set; } = true;
    
    // Permission code for easy reference in code
    public string Code { get; set; } = string.Empty; // e.g., "USER_CREATE", "PRODUCT_DELETE"
    
    // Navigation properties
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}