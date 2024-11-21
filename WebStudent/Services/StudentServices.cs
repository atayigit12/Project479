using Microsoft.EntityFrameworkCore;
using WebStudent.DTO;
using WebStudent.Models;

public class StudentService
{
    private readonly StudentsDbContext _context;

    public StudentService(StudentsDbContext context)
    {
        _context = context;
    }

    public IEnumerable<StudentDTO> GetAllStudents()
    {
        return _context.Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                BirthDate = s.BirthDate,
                Gpa = s.Gpa,
                Courses = s.StudentCourses.Select(sc => new CourseDTO
                {
                    Id = sc.Course.Id,
                    Name = sc.Course.Name
                }).ToList()
            }).ToList();
    }

    public void EnrollStudentInCourse(int studentId, int courseId)
    {
        var studentCourse = new StudentCourse
        {
            StudentId = studentId,
            CourseId = courseId
        };

        _context.StudentCourses.Add(studentCourse);
        _context.SaveChanges();
    }

    public void RemoveStudentFromCourse(int studentId, int courseId)
    {
        var studentCourse = _context.StudentCourses
            .FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);

        if (studentCourse != null)
        {
            _context.StudentCourses.Remove(studentCourse);
            _context.SaveChanges();
        }
    }
    public IEnumerable<StudentCourseDTO> GetStudentCourses()
    {
        return _context.StudentCourses
            .Include(sc => sc.Student)
            .Include(sc => sc.Course)
            .Select(sc => new StudentCourseDTO
            {
                StudentId = sc.StudentId,
                CourseId = sc.CourseId,
                StudentName = sc.Student.Name,
                CourseName = sc.Course.Name,
                EnrollmentDate = null // Adjust as needed if such a property exists
            }).ToList();
    }
}
