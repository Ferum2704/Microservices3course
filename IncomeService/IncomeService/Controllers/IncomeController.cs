using IncomeService.Models;
using IncomeService.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IncomeService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IncomeDbContext _context;
        public IncomeController(IncomeDbContext context)
        {
            _context = context;
        }
        private readonly List<IncomeRecord> _records = new()
        {
            new IncomeRecord() {Id = 1, Sum = 200, Date = DateTime.ParseExact("4/1/2022", "M/d/yyyy", null)},
            new IncomeRecord() {Id = 2, Sum = 1000, Date = DateTime.ParseExact("4/29/2022", "M/d/yyyy", null)},
            new IncomeRecord() {Id = 3, Sum = 150, Date = DateTime.ParseExact("5/18/2022", "M/d/yyyy", null)},
            new IncomeRecord() {Id = 4, Sum = 200, Date = DateTime.ParseExact("7/7/2022", "M/d/yyyy", null)},
            new IncomeRecord() {Id = 5, Sum = 500, Date = DateTime.ParseExact("7/7/2022", "M/d/yyyy", null)},
        };

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
            try
            {
                var added = _context.IncomeCategories.Add(new IncomeCategory
                {
                    Name = "Category1"
                });
                await _context.SaveChangesAsync(ct);

                return Ok(added.Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("get/{id:int}")]
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
        [Route("update/{id:int}")]
        public IActionResult UpdateIncome(int id)
        {
            var foundRecord = _records.SingleOrDefault(r => r.Id == id);
            if (foundRecord == null)
            {
                return NotFound("No record with such id");
            }

            return Ok("Update was successful");

        }

        [HttpDelete]
        [Route("delete/{id:int}")]
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