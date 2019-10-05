using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIdentityJwt.Models
{
    public class Submenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int MenuMasterId { get; set; }
        public virtual MenuMaster MenuMaster { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
