using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIdentityJwt.Models;

namespace PIdentityJwt.Services
{
    public class SubmenuService : ISubmenuService
    {
        private DataContext _context;

        public SubmenuService(DataContext context)
        {
            _context = context;
        }
        public Submenu Create(Submenu submenu)
        {
            _context.Submenus.Add(submenu);
            _context.SaveChanges();
            return submenu;
        }

        public List<Submenu> GetSubmenuByRoleID(int roleId)
        {
            var submenu = _context.Submenus.Where(w => w.Id == roleId).ToList();
            if (submenu == null)
                return null;
            return submenu;
        }
    }
}
