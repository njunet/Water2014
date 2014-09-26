<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Monthly_Average_Flow.aspx.cs" Inherits="Water125.Monthly_Average_Flow" %>

<%--Highcharts--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>

<body>    
    <div id="container" style="min-width:800px;height:400px;"></div>

    <form id="form1" runat="server">
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

        function Show_Charts(stationStr, yearStr) {

            //  调用数据
            //  这里调用了一个有输入参数的webservice,前两个为输入参数，rlt为返回值
            Water125.WebService.AverageFlow_Month(stationStr, yearStr, function (rlt) {
                //在这里对返回的rlt进行处理
                //比如直接把结果写在页面上  
                //document.write(rlt);
                //或将字符串打散处理
                if (rlt == "null")
                    alert("对应时段无数据");
                var DischargeAmount = rlt.split("#");
                //alert(DischargeAmount[0]);//弹出窗口
                //document.write(DischargeAmount[1]);

                //flow
                var flowAmount = DischargeAmount[1].split(";");
                var count = flowAmount.length;
                //document.write(count);
                //document.write(flowAmount);
                var dataArray = new Array();
                for (i = 0; i < count - 1; i++) {
                    var flowArray = flowAmount[i + 1].split(",");
                    var flowtime = flowArray[0].split("/");
                    dataArray[i] = new Array();
                    dataArray[i][0] = Date.UTC(parseInt(flowtime[0]), parseInt(flowtime[1]) - 1);
                    dataArray[i][1] = parseFloat(flowArray[1]);
                }
                //document.write(dataArray);


                // 画图
                $(function () {
                    $('#container').highcharts({
                        chart: {
                            type: 'spline'
                        },
                        title: {
                            text: 'Monthly Average Flow'
                        },
                        subtitle: {
                            text: 'Source:HIS_MEASURAND_DischargeAmount_Month'
                        },
                        xAxis: {
                            type: 'datetime',
                            dateTimeLabelFormats: { // don't display the dummy year
                                month: '%e. %b',
                                year: '%b'
                            }
                        },
                        yAxis: {
                            title: {
                                text: 'Average Flow(t)'
                            },
                            min: 0
                        },
                        tooltip: {
                            formatter: function () {
                                return '<b>' + this.series.name + '</b><br>' +
                           Highcharts.dateFormat('%e. %b', this.x) + ': ' + this.y + ' t';
                            }
                        },
                        series: [{
                            name: 'flow',
                            // Define the data points. All series have a dummy year of 1970/71 in order
                            // to be compared on the same x axis. Note
                            // that in JavaScript, months start at 0 for January, 1 for February etc.
                            data: dataArray
                        }]
                    });
                }); //highcharts结束
            }, //function结束
        function () {
            //当调用失败时执行下面的函数
            alert('无数据！');
        }); //webservice结束

        } //show_charts结束

        //页面一载入就执行的程序段
        $(function () {
            //Show_Charts("陈东港","2014","7");
        });  //$function () 结束


        function show() {
            var stationvar = document.getElementById("stationID").options[document.getElementById("stationID").selectedIndex].value;
            var yearvar = document.getElementById("yearID").options[document.getElementById("yearID").selectedIndex].value;
            Show_Charts(stationvar, yearvar);
        } 
       
</script>
选择站点：
<select id="stationID" name="station" onchange="show()"> 

<option value="陈东港" >陈东港</option> 
<option value="321国道桥" >321国道桥</option> 
<option value="漕桥">漕桥</option>
<option value="裴家" >裴家</option> 
<option value="黄埝桥">黄埝桥</option> 
<option value="官渎港" >官渎港</option>
<option value="洪巷桥" >洪巷桥</option> 
<option value="社渎港">社渎港</option>
<option value="殷村港" >殷村港</option> 
<option value="梁溪河桥">梁溪河桥</option> 
<option value="百渎港" >百渎港</option>
<option value="大港桥" >大港桥</option> 
<option value="乌溪港桥">乌溪港桥</option>
<option value="小溪港">小溪港</option> 
<option value="直湖港" >直湖港</option> 
<option value="大浦港" >大浦港</option>  
<option value="武进港">武进港</option>
</select> 


选择年份：
<select id="yearID" name="year" onchange="show()"> 

 
<option value="2013">2013</option> 
<option value="2014">2014</option> 
<option value="2015">2015</option>
</select> 

    </form>
</body>
</html>
