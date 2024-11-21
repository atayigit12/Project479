namespace WebStudent.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public decimal? Gpa { get; set; }

        // List of Courses the student is enrolled in
        public List<CourseDTO>? Courses { get; set; }
    }
}
