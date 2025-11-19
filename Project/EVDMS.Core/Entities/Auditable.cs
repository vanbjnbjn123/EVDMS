using System;

namespace EVDMS.Core.Entities;

public abstract class Auditable
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }

    // For PostgreSQL, use uint instead of byte[] for concurrency control
    public uint Version { get; set; }
    
    // Soft Delete Properties
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}