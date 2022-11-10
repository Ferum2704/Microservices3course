using Microsoft.AspNetCore.Mvc;
using SpendingApp.Persistence;

namespace SpendingApp.Controllers;

[ApiController]
[Route("[controller]")]
public class SpendingController : ControllerBase
{
    private readonly SpendingContext _context;

    public SpendingController(SpendingContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }

    [HttpGet]
    [Route("ping-item")]
    public async Task<IActionResult> PingItem(int counter)
    {
        var addedPing = _context.Pings.Add(new PingItem(counter));
        await _context.SaveChangesAsync();

        return Ok(addedPing.Entity.Id);
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add()
    {
        return Ok(new
        {
            Currency = "UAH",
            Value = "2001",
            Item = "Food"
        });
    }

    [HttpPut]
    [Route("update/{id:int}")]
    public IActionResult Update(int id)
    {
        return Ok(new
        {
            Id = id,
            Currency = "UAH",
            Value = "2000",
            Item = "Food"
        });
    }

    [HttpGet]
    [Route("get/{id:int}")]
    public IActionResult Get(int id)
    {
        return Ok(new
        {
            Id = id,
            Currency = "UAH",
            Value = "2000",
            Item = "Food"
        });
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public IActionResult Delete(int id)
    {
        return Ok(new
        {
            Success = true,
        });
    }
}