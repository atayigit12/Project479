using System;
using System.Collections.Generic;

namespace WebStudent.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // Navigation property for the many-to-many relationship
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
