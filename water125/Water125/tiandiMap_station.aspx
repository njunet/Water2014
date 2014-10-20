<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tiandiMap_station.aspx.cs" Inherits="Water125.tiandiMap_station" %>
<!DOCTYPE html> 
<html> 
<head> 
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" /> 
<title>十二五水专项地图</title> 
<script language="javascript" src="http://api.tianditu.com/js/maps.js"></script> 
<script type="text/javascript" language="javascript">
    var map, zoom = 12, marker,markerTool,infoWindow;
    var listener = null;
    function onLoad() {
        //初始化地图对象 
        map = new TMap("mapDiv");
        //设置显示地图的中心点和级别 
        map.centerAndZoom(new TLngLat(119.958095, 31.468101), zoom);
        //允许鼠标双击放大地图 
        map.enableHandleMouseScroll();

        //创建标注工具对象 
        markerTool = new TMarkTool(map);
        //注册标注的mouseup事件 
        TEvent.addListener(markerTool, "mouseup", mouseup);

        //创建标注对象 
        marker1 = new TMarker(new TLngLat(119.9275,31.3225));
        //向上地图上添加标注 
        map.addOverLay(marker1);
        TEvent.addListener(marker1, "click", function () { onClick(119.9275, 31.3225, 175); })
        //TEvent.addListener(marker1, "mouseover", function () { onMouseOver(119.9275, 31.3225, 175); })


        marker2 = new TMarker(new TLngLat(120.41649, 31.45067));
        map.addOverLay(marker2);
        TEvent.addListener(marker2, "click", function () { onClick(120.41649, 31.45067, 183); })
        //TEvent.addListener(marker2, "mouseover", function () { onMouseOver(120.41649, 31.45067, 183); })

        marker3 = new TMarker(new TLngLat(119.9783, 31.51357));
        map.addOverLay(marker3);
        TEvent.addListener(marker3, "click", function () { onClick(119.9783, 31.51357, 187); })
        //TEvent.addListener(marker3, "mouseover", function () { onMouseOver(119.9783, 31.51357, 187); })

        marker4 = new TMarker(new TLngLat(119.99566, 31.49904));
        map.addOverLay(marker4);
        TEvent.addListener(marker4, "click", function () { onClick(119.99566, 31.49904, 188); })
        //TEvent.addListener(marker4, "mouseover", function () { onMouseOver(119.99566, 31.49904, 188); })

        marker5 = new TMarker(new TLngLat(120.0160,	31.5200));
        map.addOverLay(marker5);
        TEvent.addListener(marker5, "click", function () { onClick(120.0160, 31.5200, 212); })
        //TEvent.addListener(marker5, "mouseover", function () { onMouseOver(120.0160, 31.5200, 212); })

        marker6 = new TMarker(new TLngLat(119.93653, 31.33713));
        map.addOverLay(marker6);
        TEvent.addListener(marker6, "click", function () { onClick(119.93653, 31.33713, 224); })
        //TEvent.addListener(marker6, "mouseover", function () { onMouseOver(119.93653, 31.33713, 224); })

        marker7 = new TMarker(new TLngLat(119.92284, 31.33207));
        map.addOverLay(marker7);
        TEvent.addListener(marker7, "click", function () { onClick(119.92284, 31.33207, 225); })
        //TEvent.addListener(marker7, "mouseover", function () { onMouseOver(119.92284, 31.33207, 225); })

        marker8 = new TMarker(new TLngLat(119.9450,31.3556));
        map.addOverLay(marker8);
        TEvent.addListener(marker8, "click", function () { onClick(119.9450, 31.3556, 228); })
        //TEvent.addListener(marker8, "mouseover", function () { onMouseOver(119.9450, 31.3556, 228); })

        marker9 = new TMarker(new TLngLat(120.0081,31.4531));
        map.addOverLay(marker9);
        TEvent.addListener(marker9, "click", function () { onClick(120.0081, 31.4531, 230); })
        //TEvent.addListener(marker9, "mouseover", function () { onMouseOver(120.0081, 31.4531, 230); })

        marker10 = new TMarker(new TLngLat(120.22889, 31.54998));
        map.addOverLay(marker10);
        TEvent.addListener(marker10, "click", function () { onClick(120.22889, 31.54998, 232); })
        //TEvent.addListener(marker10, "mouseover", function () { onMouseOver(120.22889, 31.54998, 232); })

        marker11 = new TMarker(new TLngLat(120.0264,31.4919));
        map.addOverLay(marker11);
        TEvent.addListener(marker11, "click", function () { onClick(120.0264, 31.4919, 237); })
        //TEvent.addListener(marker11, "mouseover", function () { onMouseOver(120.0264, 31.4919, 237); })

        marker12 = new TMarker(new TLngLat(119.89721, 31.18964));
        map.addOverLay(marker12);
        TEvent.addListener(marker12, "click", function () { onClick(119.89721, 31.18964, 240); })
        // TEvent.addListener(marker12, "mouseover", function () { onMouseOver(119.89721, 31.18964, 240); })

        marker13 = new TMarker(new TLngLat(119.8839,31.2272));
        map.addOverLay(marker13);
        TEvent.addListener(marker13, "click", function () { onClick(119.8839, 31.2272, 241); })
        // TEvent.addListener(marker13, "mouseover", function () { onMouseOver(119.8839, 31.2272, 241); })

        marker14 = new TMarker(new TLngLat(120.3478,31.4656));
        map.addOverLay(marker14);
        TEvent.addListener(marker14, "click", function () { onClick(120.3478, 31.4656, 242); })
        //TEvent.addListener(marker14, "mouseover", function () { onMouseOver(120.3478, 31.4656, 242); })

        marker15 = new TMarker(new TLngLat(120.1222, 31.50901));
        map.addOverLay(marker15);
        TEvent.addListener(marker15, "click", function () { onClick(120.1222, 31.50901, 248); })
        //TEvent.addListener(marker15, "mouseover", function () { onMouseOver(120.1222, 31.50901, 248); })

        marker16 = new TMarker(new TLngLat(119.9236,31.3144));
        map.addOverLay(marker16);
        TEvent.addListener(marker16, "click", function () { onClick(119.9236, 31.3144, 250); })
        // TEvent.addListener(marker16, "mouseover", function () { onMouseOver(119.9236, 31.3144, 250); })

        marker17 = new TMarker(new TLngLat(120.11758, 31.5022));
        map.addOverLay(marker17);
        TEvent.addListener(marker17, "click", function () { onClick(120.11758, 31.5022, 258); })
        // TEvent.addListener(marker17, "mouseover", function () { onMouseOver(120.11758, 31.5022, 258); })

//        marker18 = new TMarker(new TLngLat(120.0067311, 31.45384417));
//        map.addOverLay(marker18);
//        TEvent.addListener(marker18, "click", function () { onClick(120.0067311, 31.45384417, 18); })
//        TEvent.addListener(marker18, "mouseover", function () { onMouseOver(120.0067311, 31.45384417, 18); })

        //注册标注的点击事件 
        //TEvent.addListener(marker, "click", onClick);
    }

    function onClick(lng,lat,stationId) {
        //alert(number);
        //top.location.href = "MEASURAND_PREDICT_SECTION_2011.aspx?" + number;
        var showInfo = "";
        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest();
        }
        else {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }

        xmlhttp.open("GET", "getLatestStationWaterInfo.ashx?stationId=" + stationId, true);
        xmlhttp.send();

        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                //当服务器有回应时执行的语句
                var result = xmlhttp.responseText.toString();
                var waterInfo = result.split('&');
                //alert(waterInfo[0]);
                var lnglat = new TLngLat(lng, lat);
                infoWindow = new TInfoWindow(lnglat, new TPixel([0, 0]));
                //infoWindow.closeInfoWindowWithMouse();

                showInfo += "站点号:" + stationId + "</br>";
                showInfo += "站点名称:" + waterInfo[0] + "</br>";
                showInfo += "采样时间:" + waterInfo[1] + "</br>";
                showInfo += " CODMn:" + waterInfo[2] + "毫克/升</br>";
                showInfo += " NH3_N:" + waterInfo[3] + "毫克/升</br>";
                showInfo += " TP:   " + waterInfo[4] + "毫克/升</br>";
                showInfo += " TN:   " + waterInfo[5] + "毫克/升</br>";
                if (waterInfo[6] != null)
                    showInfo += " 流量:   " + waterInfo[6] + "立方米/小时</br>";
                else
                    showInfo += " 流量:   0立方米/小时</br>";
                showInfo += "<a href='javascript:window.top.location=\&quot Daily_Discharge_Amount_new.aspx \&quot'>日排放量图</a></br>";
                showInfo += "<a href='javascript:window.top.location=\&quot dataquery_HIS_MEASURAND_DischargeAmount_Day.aspx \&quot'>日排放量表</a></br>";

                infoWindow.setWidth(300);
                infoWindow.setLabel(showInfo);
                map.addOverLay(infoWindow);
            }
        }
    }

    //从数据库中读取截面最新的河流采样信息
    function onMouseOver(lng, lat, section) {
//        var showInfo = "";
//        if (window.XMLHttpRequest) {
//            xmlhttp = new XMLHttpRequest();
//        }
//        else {
//            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
//        }      

//        xmlhttp.open("GET","getLatestStationWaterInfo.ashx?section="+section,true);
//        xmlhttp.send();

//        xmlhttp.onreadystatechange = function () {
//            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
//                //当服务器有回应时执行的语句
//            }
//        }
    }

    function infoWindowHref(id) {
        switch (id) {
            case 1: top.window.history = 'Daily_Discharge_Amount_new.aspx';
            case 2: top.window.history = 'dataquery_HIS_MEASURAND_DischargeAmount_Day.aspx';
            default: break;
        }
    }
    function onMouseOut() {

    }

    function onClickOtherArea() {
        map.removeOverLay(infoWindow);
    }
    //鼠标在地图上按下左键时添加一个点标记 
    function mouseup(point) {
        marker = new TMarker(point);
        map.addOverLay(marker);
        markerTool.close();
    }
    
    //启动编辑点标记 
//    function editMarker() {
//        if (marker == null) {
//            alert('请先画点再进行编辑！');
//            return;
//        }
//        else {
//            marker.enableEdit();
//            listener = TEvent.bind(marker, "dragend", marker, function (lnglat) {
//                TEvent.removeListener(listener);
//                alert("当前坐标：" + lnglat.getLng() + "," + lnglat.getLat());
//            });
//        }
//    } 
</script> 
</head> 
<body onLoad="onLoad()" onclick="onClickOtherArea()"> 
 <div id="mapDiv" style="position:absolute;width:100%; height:100%"></div>

    <%--<div style="position:absolute;left:1400px;">

        <input type="button" value="开 启" onClick="markerTool.open();"/>
        <input type="button" value="关 闭" onClick="markerTool.close();"/>
        <input type="button" value="编 辑" onClick="editMarker();"/>
    </div>--%>

</body> 
</html>