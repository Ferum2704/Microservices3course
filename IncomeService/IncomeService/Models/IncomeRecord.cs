namespace IncomeService.Models
{
    public class IncomeRecord
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
    }
}
