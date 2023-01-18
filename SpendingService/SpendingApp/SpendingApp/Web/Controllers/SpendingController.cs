using Microsoft.AspNetCore.Mvc;
using SpendingApp.Messages;
using SpendingApp.Models;
using SpendingApp.Services.Interfaces;

namespace SpendingApp.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SpendingController : ControllerBase
{
    private readonly ISpendingService _spendingService;
    private readonly IStatisticsService _statisticsService;

    public SpendingController(ISpendingService spendingService, IStatisticsService statisticsService)
    {
        _spendingService = spendingService;
        _statisticsService = statisticsService;
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
        var spending = await _spendingService.GetAllAsync(ct);

        return Ok(spending);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await _spendingService.RemoveByIdAsync(id, ct);

        return Ok();
    }

    [HttpGet]
    [Route("total-profit")]
    public async Task<IActionResult> GetTotalProfit(CancellationToken ct)
    {
        try
        {
            var totalProfit = await _statisticsService.GetTotalProfitAsync(ct);

            return Ok(totalProfit);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("failures")]
    public async Task<IActionResult> TryGetFailures(CancellationToken ct)
    {
        var failureModel = await _statisticsService.TryGetFailuresAsync(ct);

        return Ok(failureModel);
    }

    [HttpPost]
    [Route("first-topic-message")]
    public async Task<IActionResult> SendFirstTopicMessage(CancellationToken ct)
    {
        var a = new Producer();
        a.Bruh("firstTopic");
        return Ok();
    }

    [HttpPost]
    [Route("second-topic-message")]
    public async Task<IActionResult> SendSecondTopicMessage(CancellationToken ct)
    {
        var a = new Producer();
        a.Bruh("secondTopic");
        return Ok();
    }
}