<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Water125.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�ޱ����ĵ�</title>

<script type="text/javascript">
    function count() {
        alert("���ڵ������ǣ�" + new Date().toLocaleString());

        var date1 = new Date("2010/12/31");        //2010��12��31��0ʱ0��0��
        var date2 = new Date("2011/1/6");      //��ʱ������

        var date3 = date2.getTime() - date1.getTime();  //ʱ���ĺ�����
        alert(date3);
       
        var hours = Math.floor(date3 / ( 3600 * 1000));

//        //�����Сʱ��
//        var leave1 = date3 % (24 * 3600 * 1000);     //����������ʣ��ĺ�����
//        var hours = Math.floor(leave1 / (3600 * 1000));

//        //������������
//        var leave2 = leave1 % (3600 * 1000);        //����Сʱ����ʣ��ĺ�����
//        var minutes = Math.floor(leave2 / (60 * 1000));

//        //�����������
//        var leave3 = leave2 % (60 * 1000);          //�����������ʣ��ĺ�����
//        var seconds = Math.round(leave3 / 1000);

//        alert("���վ�2010��12��31��0ʱ0��0�� ��� " + days + "�� " + hours + "Сʱ " + minutes + " ����" + seconds + " ��");
        document.write(hours);
    }
</script>
</head>

<body onload="count()">

</body>
</html>