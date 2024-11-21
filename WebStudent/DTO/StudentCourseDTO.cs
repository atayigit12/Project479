namespace WebStudent.DTO
{
    public class StudentCourseDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public string? StudentName { get; set; }
        public string? CourseName { get; set; }
        public DateTime? EnrollmentDate { get; set; } // Example of an additional property
    }
}
