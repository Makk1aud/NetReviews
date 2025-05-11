using DataAccess.Interfaces;
using Domain.Entities;
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
        
        var hashedPassword = _userDomainService.HashPassword(password, out var salt);

        var newUser = new User()
        {
            Email = "makklaud@mail.ru",
            Nickname = "makklaud",
            Password = hashedPassword,
            Salt = salt,
            UserRankId = new Guid("b5a4fe45-415a-4245-b392-19e5d0de8d0e")
        };
        
        await _dbContext.Users.AddAsync(newUser, cancellationToken);
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