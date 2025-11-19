using System;

namespace EVDMS.Core.Entities;

public class RolePermission : Auditable
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
    public bool IsGranted { get; set; } = true; // Indicates if the permission is granted or denied. Ex: true = granted, false = denied.
    
    // Navigation properties
    public Role Role { get; set; } = null!;
    public Permission Permission { get; set; } = null!;
}