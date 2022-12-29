using IncomeService.Models;
using IncomeService.Services;
using IncomeService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IncomeService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeRecordsService _incomeRecordsService;

        public IncomeController(IIncomeRecordsService incomeRecordsService)
        {
            _incomeRecordsService = incomeRecordsService;
        }

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(IncomeRecord model, CancellationToken ct)
        {
            try
            {
                var added = await _incomeRecordsService.AddAsync(model, ct);
                return Ok(added);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("get")]
        public IActionResult GetAllIncomes(CancellationToken ct)
        {
            var incomes = _incomeRecordsService.GetAllAsync(ct);
            return Ok(incomes);
        }
        [HttpGet]
        [Route("get/{id:int}")]
        public IActionResult GetIncomeById(int id, CancellationToken ct)
        {
            var model = _incomeRecordsService.GetByIdAsync(id, ct)!;
            return Ok(model);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateIncome(IncomeRecord model, CancellationToken ct)
        {
            var updated = await _incomeRecordsService.UpdateAsync(model, ct);
            return Ok(updated);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteIncome(int id, CancellationToken ct)
        {
            await _incomeRecordsService.RemoveByIdAsync(id, ct);
            return Ok();
        }
    }
}