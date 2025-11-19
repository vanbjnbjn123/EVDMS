using System;
using EVDMS.Application.Interfaces;

namespace EVDMS.Application.Features.Roles.Commands;

public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        // check for existing role, validate data, etc.
        bool roleExists = await _unitOfWork.Repository<Role>().ExistsAsync(r => r.Name == request.Name);
        if (roleExists)
        {
            throw new InvalidOperationException("Role with the same name already exists.");
        }
        var role = new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            IsSystemRole = request.IsSystemRole ?? false
        };

        await _unitOfWork.Repository<Role>().AddAsync(role);
        await _unitOfWork.SaveChangesAsync();

        return role.Id;
    }
}
