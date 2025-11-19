using System.Linq.Expressions;
using EVDMS.Application.Interfaces.Repositories;
using EVDMS.Core.Entities;
using EVDMS.Infrastructure.DBContext;

namespace EVDMS.Infrastructure.Repositories;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(EVDMSDBContext context) : base(context)
    {
    }

}
