using Microsoft.AspNetCore.Mvc;
using przygotowanie1.DTOs;
using przygotowanie1.Services;

namespace ExampleTest2.Controllers;

[ApiController]
[Route("api/enrollments")]
public class EnrollmentsController : ControllerBase
{
    private readonly IDbService _dbService;

    public EnrollmentsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetAllEnrollments()
    {
        var enrollments = await _dbService.GetAllEnrollmentsAsync();
        return Ok(enrollments);
    }
}