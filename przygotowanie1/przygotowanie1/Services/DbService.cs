using Microsoft.EntityFrameworkCore;
using przygotowanie1.Data;
using przygotowanie1.DTOs;
using przygotowanie1.Models;

namespace przygotowanie1.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentsAsync()
    {
        var enrollments = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();

        return enrollments.Select(e => new EnrollmentDto
        {
            Student = new StudentDto
            {
                Id = e.Student.Id,
                FirstName = e.Student.FirstName,
                LastName = e.Student.LastName,
                Email = e.Student.Email
            },
            Course = new CourseDto
            {
                Id = e.Course.Id,
                Title = e.Course.Title,
                Teacher = e.Course.Teacher
            },
            EnrollmentDate = e.EnrollmentDate
        });
    }

    public async Task<CourseWithEnrollmentsResponse> AddCourseWithEnrollmentsAsync(CourseWithEnrollmentsRequest request)
    {
        var course = new Course
        {
            Title = request.Title,
            Credits = request.Credits,
            Teacher = request.Teacher
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        var enrollmentResponses = new List<EnrollmentResponseDto>();

        foreach (var s in request.Students)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(st => st.FirstName == s.FirstName &&
                                           st.LastName == s.LastName &&
                                           st.Email == s.Email);

            if (student == null)
            {
                student = new Student
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email
                };
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }

            var enrollment = new Enrollment
            {
                StudentId = student.Id,
                CourseId = course.Id,
                EnrollmentDate = DateTime.UtcNow
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            enrollmentResponses.Add(new EnrollmentResponseDto
            {
                StudentId = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                EnrollmentDate = enrollment.EnrollmentDate
            });
        }

        return new CourseWithEnrollmentsResponse
        {
            Message = "Kurs został utworzony i studenci zostali zapisani.",
            Course = new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Teacher = course.Teacher
            },
            Enrollments = enrollmentResponses
        };
    }
}