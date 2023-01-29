﻿using System;
using System.Collections.Generic;

namespace EF_Labb_3.Models
{
    public partial class Grade
    {
        public Grade()
        {
            StuGrades = new HashSet<StuGrade>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; } = null!;

        public virtual ICollection<StuGrade> StuGrades { get; set; }
    }
}
