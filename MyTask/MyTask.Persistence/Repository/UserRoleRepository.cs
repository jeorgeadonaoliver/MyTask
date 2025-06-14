using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyTask.Api.Client.MyTaskDbModel;
using MyTask.Application.Contracts;
using MyTask.Persistence.MyTaskDb;
using System.Linq.Expressions;

namespace MyTask.Persistence.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(MyTaskDbContext context) : base(context) { }

        public async Task<bool> IsUserRoleExistById(Guid guid)
        {
            return await _context.UserRoles.AsNoTracking().AllAsync(x => x.RoleId == guid);
        }

        public async Task<bool> IsUserRoleExistByName(string name)
        {
            return await _context.UserRoles.AsNoTracking().AnyAsync(x => x.Name == name);
        }

        public async Task<bool> UpdateRoleAsync(UserRole role) {

            Expression<Func<SetPropertyCalls<UserRole>, SetPropertyCalls<UserRole>>> expression =
                setter => setter
                    .SetProperty(sp => sp.RoleId, role.RoleId)
                    .SetProperty(sp => sp.Name, role.Name);

            var data = await UpdateAsync(x => x.RoleId == role.RoleId, expression);
            return data.Value;
        }
        
    }
}
