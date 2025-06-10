namespace przygotowanie1.DTOs;

public class EnrollmentDto
{
    public StudentDto Student { get; set; } = null!;
    public CourseDto Course { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
}