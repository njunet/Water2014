<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tiandiMap_getPoint.aspx.cs" Inherits="Water125.tiandiMap_getPoint" %>
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


        //        marker18 = new TMarker(new TLngLat(120.0067311, 31.45384417));
        //        map.addOverLay(marker18);
        //        TEvent.addListener(marker18, "click", function () { onClick(120.0067311, 31.45384417, 18); })
        //        TEvent.addListener(marker18, "mouseover", function () { onMouseOver(120.0067311, 31.45384417, 18); })

        //注册标注的点击事件 
        //TEvent.addListener(marker, "click", onClick);
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
    function editMarker() {
        if (marker == null) {
            alert('请先画点再进行编辑！');
            return;
        }
        else {
            marker.enableEdit();
            listener = TEvent.bind(marker, "dragend", marker, function (lnglat) {
                TEvent.removeListener(listener);
                alert("当前坐标：" + lnglat.getLng() + "," + lnglat.getLat());
            });
        }
    } 
</script> 
</head> 
<body onLoad="onLoad()" onclick="onClickOtherArea()"> 
 <div id="mapDiv" style="position:absolute;width:75%; height:75%"></div>
    <div style="position:absolute;left:1800px;">

        <input type="button" value="开 启" onClick="markerTool.open();"/>
        <input type="button" value="关 闭" onClick="markerTool.close();"/>
        <input type="button" value="编 辑" onClick="editMarker();"/>
    </div>

</body> 
</html>