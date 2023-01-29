﻿using System;
using System.Collections.Generic;

namespace EF_Labb_3.Models
{
    public partial class StuGrade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public int StuGradeId { get; set; }
        public DateTime GradeDate { get; set; }
        public string? GradeJustification { get; set; }
        public int? RoleId { get; set; }

        public virtual Grade Grade { get; set; } = null!;
        public virtual Role? Role { get; set; }
        public virtual Student Student { get; set; } = null!;
    }
}
