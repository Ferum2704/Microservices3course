using IncomeService.Messages;
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
        private readonly NumOfRetriesHolder _numOfRetriesHolder;

        public IncomeController(IIncomeRecordsService incomeRecordsService, NumOfRetriesHolder numOfRetriesHolder)
        {
            _incomeRecordsService = incomeRecordsService;
            _numOfRetriesHolder = numOfRetriesHolder;
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
        [Route("get-all")]
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

        [HttpGet]
        [Route("total")]
        public IActionResult GetTotalIncomeValue()
        {
            var total = _incomeRecordsService.GetTotal();
            return Ok(total);
        }


        [HttpGet]
        [Route("failure")]
        public IActionResult GetFailure(bool isForRetries)
        {
            if (!isForRetries)
            {
                Thread.Sleep(700);
                return StatusCode(500);
            }

            if (_numOfRetriesHolder.NumOfRetries == 4)
            {
                var result = _numOfRetriesHolder.NumOfRetries;
                _numOfRetriesHolder.NumOfRetries = 0;
                return Ok(result);
            }

            _numOfRetriesHolder.NumOfRetries++;
            return StatusCode(500);
        }

        [HttpGet]
        [Route("first-topic-message")]
        public IActionResult GetFirstTopicMessage()
        {
            return Ok(new Consumer().Bruh("firstTopic"));
        }

        [HttpGet]
        [Route("second-topic-message")]
        public IActionResult GetSecondTopicMessage()
        {
            return Ok(new Consumer().Bruh("secondTopic"));
        }
    }
}