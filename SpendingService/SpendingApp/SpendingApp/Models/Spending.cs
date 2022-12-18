namespace SpendingApp.Models;

public class Spending
{
    public int Id { get; set; }
    public Currency Currency { get; set; }
    public int Value { get; set; }
    public string Item { get; set; }
}