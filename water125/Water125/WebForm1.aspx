<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Water125.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>无标题文档</title>

<script type="text/javascript">
    function count() {
        alert("现在的日期是：" + new Date().toLocaleString());

        var date1 = new Date("2010/12/31");        //2010年12月31日0时0分0秒
        var date2 = new Date("2011/1/6");      //此时的日期

        var date3 = date2.getTime() - date1.getTime();  //时间差的毫秒数
        alert(date3);
       
        var hours = Math.floor(date3 / ( 3600 * 1000));

//        //计算出小时数
//        var leave1 = date3 % (24 * 3600 * 1000);     //计算天数后剩余的毫秒数
//        var hours = Math.floor(leave1 / (3600 * 1000));

//        //计算相差分钟数
//        var leave2 = leave1 % (3600 * 1000);        //计算小时数后剩余的毫秒数
//        var minutes = Math.floor(leave2 / (60 * 1000));

//        //计算相差秒数
//        var leave3 = leave2 % (60 * 1000);          //计算分钟数后剩余的毫秒数
//        var seconds = Math.round(leave3 / 1000);

//        alert("今日距2010年12月31日0时0分0秒 相差 " + days + "天 " + hours + "小时 " + minutes + " 分钟" + seconds + " 秒");
        document.write(hours);
    }
</script>
</head>

<body onload="count()">

</body>
</html>