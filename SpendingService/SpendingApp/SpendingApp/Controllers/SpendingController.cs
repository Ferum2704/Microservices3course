using Microsoft.AspNetCore.Mvc;

namespace SpendingApp.Controllers;

[ApiController]
[Route("[controller]")]
public class SpendingController : ControllerBase
{
    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
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