public class TestRunResult
{
    public DateTime Start { get; set; }

    public DateTime Finish { get; set; }

    public int Total { get; set; }

    public int Passed { get; set; }

    public int Failed { get; set; }

    public List<TestResultItem> Tests { get; set; } = new();
}
