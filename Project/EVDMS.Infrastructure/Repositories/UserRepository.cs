using EVDMS.Application.Interfaces.Repositories;
using EVDMS.Core.Entities;
using EVDMS.Infrastructure.DBContext;


namespace EVDMS.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(EVDMSDBContext context) : base(context)
    {
    }
}
