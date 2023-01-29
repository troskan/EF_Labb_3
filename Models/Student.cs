using System;
using System.Collections.Generic;

namespace EF_Labb_3.Models
{
    public partial class Student
    {
        public Student()
        {
            StuCourses = new HashSet<StuCourse>();
            StuGrades = new HashSet<StuGrade>();
        }

        public int StudentId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int Ssn { get; set; }

        public virtual ICollection<StuCourse> StuCourses { get; set; }
        public virtual ICollection<StuGrade> StuGrades { get; set; }
    }
}
