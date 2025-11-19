using System;

namespace EVDMS.Core.Entities;

/// <summary>
/// Represents a user role in the EVDMS security system.
/// Defines a collection of permissions that can be assigned to users.
/// Examples: Admin, Manager, Sales Representative, Customer Service.
/// </summary>
public class Role : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool IsSystemRole { get; set; } = false; // Built-in roles that cannot be deleted
    
    // Navigation properties
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}