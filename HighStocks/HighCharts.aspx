<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HighCharts.aspx.cs" Inherits="HighStocks.HighCharts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Content/Plugin/Highstock/highstock.js"></script>
    <script src="Content/Plugin/Highstock/exporting.js"></script>

<div id="container" style="height: 400px; min-width: 310px"></div>
    <script src="data.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "HighCharts.aspx/GetReportData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });

    </script>

    <script>
    
    // Create the chart
    //Highcharts.stockChart('container', {


    //    rangeSelector: {
    //        selected: 5
    //    },

    //    title: {
    //        text: 'AAPL Stock Price'
    //    },        
    //    series: [{
    //        name: 'AAPL Stock Price',
    //        data: data1,
    //        type: 'area',
    //        threshold: null,
    //        tooltip: {
    //            valueDecimals: 2
    //        },
    //        fillColor: {
    //            linearGradient: {
    //                x1: 0,
    //                y1: 0,
    //                x2: 0,
    //                y2: 1
    //            },
    //            stops: [
    //                [0, Highcharts.getOptions().colors[0]],
    //                [1, Highcharts.Color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
    //            ]
    //        }
    //    },
    //    {
    //        name: 'AAPL Stock Price',
    //        data: data2,
    //        type: 'area',
    //        threshold: null,
    //        tooltip: {
    //            valueDecimals: 2
    //        },
    //        fillColor: {
    //            linearGradient: {
    //                x1: 0,
    //                y1: 0,
    //                x2: 1,
    //                y2: 0
    //            },
    //            stops: [
    ////                [0, Highcharts.getOptions().colors[1]],
    //                [1, Highcharts.Color(Highcharts.getOptions().colors[1]).setOpacity(0).get('rgba')]
    //            ]
    //        }
    //    }]
    //});


        function onSuccess(response) {
            var result = response.d;
                        
            var rpt1 = [];
            var rpt2 = [];
            
            $.each(result.Report1, function (i) {
                var t1 = [];
                t1.push(parseInt((result.Report1[i].ReportDate).substring(6)));
                t1.push(result.Report1[i].ReportAmount);
                rpt1.push(t1);;
            });

            $.each(result.Report2, function (i) {
                var t2 = [];
                t2.push(parseInt((result.Report2[i].ReportDate).substring(6)));
                t2.push(result.Report2[i].ReportAmount);
                rpt2.push(t2);
            });
            
            
          //  $('#container').highcharts({
            Highcharts.stockChart('container', {

                rangeSelector: {
                    selected: 5
                },
                title: {
                    text: 'Entrate/Uscite'
                },
                subtitle: {
                },
                xAxis: {
                    type: 'datetime',
                    title: {
                        text: null
                    }
                },
                yAxis: {
                    title: {
                        text: 'Euro(€)'
                    }
                },
                legend: {
                    enabled: true
                },
                rangeSelector:{
                    enabled:false
                },
                navigator: {
                    enabled: false
                },
                scrollbar: {
                    enabled: false
                },
                series: [{
                        name: 'AAPL Stock Price',
                        data: rpt1,
                        type: 'area',
                        fillColor: {
                            linearGradient: {
                                x1: 0,
                                y1: 0,
                                x2: 0,
                                y2: 1
                            },
                            stops: [
                                [0, Highcharts.getOptions().colors[0]],
                                [1, Highcharts.Color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                            ]
                        }
                    },
                    {
                        name: 'AAPL Stock Price',
                        data: rpt2,
                        type: 'area',
                        fillColor: {
                            linearGradient: {
                                x1: 0,
                                y1: 1,
                                x2: 0,
                                y2: 0
                            },
                            stops: [
                                [0, Highcharts.getOptions().colors[1]],
                                [1, Highcharts.Color(Highcharts.getOptions().colors[1]).setOpacity(0).get('rgba')]
                            ]
                        }
                    }
                ]
            });
        
        };

</script>

</asp:Content>
