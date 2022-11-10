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

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add(CancellationToken ct)
    {
        var added = _context.Spendings.Add(new Spending
        {
            Currency = Currency.Uah,
            Value = 2001,
            Item = "Food"
        });
        await _context.SaveChangesAsync(ct);

        return Ok(added.Entity);
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
            Item = "Food",
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