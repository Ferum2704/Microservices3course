using IncomeService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IncomeService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        List<IncomeCategory> categories = new List<IncomeCategory>()
        {
            new IncomeCategory(){Id = 1, Name ="Job salary"},
            new IncomeCategory(){Id= 2, Name = "Scholarship"},
            new IncomeCategory(){Id = 3, Name = "Present"}
        };
        List<IncomeRecord> records = new List<IncomeRecord>()
        {
            new IncomeRecord(){Id = 1, Sum = 200, Date = DateTime.ParseExact("4/1/2022", "M/d/yyyy", null)},
            new IncomeRecord(){Id = 2, Sum = 1000, Date = DateTime.ParseExact("4/29/2022", "M/d/yyyy", null)},
            new IncomeRecord(){Id = 3, Sum = 150, Date = DateTime.ParseExact("5/18/2022", "M/d/yyyy", null)},
            new IncomeRecord(){Id = 4, Sum = 200, Date = DateTime.ParseExact("7/7/2022", "M/d/yyyy", null)},
            new IncomeRecord(){Id = 5, Sum = 500, Date = DateTime.ParseExact("7/7/2022", "M/d/yyyy", null)},
        };
        [HttpGet]
        public IActionResult GetIncomes()
        {
            return Ok(records);
        }
        [HttpGet]
        public IActionResult GetIncomeById(int? id)
        {
            IncomeRecord? foundRecord = records.Where(r => r.Id == id).SingleOrDefault();
            if (foundRecord != null)
            {
                return Ok(foundRecord);
            }
            return NotFound("No record with such id");
        }
        [HttpPut]
        public IActionResult UpdateIncome(IncomeRecord incomeRecord)
        {
            IncomeRecord? foundRecord = records.Where(r => r.Id == incomeRecord.Id).SingleOrDefault();
            if (foundRecord != null)
            {
                foundRecord = incomeRecord;
                return Ok("Update was successful");
            }
            return NotFound("No record with such id");
        }
        [HttpDelete]
        public IActionResult DeleteIncome(int? id)
        {
            IncomeRecord? foundRecord = records.Where(r => r.Id == id).SingleOrDefault();
            if (foundRecord != null)
            {
                if (records.Remove(foundRecord))
                {
                    return Ok("Delete was successful");
                }
                return StatusCode(500, "Something went wrong");
            }
            return NotFound("No record with such id");
        }
    }
}
