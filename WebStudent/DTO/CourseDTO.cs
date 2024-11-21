namespace WebStudent.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        // List of Students enrolled in the course
        public List<StudentDTO>? Students { get; set; }
    }
}
