using System;
using System.Collections.Generic;

namespace EF_Labb_3.Models
{
    public partial class Course
    {
        public Course()
        {
            StuCourses = new HashSet<StuCourse>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string? CourseDesc { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<StuCourse> StuCourses { get; set; }
    }
}
