using System.Diagnostics;

var parser = new TrxParser();
//dotnet test --no-build --logger "trx;LogFileName=results.trx"
var report =
    parser.Parse(
       @"C:\dysk_d\wywal\testy\results.trx"
    );


Console.WriteLine(
    $"Testy: {report.Total}"
);


Console.WriteLine(
    $"OK: {report.Passed}"
);



foreach (var test in report.Tests)
{
    Console.WriteLine(
       $"{test.Outcome} {test.ClassName}.{test.TestName} {test.Duration}"
    );
}
var generator =
    new TrxHtmlReportGenerator();


generator.Generate(
    report,
    @"report.html"
);

Process.Start(new ProcessStartInfo
{
    FileName = "report.html",
    UseShellExecute = true
});