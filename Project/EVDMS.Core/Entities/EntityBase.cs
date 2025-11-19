using System;

namespace EVDMS.Core.Entities;

public abstract class EntityBase: Auditable
{
    public Guid Id { get; set; }
}