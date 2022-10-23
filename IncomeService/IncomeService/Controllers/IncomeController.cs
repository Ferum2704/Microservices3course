using IncomeService.Models;
using Microsoft.AspNetCore.Mvc;

namespace IncomeService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly List<IncomeRecord> _records = new()
        {
            new IncomeRecord() {Id = 1, Sum = 200, Date = DateTime.ParseExact("4/1/2022", "M/d/yyyy", null)},
            new IncomeRecord() {Id = 2, Sum = 1000, Date = DateTime.ParseExact("4/29/2022", "M/d/yyyy", null)},
            new IncomeRecord() {Id = 3, Sum = 150, Date = DateTime.ParseExact("5/18/2022", "M/d/yyyy", null)},
            new IncomeRecord() {Id = 4, Sum = 200, Date = DateTime.ParseExact("7/7/2022", "M/d/yyyy", null)},
            new IncomeRecord() {Id = 5, Sum = 500, Date = DateTime.ParseExact("7/7/2022", "M/d/yyyy", null)},
        };

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("pong");
        }

        [HttpGet]
        public IActionResult GetIncomes()
        {
            return Ok(_records);
        }

        [HttpGet]
        public IActionResult GetIncomeById(int? id)
        {
            var foundRecord = _records.SingleOrDefault(r => r.Id == id);
            if (foundRecord != null)
            {
                return Ok(foundRecord);
            }

            return NotFound("No record with such id");
        }

        [HttpPut]
        public IActionResult UpdateIncome(IncomeRecord incomeRecord)
        {
            var foundRecord = _records.SingleOrDefault(r => r.Id == incomeRecord.Id);
            if (foundRecord == null)
            {
                return NotFound("No record with such id");
            }

            return Ok("Update was successful");

        }

        [HttpDelete]
        public IActionResult DeleteIncome(int? id)
        {
            var foundRecord = _records.SingleOrDefault(r => r.Id == id);
            if (foundRecord == null)
            {
                return NotFound("No record with such id");
            }

            return _records.Remove(foundRecord) ? Ok("Delete was successful") : StatusCode(500, "Something went wrong");
        }
    }
}