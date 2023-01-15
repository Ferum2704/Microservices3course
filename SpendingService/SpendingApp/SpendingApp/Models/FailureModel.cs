namespace SpendingApp.Models;

public class FailureModel
{
    public int NumberOfRetries { get; set; }
    public bool IsRequestCancelled { get; set; }
    public int NumberOfRetriesForBrokenCircuit { get; set; }
    public bool IsCircuitBroken { get; set; }
}