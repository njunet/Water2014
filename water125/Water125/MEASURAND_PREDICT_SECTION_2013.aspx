<%@ Page Title="" Language="C#" MasterPageFile="~/IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="MEASURAND_PREDICT_SECTION_2013.aspx.cs" Inherits="Water125.MEASURAND_PREDICT_SECTION_2013" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="container" style="min-width: 1400px; height: 600px; margin: 0 auto"></div>

 <%--引入webservice,声明--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
    <asp:ServiceReference Path="~/WebService.asmx"/>
    </Services>
    </asp:ScriptManager>
  
    <script type="text/javascript" src="http://cdn.hcharts.cn/jquery/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="http://cdn.hcharts.cn/highcharts/4.0.1/highcharts.js"></script>
    <script type="text/javascript" src="js/exporting.js"></script>
    <script type="text/javascript" src="js/date.js"></script>
    <script language = "javascript" type="text/javascript">

        function Show_Charts(startStr, endStr, iiStr) {
            //            alert("test1");
            //  调用数据
            //  这里调用了一个有输入参数的webservice,前3个为输入参数，rlt为返回值
            Water125.WebService.Predict2013(startStr, endStr, iiStr, function (rlt) {
                //在这里对返回的rlt进行处理
                //比如直接把结果写在页面上 
                //            document.write(rlt);
                //或将字符串打散处理
                if (rlt == "null")
                    alert("对应时段无数据");

                var Predict = rlt.split("#");
                //            document.write(Predict[1]);

                //CoDMn
                var CoDMnAmount = Predict[1].split(";");
                var count1 = CoDMnAmount.length;
                //document.write(count1);
                //document.write(CoDMnAmount);
                var dataArray1 = new Array();
                for (i = 0; i < count1 - 1; i++) {
                    var CoDMnArray = CoDMnAmount[i + 1].split(",");
                    dataArray1[i] = new Array();
                    dataArray1[i][0] = parseFloat(CoDMnArray[0]);
                    dataArray1[i][1] = parseFloat(CoDMnArray[1]);
                }
                //            document.write(dataArray1);

                //NH3_N
                var NH3_NAmount = Predict[2].split(";");
                var count2 = NH3_NAmount.length;
                //document.write(count2);
                //document.write(NH3_NAmount);
                var dataArray2 = new Array();
                for (i = 0; i < count2 - 1; i++) {
                    var NH3_NArray = NH3_NAmount[i + 1].split(",");
                    dataArray2[i] = new Array();
                    dataArray2[i][0] = parseFloat(NH3_NArray[0]);
                    dataArray2[i][1] = parseFloat(NH3_NArray[1]);
                }
                //            document.write(dataArray2);

                //TP
                var TPAmount = Predict[3].split(";");
                var count3 = TPAmount.length;
                //document.write(count3);
                //document.write(TPAmount);
                var dataArray3 = new Array();
                for (i = 0; i < count3 - 1; i++) {
                    var TPArray = TPAmount[i + 1].split(",");
                    dataArray3[i] = new Array();
                    dataArray3[i][0] = parseFloat(TPArray[0]);
                    dataArray3[i][1] = parseFloat(TPArray[1]);
                }
                //            document.write(dataArray3);

                //TN
                var TNAmount = Predict[4].split(";");
                var count4 = TNAmount.length;
                //document.write(count4);
                //document.write(TNAmount);
                var dataArray4 = new Array();
                for (i = 0; i < count4 - 1; i++) {
                    var TNArray = TNAmount[i + 1].split(",");
                    dataArray4[i] = new Array();
                    dataArray4[i][0] = parseFloat(TNArray[0]);
                    dataArray4[i][1] = parseFloat(TNArray[1]);
                }
                //            document.write(dataArray4);

                $(function () {
                    $('#container').highcharts({
                        chart: {
                            type: 'spline'
                        },
                        title: {
                            text: '2013年排放量'
                        },
                        xAxis: {
                            //                            type: 'datetime',
                            //                            dateTimeLabelFormats: { // don't display the dummy year
                            //                                hour: '%H:%M'
                            //                            }
                            title: {
                                text: '小时（h）'
                            }
                        },
                        yAxis: {
                            title: {
                                text: '排放量(t)'
                            },
                            min: 0
                        },
                        //                        tooltip: {
                        //                            formatter: function () {
                        //                                return '<b>' + this.series.name + '</b><br>' +
                        //                           Highcharts.dateFormat('%H:%M', this.x) + ': ' + this.y + ' t';
                        //                            }
                        //                        },
                        series: [{
                            name: 'CoDMn',
                            // Define the data points. All series have a dummy year of 1970/71 in order
                            // to be compared on the same x axis. Note
                            // that in JavaScript, months start at 0 for January, 1 for February etc.
                            data: dataArray1
                        }, {
                            name: 'NH3_N',
                            data: dataArray2
                        }, {
                            name: 'TP',
                            data: dataArray3
                        }, {
                            name: 'TN',
                            data: dataArray4
                        }]
                    }); //highcharts结束
                }); //画图结束

            }, //function（rlt）结束

        function () {
            //当调用失败时执行下面的函数
            alert('无数据！');
        });    //webservice结束
        } //show_charts结束

        //页面一载入就执行的程序段
        $(function () {

            var iiId;
            var URL = document.location.toString();
            if (URL.lastIndexOf("?") != -1) {
                iiId = URL.substring(URL.lastIndexOf("?") + 1, URL.length);
                Show_Charts("1", "24", iiId);
            }
            else {
                Show_Charts("1", "24", "1");
            }

        });        //$function () 结束

        function show(startvar, endvar) {
            //var startvar = document.getElementById("startID").options[document.getElementById("startID").selectedIndex].value;
            //var endvar = document.getElementById("endID").options[document.getElementById("endID").selectedIndex].value;
            var iivar = document.getElementById("iiID").options[document.getElementById("iiID").selectedIndex].value;
            //        alert("test");
            Show_Charts(startvar, endvar, iivar);
        }

        function caculate_time() {
            //alert("test!");

            var startvar = document.getElementById("ContentPlaceHolder1_startID").value;
            var endvar = document.getElementById("ContentPlaceHolder1_endID").value;

            //        alert(document.getElementById("ContentPlaceHolder1_startID").value);
            //        alert(document.getElementById("ContentPlaceHolder1_endID").value);

            var date0 = new Date("2013/1/1")
            var date1 = new Date(startvar);
            var date2 = new Date(endvar);

            var startTime = date1.getTime() - date0.getTime();
            var endTime = date2.getTime() - date0.getTime();
            //        alert(startTime);
            var startHour = Math.floor(startTime / (1000 * 60 * 60));
            var endHour = Math.floor(endTime / (1000 * 60 * 60));

            //        alert(startHour);
            show(startHour, endHour);

        }  
</script>

<asp:Label ID="Label" runat="server">起始时间：</asp:Label>
<input id="startID" class="Wdate" runat="server" type="text" onclick="WdatePicker({startDate:'2013-01-01',dateFmt:'yyyy/M/d'})" /> 

<asp:Label ID="Label2" runat="server">终止时间：</asp:Label>
<input id="endID" class="Wdate" runat="server" type="text" onclick="WdatePicker({startDate:'2013-01-01',dateFmt:'yyyy/M/d'})" />

截面号：
<select id="iiID" name="II" onchange="caculate_time()"> 
<%--<select id="Select1" name="II" onchange="caculate_time()"> --%>
<option value="1">1</option> 
<option value="2">2</option>
<option value="3">3</option> 
<option value="4">4</option> 
<option value="5">5</option>
<option value="6">6</option> 
<option value="7">7</option>
<option value="8">8</option> 
<option value="9">9</option> 
<option value="10">10</option>
<option value="11">11</option> 
<option value="12">12</option>
<option value="13">13</option> 
<option value="14">14</option> 
<option value="15">15</option>
<option value="16">16</option> 
<option value="17">17</option>
</select> 

<%--<button onclick='caculate_time()' >快速搜索</button>--%>

</asp:Content>
