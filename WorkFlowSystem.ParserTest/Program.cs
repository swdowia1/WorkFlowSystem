var parser = new TrxParser();

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