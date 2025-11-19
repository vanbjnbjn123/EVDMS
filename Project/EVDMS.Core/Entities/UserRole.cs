using System;

namespace EVDMS.Core.Entities;

public class UserRole : Auditable
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public DateTime? ExpiresAt { get; set; }
    
    // Navigation properties
    public User User { get; set; } = null!;
    public Role Role { get; set; } = null!;
}