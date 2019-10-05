using PIdentityJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIdentityJwt.Services
{
    public interface ISubmenuService
    {
        List<Submenu> GetSubmenuByRoleID(int roleId);
        Submenu Create(Submenu submenu);
    }
}
