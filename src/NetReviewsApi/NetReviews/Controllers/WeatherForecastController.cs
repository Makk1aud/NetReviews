using System.Security.Claims;
using DataAccess.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetReviews.Controllers;

[ApiController]
[Route("api")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IDbContext _dbContext;
    private readonly IUserDomainService _userDomainService;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IDbContext dbContext,
        IUserDomainService userDomainService)
    {
        _logger = logger;
        _dbContext = dbContext;
        _userDomainService = userDomainService;
    }
    
    [Authorize]
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok(User.Claims.ToDictionary(c => c.Type, c => c.Value));
    }
}