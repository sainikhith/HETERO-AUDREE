using PIdentityJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIdentityJwt.Services
{
    public class UsersInRolesService : IUsersInRolesService
    {
        private readonly DataContext _dataContext;

        public UsersInRolesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<UsersInRoles> GetUserInRolesByID(int userId)
        {
            var role = _dataContext.Roles.Where(w => w.Id == userId).ToList();
            //  var role = _context.Roles.SingleOrDefault(x => x.UserId == userId);

            // check if username exists
            if (role == null)
                return null;

            // authentication successful
            return null;
        }
        public UsersInRoles Create(UsersInRoles usersInRoles)
        {
            _dataContext.UsersInRoles.Add(usersInRoles);
            _dataContext.SaveChanges();
            return usersInRoles;
        }
    }
}
