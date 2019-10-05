using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIdentityJwt.Models;

namespace PIdentityJwt.Services
{
    public class MenuMasterService : IMenuMasterService
    {
        private DataContext _context;
        public MenuMasterService(DataContext context)
        {
            _context = context;
        }
        public MenuMaster Create(MenuMaster menuMaster)
        {
            _context.MenuMasters.Add(menuMaster);
            _context.SaveChanges();
            return menuMaster;
        }

        public List<MenuMaster> GetMenuByUserID(int userId)
        {
            var menu = _context.MenuMasters.Where(w => w.Id == userId).ToList();
            //  var role = _context.Roles.SingleOrDefault(x => x.UserId == userId);

            // check if username exists
            if (menu == null)
                return null;

            // authentication successful
            return menu;
        }
    }
}
