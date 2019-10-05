using PIdentityJwt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIdentityJwt.Services
{
    public interface IMenuMasterService
    {
        List<MenuMaster> GetMenuByUserID(int userId);
        MenuMaster Create(MenuMaster menuMaster);
    }
}
