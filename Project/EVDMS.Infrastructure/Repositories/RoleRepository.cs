using EVDMS.Application.Interfaces.Repositories;
using EVDMS.Core.Entities;
using EVDMS.Infrastructure.DBContext;

namespace EVDMS.Infrastructure.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(EVDMSDBContext context) : base(context)
    {
    }
}
