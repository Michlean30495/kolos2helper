using Microsoft.AspNetCore.Mvc;
using przygotowanie1.DTOs;
using przygotowanie1.Services;

namespace ExampleTest2.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly IDbService _dbService;

    public CoursesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("with-enrollments")]
    public async Task<ActionResult<CourseWithEnrollmentsResponse>> AddCourseWithEnrollments(
        [FromBody] CourseWithEnrollmentsRequest request)
    {
        var result = await _dbService.AddCourseWithEnrollmentsAsync(request);
        return Created(string.Empty, result);
    }
}