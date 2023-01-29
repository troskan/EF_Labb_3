﻿using System;
using System.Collections.Generic;

namespace EF_Labb_3.Models
{
    public partial class StuCourse
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int StuCourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
