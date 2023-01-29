using System;
using System.Collections.Generic;

namespace EF_Labb_3.Models
{
    public partial class StaffRole
    {
        public int StaffId { get; set; }
        public int StaffRoleId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual staff Staff { get; set; } = null!;
    }
}
