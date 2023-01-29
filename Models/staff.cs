using System;
using System.Collections.Generic;

namespace EF_Labb_3.Models
{
    public partial class staff
    {
        public staff()
        {
            StaffRoles = new HashSet<StaffRole>();
        }

        public int StaffId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int Ssn { get; set; }

        public virtual ICollection<StaffRole> StaffRoles { get; set; }
    }
}
