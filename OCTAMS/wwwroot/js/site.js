// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function timeSeries() {
    console.log(document.getElementById("timeSeriesChg").value)
    $.ajax({
        url: "https://disease.sh/v3/covid-19/historical/in?lastdays=" + document.getElementById("timeSeriesChg").value, success: function (result) {
            console.log("222", Object.keys(result.timeline.cases));
            const label = Object.keys(result.timeline.cases);
            var casesData = {
                x: label,
                y: Object.values(result.timeline.cases),
                type: 'scatter',
                mode: 'lines',
                name: 'Cases',
                line: {
                    color: 'yellow',
                    width: 3
                }
            };

            var dethsData = {
                x: label,
                y: Object.values(result.timeline.deaths),
                type: 'scatter',
                mode: 'lines',
                name: 'Deaths',
                line: {
                    color: 'rgb(219, 64, 82)',
                    width: 3
                }
            };
            var recoveredData = {
                x: label,
                y: Object.values(result.timeline.recovered),
                type: 'scatter',
                mode: 'lines',
                name: 'Recovered',
                line: {
                    color: 'green',
                    width: 3
                }
            };

            var cases = [casesData, dethsData, recoveredData];

            Plotly.newPlot('casesPlot', cases);
        }
    });
}

$(document).ready(function () {
    
        $.ajax({
            url: "https://disease.sh/v3/covid-19/countries/in", success: function (result) {
                //console.log(result)
                document.getElementById("totalCase").innerHTML = result.cases;
                document.getElementById("active").innerHTML = result.active
                document.getElementById("recovered").innerHTML = result.recovered
                document.getElementById("deaths").innerHTML = result.deaths
                document.getElementById("tcases").innerHTML = result.todayCases
                document.getElementById("tdeaths").innerHTML = result.todayDeaths
                document.getElementById("tests").innerHTML = result.tests
            }
        });
        $.ajax({
            url: "https://disease.sh/v3/covid-19/vaccine/coverage/countries/in?lastdays=1&fullData=false", success: function (result) {
                document.getElementById("vaccine").innerHTML = Object.values(result.timeline)[0];
            }
        });
    timeSeries();
        
    
});

$(".alert").fadeTo(2000, 500).slideUp(500, function () {
    $(".alert").slideUp(500);
});
let table = null;
$(document).ready(function () {
   table= $('#exampleTable').DataTable({
        paging: true,
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]

   });

    
});

function user() {
    console.log(table.rows().data())
}
$('#exampleTable tbody').on('click', 'tr', function () {
    var rowData = table.row(this).data();
    console.log(rowData);
    document.getElementById("title").innerHTML = rowData[0];
    document.getElementById("data").innerHTML = rowData[1];
});

$(document).ready(function () {
    $('#exampleTable1').DataTable({
        paging: true,
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]

    });
});
$(document).ready(function () {
    $('#exampleTable2').DataTable({
        paging: true,
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]

    });
});

$(document).ready(function () {
    $('#exampleTable3').DataTable({
        paging: true,
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]

    });
});
$(document).ready(function () {
    $('#exampleTable4').DataTable({
        paging: true,
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]

    });
});


function editStory(id,story) {
    console.log("id - ", id);
    document.getElementById(id).disabled = false
   
}

function userChartPloat() {
    console.log(document.getElementById("uquestion").innerHTML, "------")

}

var data = [{
    values: [document.getElementById("article").innerHTML, document.getElementById("story").innerHTML,
        document.getElementById("question").innerHTML,
        document.getElementById("user").innerHTML,
        document.getElementById("volunteer").innerHTML
        ],
    labels: ['Articles', 'Stories', 'Questions', "Users","Volunteers"],
    type: 'pie'
}];

var layout = {
    height: 400,
    width: "100%"
};

Plotly.newPlot('tester', data, layout);


$(document).ready(function () {
    //var userData = [{
    //    values: [document.getElementById("uarticle").innerHTML, document.getElementById("ustory").innerHTML,
    //    document.getElementById("uquestion").innerHTML
    //    ],
    //    labels: ['Articles', 'Stories', 'Questions'],
    //    type: 'pie'
    //}];

    //var layoutx = {
    //    height: 400,
    //    width: "100%"
    //};

    //Plotly.newPlot('userChart', userData, layout);

});