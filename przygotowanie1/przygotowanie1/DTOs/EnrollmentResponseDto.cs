namespace przygotowanie1.DTOs;

public class EnrollmentResponseDto
{
    public int StudentId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
}