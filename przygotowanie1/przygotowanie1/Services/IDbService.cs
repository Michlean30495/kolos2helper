using przygotowanie1.DTOs;

namespace przygotowanie1.Services;

public interface IDbService
{
    Task<IEnumerable<EnrollmentDto>> GetAllEnrollmentsAsync();
    Task<CourseWithEnrollmentsResponse> AddCourseWithEnrollmentsAsync(CourseWithEnrollmentsRequest request);
}