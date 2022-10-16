namespace IncomeService.Models
{
    public class IncomeRecord
    {
        public int Id { get; set; }
        public IncomeCategory Category { get; set; } = new IncomeCategory();
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
    }
}
