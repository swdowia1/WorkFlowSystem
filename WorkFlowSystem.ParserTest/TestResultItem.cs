public class TestResultItem
{
    public string ClassName { get; set; } = "";

    public string TestName { get; set; } = "";

    public string Outcome { get; set; } = "";

    public TimeSpan Duration { get; set; }

    public string? ErrorMessage { get; set; }
    public string? StackTrace { get; set; }
}
