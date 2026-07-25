using System.Net;
using System.Text;

public class TrxHtmlReportGenerator
{
    public void Generate(TestRunResult result, string file)
    {
        var html = new StringBuilder();


        html.Append($$"""
<!DOCTYPE html>
<html>

<head>

<meta charset="utf-8">

<title>Test Report</title>


<link 
href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
rel="stylesheet">


<style>

body{
    padding:30px;
    background:#f8f9fa;
}


.card-number{
    font-size:35px;
    font-weight:bold;
}


.test{
    padding:15px;
    margin-bottom:10px;
    border-radius:8px;
}


.pass{
    background:#d1e7dd;
    border-left:5px solid #198754;
}


.fail{
    background:#f8d7da;
    border-left:5px solid #dc3545;
}


.test-name{
    font-size:18px;
}


pre{
    white-space:pre-wrap;
    background:#212529;
    color:white;
    padding:15px;
    border-radius:5px;
}


</style>


</head>


<body>


<div class="container">


<h1 class="mb-4">
🧪 Test Report
</h1>


<div class="row">


<div class="col-md-3">

<div class="card text-center">

<div class="card-body">

<div>Total</div>

<div class="card-number">
{{result.Total}}
</div>

</div>

</div>

</div>



<div class="col-md-3">

<div class="card text-center">

<div class="card-body">

<div class="text-success">
Passed
</div>

<div class="card-number text-success">
{{result.Passed}}
</div>

</div>

</div>

</div>




<div class="col-md-3">

<div class="card text-center">

<div class="card-body">

<div class="text-danger">
Failed
</div>

<div class="card-number text-danger">
{{result.Failed}}
</div>

</div>

</div>

</div>



<div class="col-md-3">

<div class="card text-center">

<div class="card-body">

<div>
Duration
</div>

<div class="card-number">
{{(result.Finish - result.Start).TotalSeconds:F2}}s
</div>

</div>

</div>

</div>


</div>


<h3 class="mt-5">
Tests
</h3>

""");



        var groups =
            result.Tests
            .GroupBy(x => x.ClassName);



        foreach (var group in groups)
        {

            html.Append($$"""

<div class="card mt-4">


<div class="card-header bg-dark text-white">

📁 {{group.Key}}

</div>


<div class="card-body">


""");



            foreach (var test in group)
            {

                bool passed =
                    test.Outcome.Equals(
                        "Passed",
                        StringComparison.OrdinalIgnoreCase);



                string css =
                    passed
                    ? "pass"
                    : "fail";


                string icon =
                    passed
                    ? "✅"
                    : "❌";


                html.Append($$"""

<div class="test {{css}}">


<div class="test-name">

{{icon}}

<b>
{{WebUtility.HtmlEncode(test.TestName)}}
</b>

</div>


<div>

⏱ 
{{test.Duration.TotalMilliseconds:F0}} ms

</div>


<span class="badge 
{{(passed ? "bg-success" : "bg-danger")}}">
{{test.Outcome}}
</span>



""");



                if (!passed)
                {

                    html.Append($$"""

<div class="alert alert-danger mt-3">


<h5>
❌ Reason
</h5>


<pre>
{{WebUtility.HtmlEncode(
    test.ErrorMessage
    ?? "No error message"
)}}
</pre>



<details>


<summary class="btn btn-outline-danger">

Stack Trace

</summary>



<pre class="mt-3">
{{WebUtility.HtmlEncode(
    test.StackTrace
    ?? "No stack trace"
)}}
</pre>


</details>


</div>

""");

                }



                html.Append("""

</div>

""");

            }



            html.Append("""

</div>

</div>

""");

        }



        html.Append("""

</div>


</body>

</html>

""");



        File.WriteAllText(
            file,
            html.ToString(),
            Encoding.UTF8
        );
    }
}