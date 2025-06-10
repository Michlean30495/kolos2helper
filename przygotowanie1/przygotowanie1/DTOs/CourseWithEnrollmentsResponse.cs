namespace przygotowanie1.DTOs;

public class CourseWithEnrollmentsResponse
{
    public string Message { get; set; } = null!;
    public CourseDto Course { get; set; } = null!;
    public List<EnrollmentResponseDto> Enrollments { get; set; } = new();
}