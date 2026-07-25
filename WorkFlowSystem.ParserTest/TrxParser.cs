using System.Xml.Linq;
public class TrxParser
{

    private const string Namespace =
        "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";


    public TestRunResult Parse(string file)
    {
        var doc = XDocument.Load(file);

        XNamespace ns = Namespace;


        var result = new TestRunResult();


        // czas wykonania
        var times = doc.Root?
            .Element(ns + "Times");


        result.Start =
            DateTime.Parse(
                times?.Attribute("start")?.Value!
            );


        result.Finish =
            DateTime.Parse(
                times?.Attribute("finish")?.Value!
            );



        // statystyki
        var counters = doc.Root?
            .Element(ns + "ResultSummary")
            ?.Element(ns + "Counters");


        result.Total =
            int.Parse(
                counters?.Attribute("total")?.Value ?? "0"
            );


        result.Passed =
            int.Parse(
                counters?.Attribute("passed")?.Value ?? "0"
            );


        result.Failed =
            int.Parse(
                counters?.Attribute("failed")?.Value ?? "0"
            );



        // mapowanie testId -> klasa
        var classes =
            doc.Descendants(ns + "UnitTest")
            .ToDictionary(
                x => x.Attribute("id")!.Value,

                x =>
                {
                    var method =
                        x.Element(ns + "TestMethod");

                    return new
                    {
                        Class =
                            method?.Attribute("className")?.Value ?? "",

                        Method =
                            method?.Attribute("name")?.Value ?? ""
                    };
                });



        // wyniki

        foreach (var item in doc.Descendants(ns + "UnitTestResult"))
        {

            var id =
                item.Attribute("testId")?.Value;


            var info =
                classes.ContainsKey(id!)
                ? classes[id!]
                : null;
            var errorInfo =
    item
    .Element(ns + "Output")
    ?.Element(ns + "ErrorInfo");

            result.Tests.Add(new TestResultItem
            {

                ClassName = info?.Class ?? "",

                TestName = info?.Method ?? "",

                Outcome =
                    item.Attribute("outcome")?.Value ?? "",


                Duration =
                    TimeSpan.Parse(
                        item.Attribute("duration")?.Value
                        ?? "00:00:00"
                    ),
                    ErrorMessage =
        errorInfo?
        .Element(ns + "Message")
        ?.Value,


                StackTrace =
        errorInfo?
        .Element(ns + "StackTrace")
        ?.Value

            });
        }


        return result;
    }
}
