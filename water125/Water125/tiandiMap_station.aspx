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
        marker1 = new TMarker(new TLngLat(119.8151353, 31.50946944));
        //向上地图上添加标注 
        map.addOverLay(marker1);
        TEvent.addListener(marker1, "click", function () { onClick(119.8151353, 31.50946944,1); })
        TEvent.addListener(marker1, "mouseover", function () { onMouseOver(119.8151353, 31.50946944,1); })


        marker2 = new TMarker(new TLngLat(119.82801, 31.50623));
        map.addOverLay(marker2);
        TEvent.addListener(marker2, "click", function () { onClick(119.82801, 31.50623, 2); })
        TEvent.addListener(marker2, "mouseover", function () { onMouseOver(119.82801, 31.50623, 2); })

        marker3 = new TMarker(new TLngLat(119.84097, 31.50323));
        map.addOverLay(marker3);
        TEvent.addListener(marker3, "click", function () { onClick(119.84097, 31.50323, 3); })
        TEvent.addListener(marker3, "mouseover", function () { onMouseOver(119.84097, 31.50323, 3); })

        marker4 = new TMarker(new TLngLat(119.8544517, 31.49976694));
        map.addOverLay(marker4);
        TEvent.addListener(marker4, "click", function () { onClick(119.8544517, 31.49976694, 4); })
        TEvent.addListener(marker4, "mouseover", function () { onMouseOver(119.8544517, 31.49976694, 4); })

        marker5 = new TMarker(new TLngLat(119.86496, 31.49723));
        map.addOverLay(marker5);
        TEvent.addListener(marker5, "click", function () { onClick(119.86496, 31.49723, 5); })
        TEvent.addListener(marker5, "mouseover", function () { onMouseOver(119.86496, 31.49723, 5); })

        marker6 = new TMarker(new TLngLat(119.87531, 31.49489));
        map.addOverLay(marker6);
        TEvent.addListener(marker6, "click", function () { onClick(119.87531, 31.49489, 6); })
        TEvent.addListener(marker6, "mouseover", function () { onMouseOver(119.87531, 31.49489, 6); })

        marker7 = new TMarker(new TLngLat(119.88573, 31.49262));
        map.addOverLay(marker7);
        TEvent.addListener(marker7, "click", function () { onClick(119.88573, 31.49262, 7); })
        TEvent.addListener(marker7, "mouseover", function () { onMouseOver(119.88573, 31.49262, 7); })

        marker8 = new TMarker(new TLngLat(119.8970956, 31.48899167));
        map.addOverLay(marker8);
        TEvent.addListener(marker8, "click", function () { onClick(119.8970956, 31.48899167, 8); })
        TEvent.addListener(marker8, "mouseover", function () { onMouseOver(119.8970956, 31.48899167, 8); })

        marker9 = new TMarker(new TLngLat(119.90739, 31.48506));
        map.addOverLay(marker9);
        TEvent.addListener(marker9, "click", function () { onClick(119.90739, 31.48506, 9); })
        TEvent.addListener(marker9, "mouseover", function () { onMouseOver(119.90739, 31.48506, 9); })

        marker10 = new TMarker(new TLngLat(119.91717, 31.48149));
        map.addOverLay(marker10);
        TEvent.addListener(marker10, "click", function () { onClick(119.91717, 31.48149, 10); })
        TEvent.addListener(marker10, "mouseover", function () { onMouseOver(119.91717, 31.48149, 10); })

        marker11 = new TMarker(new TLngLat(119.92886, 31.47728));
        map.addOverLay(marker11);
        TEvent.addListener(marker11, "click", function () { onClick(119.92886, 31.47728, 11); })
        TEvent.addListener(marker11, "mouseover", function () { onMouseOver(119.92886, 31.47728, 11); })

        marker12 = new TMarker(new TLngLat(119.93978, 31.47381333));
        map.addOverLay(marker12);
        TEvent.addListener(marker12, "click", function () { onClick(119.93978, 31.47381333, 12); })
        TEvent.addListener(marker12, "mouseover", function () { onMouseOver(119.93978, 31.47381333, 12); })

        marker13 = new TMarker(new TLngLat(119.95159, 31.4706));
        map.addOverLay(marker13);
        TEvent.addListener(marker13, "click", function () { onClick(119.95159, 31.4706, 13); })
        TEvent.addListener(marker13, "mouseover", function () { onMouseOver(119.95159, 31.4706, 13); })

        marker14 = new TMarker(new TLngLat(119.96335, 31.46705));
        map.addOverLay(marker14);
        TEvent.addListener(marker14, "click", function () { onClick(119.96335, 31.46705, 14); })
        TEvent.addListener(marker14, "mouseover", function () { onMouseOver(119.96335, 31.46705, 14); })

        marker15 = new TMarker(new TLngLat(119.97506, 31.46369));
        map.addOverLay(marker15);
        TEvent.addListener(marker15, "click", function () { onClick(119.97506, 31.46369, 15); })
        TEvent.addListener(marker15, "mouseover", function () { onMouseOver(119.97506, 31.46369, 15); })

        marker16 = new TMarker(new TLngLat(119.9864947, 31.46035694));
        map.addOverLay(marker16);
        TEvent.addListener(marker16, "click", function () { onClick(119.9864947, 31.46035694, 16); })
        TEvent.addListener(marker16, "mouseover", function () { onMouseOver(119.9864947, 31.46035694, 16); })

        marker17 = new TMarker(new TLngLat(119.99706, 31.457));
        map.addOverLay(marker17);
        TEvent.addListener(marker17, "click", function () { onClick(119.99706, 31.457, 17); })
        TEvent.addListener(marker17, "mouseover", function () { onMouseOver(119.99706, 31.457, 17); })

//        marker18 = new TMarker(new TLngLat(120.0067311, 31.45384417));
//        map.addOverLay(marker18);
//        TEvent.addListener(marker18, "click", function () { onClick(120.0067311, 31.45384417, 18); })
//        TEvent.addListener(marker18, "mouseover", function () { onMouseOver(120.0067311, 31.45384417, 18); })

        //注册标注的点击事件 
        //TEvent.addListener(marker, "click", onClick);
    }

    function onClick(lng,lat,section) {
        //alert(number);
        //top.location.href = "MEASURAND_PREDICT_SECTION_2011.aspx?" + number;
        var showInfo = "";
        if (window.XMLHttpRequest) {
            xmlhttp = new XMLHttpRequest();
        }
        else {
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }

        xmlhttp.open("GET", "getLatestStationWaterInfo.ashx?section=" + section, true);
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

                showInfo += "截面号:" + section + "</br>";
                showInfo += " COD:" + waterInfo[2] + "</br>";
                showInfo += " NH4:" + waterInfo[3] + "</br>";
                showInfo += " TN :" + waterInfo[4] + "</br>";
                showInfo += " TP :" + waterInfo[5] + "</br>";

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