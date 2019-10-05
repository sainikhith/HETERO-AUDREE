using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIdentityJwt.Models;

namespace PIdentityJwt.Services
{
   public interface IRoleService
    {
        List<UsersInRoles> GetRolesByUserID(int userId);
        Role Create(Role role);
    }
}
