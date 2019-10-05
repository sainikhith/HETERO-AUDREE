using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIdentityJwt.Models;
namespace PIdentityJwt.Services
{
    public class RoleService :IRoleService
    {
        private DataContext _context;

        public RoleService(DataContext context)
        {
            _context = context;
        }

         public List<UsersInRoles> GetRolesByUserID(int userId)
        {

            //var role= _context.Roles.Where(w => w.Id == userId).ToList();
            var role = _context.UsersInRoles.Where(w => w.UserId == userId).ToList();
            //  var role = _context.Roles.SingleOrDefault(x => x.UserId == userId);

            // check if username exists
            if (role == null)
                return null;

            // authentication successful
            return role;
        }
        public Role Create(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }
    }
}
