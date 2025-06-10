namespace przygotowanie1.DTOs;

public class CourseWithEnrollmentsRequest
{
    public string Title { get; set; } = null!;
    public string Credits { get; set; } = null!;
    public string Teacher { get; set; } = null!;
    public List<StudentRequestDto> Students { get; set; } = new();
}