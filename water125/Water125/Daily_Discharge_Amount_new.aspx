<%@ Page Title="" Language="C#" MasterPageFile="~/IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="Daily_Discharge_Amount_new.aspx.cs" Inherits="Water125.Daily_Discharge_Amount_new" %>
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

        function Show_Charts(stationStr, yearStr, monthStr) {

            //  调用数据
            //  这里调用了一个有输入参数的webservice,前两个为输入参数，rlt为返回值
            Water125.WebService.DischargeAmount_Day(stationStr, yearStr, monthStr, function (rlt) {
                //在这里对返回的rlt进行处理
                //比如直接把结果写在页面上  // document.write(rlt);
                //或将字符串打散处理
                if (rlt == "null")
                    alert("对应时段无数据");
                var DischargeAmount = rlt.split("#");
                //alert(DischargeAmount[0]);//弹出窗口
                //document.write(DischargeAmount[1]);

                //CoDMn
                var CoDMnAmount = DischargeAmount[1].split(";");
                var count1 = CoDMnAmount.length;
                //document.write(count1);
                //document.write(CoDMnAmount);
                var dataArray1 = new Array();
                for (i = 0; i < count1 - 1; i++) {
                    var CoDMnArray = CoDMnAmount[i + 1].split(",");
                    var CoDMndate = CoDMnArray[0].split("/");
                    dataArray1[i] = new Array();
                    dataArray1[i][0] = Date.UTC(parseInt(CoDMndate[0]), parseInt(CoDMndate[1]) - 1, parseInt(CoDMndate[2]));
                    dataArray1[i][1] = parseFloat(CoDMnArray[1]);
                }

                //NH3_N
                var NH3_NAmount = DischargeAmount[2].split(";");
                var count2 = NH3_NAmount.length;
                // document.write(NH3_NAmount[1]);
                var dataArray2 = new Array();
                var NH3_Ndate = new Array();
                for (i = 0; i < count2 - 1; i++) {
                    var NH3_NArray = NH3_NAmount[i + 1].split(",");
                    var NH3_Ndate = NH3_NArray[0].split("/");
                    dataArray2[i] = new Array();
                    dataArray2[i][0] = Date.UTC(parseInt(NH3_Ndate[0]), parseInt(NH3_Ndate[1]) - 1, parseInt(NH3_Ndate[2]));
                    dataArray2[i][1] = parseFloat(NH3_NArray[1]);
                }
                //document.write(NH3_Ndate[2]);

                //TP
                var TPAmount = DischargeAmount[3].split(";");
                var count3 = TPAmount.length;
                // document.write(TPAmount[1]);
                var dataArray3 = new Array();
                var TPdate = new Array();
                for (i = 0; i < count3 - 1; i++) {
                    var TPArray = TPAmount[i + 1].split(",");
                    var TPdate = TPArray[0].split("/");
                    dataArray3[i] = new Array();
                    dataArray3[i][0] = Date.UTC(parseInt(TPdate[0]), parseInt(TPdate[1] - 1), parseInt(TPdate[2]));
                    dataArray3[i][1] = parseFloat(TPArray[1]);
                }
                //document.write(TPdate[2]);

                //TN
                var TNAmount = DischargeAmount[4].split(";");
                var count4 = TNAmount.length;
                // document.write(TNAmount[1]);
                var dataArray4 = new Array();
                var TNdate = new Array();
                for (i = 0; i < count4 - 1; i++) {
                    var TNArray = TNAmount[i + 1].split(",");
                    var TNdate = TNArray[0].split("/");
                    dataArray4[i] = new Array();
                    dataArray4[i][0] = Date.UTC(parseInt(TNdate[0]), parseInt(TNdate[1] - 1), parseInt(TNdate[2]));
                    dataArray4[i][1] = parseFloat(TNArray[1]);
                }

                // 画图
                $(function () {
                    $('#container').highcharts({
                        chart: {
                            type: 'spline'
                        },
                        title: {
                            text: '日排放量'
                        },
//                        subtitle: {
//                            text: 'Source:HIS_MEASURAND_DischargeAmount_Day'
//                        },
                        xAxis: {
                            type: 'datetime',
                            dateTimeLabelFormats: { // don't display the dummy year
                                month: '%e. %b',
                                year: '%b'
                            }
                        },
                        yAxis: {
                            title: {
                                text: '排放量(t)'
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
                    });
                }); //highcharts结束

            }, //function结束

        function () {
            //当调用失败时执行下面的函数
            alert('无数据！');
        });  //webservice结束

        } //show_charts结束

        //页面一载入就执行的程序段
        $(function () {
            Show_Charts("陈东港","2014","1");
        });  //$function () 结束


        function show() {
            var stationvar = document.getElementById("stationID").options[document.getElementById("stationID").selectedIndex].value;
            var yearvar = document.getElementById("yearID").options[document.getElementById("yearID").selectedIndex].value;
            var monthvar = document.getElementById("monthID").options[document.getElementById("monthID").selectedIndex].value;
            Show_Charts(stationvar, yearvar, monthvar);
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


<option value="2014">2014</option>
<option value="2015">2015</option>
 
</select> 


选择月份：
<select id="monthID" name="month" onchange="show()"> 

<option value="01">01</option> 
<option value="02">02</option>
<option value="03">03</option> 
<option value="04">04</option> 
<option value="05">05</option>
<option value="06">06</option> 
<option value="07">07</option>
<option value="08">08</option> 
<option value="09">09</option> 
<option value="10">10</option>
<option value="11">11</option> 
<option value="12">12</option>
</select> 

<asp:Button ID="buttonToTable" runat="server" OnClick="buttonToTableClick" Text="日排放量表" />   
</asp:Content>
 