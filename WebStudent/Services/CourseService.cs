using Microsoft.EntityFrameworkCore;
using WebStudent.DTO;
using WebStudent.Models;

public class CourseService
{
    private readonly StudentsDbContext _context;

    public CourseService(StudentsDbContext context)
    {
        _context = context;
    }

    public IEnumerable<CourseDTO> GetAllCourses()
    {
        return _context.Courses
            .Include(c => c.StudentCourses)
            .ThenInclude(sc => sc.Student)
            .Select(c => new CourseDTO
            {
                Id = c.Id,
                Name = c.Name,
                Students = c.StudentCourses.Select(sc => new StudentDTO
                {
                    Id = sc.Student.Id,
                    Name = sc.Student.Name,
                    Surname = sc.Student.Surname
                }).ToList()
            }).ToList();
    }
}
