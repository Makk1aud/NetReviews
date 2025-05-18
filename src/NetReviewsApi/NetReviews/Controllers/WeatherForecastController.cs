using DataAccess.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
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

    [HttpGet("ping")]
    public async Task<IActionResult> Ping(string password, CancellationToken cancellationToken)
    {
        //_dbContext.UserRanks.Add(new() { Description = "Новый", Title = "Новый Title" });

        var result = _dbContext.Authors.FirstOrDefault(x => x.AuthorType == AuthorTypes.Operator);
        
        var athor = new Author()
        {
            AuthorType = AuthorTypes.Operator,
            Birthday = DateOnly.FromDateTime(DateTime.Now),
            FirstName = "Operator 1",
            LastName = "Operator 2"
        };
        
        await _dbContext.Authors.AddAsync(athor, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Ok("pong");  
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}