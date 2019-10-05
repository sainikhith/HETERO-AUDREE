using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIdentityJwt.DTOs;

namespace PIdentityJwt.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersInRoles> UsersInRoles { get; set; }
        
        public DbSet<MenuMaster> MenuMasters { get; set; }
        public DbSet<Submenu> Submenus { get; set; }
    }
}
