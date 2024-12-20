﻿using System;
using System.Collections.Generic;

namespace WebStudent.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public decimal? Gpa { get; set; }

        // Navigation property for the many-to-many relationship
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
