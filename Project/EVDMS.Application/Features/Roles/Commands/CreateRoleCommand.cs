using System.Runtime.InteropServices;

namespace EVDMS.Application.Features.Roles.Commands;

public record CreateRoleCommand(string Name, string Description, bool? IsSystemRole = false) : IRequest<Guid>;
