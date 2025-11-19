using System;

namespace EVDMS.API.RequestDTOs;

public class CreateRoleRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool? IsSystemRole { get; set; } = false;
}
