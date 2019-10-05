using PIdentityJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIdentityJwt.Services
{
    public interface IUsersInRolesService
    {
        List<UsersInRoles> GetUserInRolesByID(int userId);
        UsersInRoles Create(UsersInRoles usersInRoles);
    }
}
