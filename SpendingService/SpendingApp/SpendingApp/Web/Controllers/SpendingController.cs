using Microsoft.AspNetCore.Mvc;
using SpendingApp.Models;
using SpendingApp.Services.Interfaces;

namespace SpendingApp.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SpendingController : ControllerBase
{
    private readonly ISpendingService _spendingService;

    public SpendingController(ISpendingService spendingService)
    {
        _spendingService = spendingService;
    }

    [HttpGet]
    [Route("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }

    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add(Spending spending, CancellationToken ct)
    {
        var added = await _spendingService.AddAsync(spending, ct);

        return Ok(added);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(Spending spending, CancellationToken ct)
    {
        var updated = await _spendingService.UpdateAsync(spending, ct);

        return Ok(updated);
    }

    [HttpGet]
    [Route("get/{id:int}")]
    public async Task<IActionResult> Get(int id, CancellationToken ct)
    {
        var spending = await _spendingService.GetByIdAsync(id, ct);

        return Ok(spending);
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var spending = await _spendingService.GetByAllAsync(ct);

        return Ok(spending);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _spendingService.RemoveByIdAsync(id, ct);

        return Ok();
    }
}