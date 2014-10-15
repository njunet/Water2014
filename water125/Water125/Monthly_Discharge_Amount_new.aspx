﻿<%@ Page Title="" Language="C#" MasterPageFile="~/IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="Monthly_Discharge_Amount_new.aspx.cs" Inherits="Water125.Monthly_Discharge_Amount_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="info">
选择站点：
<select id="stationID" name="station" onchange="show()" > 

<option value="陈东港" >陈东港</option> 
<option value="312国道桥" >312国道桥</option> 
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
</div>

<div id="container" style="min-width: 100%; height: 650px; margin: 0 auto"></div>

 <%--引入webservice,声明--%>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
    <asp:ServiceReference Path="~/WebService.asmx"/>
    </Services>
    </asp:ScriptManager>
  
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/highcharts.js"></script>
    <script type="text/javascript" src="js/exporting.js"></script>
    <script type="text/javascript" src="js/date.js"></script>
    <script language = "javascript" type="text/javascript">

        function Show_Charts(stationStr, yearStr) {

            //  调用数据
            //  这里调用了一个有输入参数的webservice,前两个为输入参数，rlt为返回值
            Water125.WebService.DischargeAmount_Month_new(stationStr, yearStr, function (rlt) {
                //在这里对返回的rlt进行处理
                //比如直接把结果写在页面上  
                //document.write(rlt);
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
                    var CoDMntime = CoDMnArray[0].split("/");
                    dataArray1[i] = new Array();
                    dataArray1[i][0] = Date.UTC(parseInt(CoDMntime[0]), parseInt(CoDMntime[1]) - 1);
                    dataArray1[i][1] = parseFloat(CoDMnArray[1]);
                }
                //document.write(dataArray1);

                //NH3_N
                var NH3_NAmount = DischargeAmount[2].split(";");
                var count2 = NH3_NAmount.length;
                // document.write(NH3_NAmount[1]);
                var dataArray2 = new Array();
                for (i = 0; i < count2 - 1; i++) {
                    var NH3_NArray = NH3_NAmount[i + 1].split(",");
                    var NH3_Ntime = NH3_NArray[0].split("/");
                    dataArray2[i] = new Array();
                    dataArray2[i][0] = Date.UTC(parseInt(NH3_Ntime[0]), parseInt(NH3_Ntime[1]) - 1);
                    dataArray2[i][1] = parseFloat(NH3_NArray[1]);
                }
                //document.write(NH3_Ntime[1]);

                //TP
                var TPAmount = DischargeAmount[3].split(";");
                var count3 = TPAmount.length;
                // document.write(TPAmount[1]);
                var dataArray3 = new Array();
                for (i = 0; i < count3 - 1; i++) {
                    var TPArray = TPAmount[i + 1].split(",");
                    var TPtime = TPArray[0].split("/");
                    dataArray3[i] = new Array();
                    dataArray3[i][0] = Date.UTC(parseInt(TPtime[0]), parseInt(TPtime[1] - 1));
                    dataArray3[i][1] = parseFloat(TPArray[1]);
                }

                //TN
                var TNAmount = DischargeAmount[4].split(";");
                var count4 = TNAmount.length;
                // document.write(TNAmount[1]);
                var dataArray4 = new Array();
                for (i = 0; i < count4 - 1; i++) {
                    var TNArray = TNAmount[i + 1].split(",");
                    var TNtime = TNArray[0].split("/");
                    dataArray4[i] = new Array();
                    dataArray4[i][0] = Date.UTC(parseInt(TNtime[0]), parseInt(TNtime[1] - 1));
                    dataArray4[i][1] = parseFloat(TNArray[1]);
                }

                // 画图
                $(function () {
                    $('#container').highcharts({
//                        chart: {
//                            type: 'spline'
//                        },
                        title: {
                            text: '月排放量'
                        },
                        //                        subtitle: {
                        //                            text: 'Source:HIS_MEASURAND_DischargeAmount_Month'
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
//                            plotLines: [{
//                                value: 0,
//                                width: 1,
//                                color: '#808080'
//                            }],
                            min: 0
                        },
                        tooltip: {
                            formatter: function () {
                                return '<b>' + this.series.name + '</b><br>' +
                           Highcharts.dateFormat('%e. %b', this.x) + ': ' + this.y + ' t';
                            }
                        },
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            verticalAlign: 'middle',
                            borderWidth: 0
                        },
                        series: [{
                            name: 'CoDMn',
                            // Define the data points. All series have a dummy year of 1970/71 in order
                            // to be compared on the same x axis. Note
                            // that in JavaScript, months start at 0 for January, 1 for February etc.
                            data: dataArray1,
                            color: '#B3EE3A'
                        }, {
                            name: 'NH3_N',
                            data: dataArray2,
                            color: '#FF9A00'
                        }, {
                            name: 'TP',
                            data: dataArray3,
                            color: '#525252'
                        }, {
                            name: 'TN',
                            data: dataArray4,
                            color: '#63B8FF'
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
            Show_Charts("陈东港", "2014");
        });  //$function () 结束


        function show() {
            var stationvar = document.getElementById("stationID").options[document.getElementById("stationID").selectedIndex].value;
            var yearvar = document.getElementById("yearID").options[document.getElementById("yearID").selectedIndex].value;
            Show_Charts(stationvar, yearvar);
        } 
       
</script>

</asp:Content>
