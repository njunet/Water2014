<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="Maticsoft.Web.Admin.Material.Manager" %>
<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../style.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="calendar.js"></script>
    <script language="javascript">
   function CA(){
var frm=  document.forms[0];
for (var i=0;i<frm.elements.length;i++)
{
var e=frm.elements[i];
if ((e.name != 'allbox') && (e.type=='checkbox'))
{
e.checked=frm.allbox.checked;
if (frm.allbox.checked)
{
hL(e);
}//endif
else
{
dL(e);
}//endelse

}//endif
}//endfor
}


//CheckBox选择项
function CCA(CB)
{
var frm=document.Form1;
if (CB.checked)
hL(CB);
else
dL(CB);

var TB=TO=0;
for (var i=0;i<frm.elements.length;i++)
{
var e=frm.elements[i];
if ((e.name != 'allbox') && (e.type=='checkbox'))
{
TB++;
if (e.checked)
TO++;
}
}
frm.allbox.checked=(TO==TB)?true:false;
}


function hL(E){
while (E.tagName!="TR")
{E=E.parentElement;}
E.className="H";
}

function dL(E){
while (E.tagName!="TR")
{E=E.parentElement;}
E.className="";
}

 
   </script>

    <script language="javascript" src="../../js/date.js">function Button_NoSelected_onclick() {

}

</script>
</head>
<body ms_positioning="GridLayout">
    <form id="form1" runat="server" method="post">
    <div align="center">
            <table cellspacing="0" cellpadding="5" width="90%" align="center" border="0">
                <tr>
                    <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                        <table cellspacing="0" bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                            cellpadding="5" width="100%" bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'
                            border="1">
                            <tr bgcolor="#e4e4e4">
                                <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' align="center" style="height: 25px">
                                    【 管理<strong>项目材料 </strong>】</td>
                            </tr>
                            <tr>
                                <td height="25">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td style="width: 202px; height: 25px;">
                                                <div align="right">
                                                    <font color='<%=Application[Session["Style"].ToString()+"xform_requestcolor"]%>'>*</font>
                                                    材料名称：</div>
                                            </td>
                                            <td style="text-align: left; height: 25px;">
                                                <asp:TextBox ID="Name" TabIndex="1" runat="server" Width="249px" MaxLength="20"
                                                    BorderStyle="Groove"></asp:TextBox>
                                                <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 202px; height: 25px;">
                                                <div align="right">
                                                    <font color='<%=Application[Session["Style"].ToString()+"xform_requestcolor"]%>'>*</font>
                                                    开始时间：</div>
                                            </td>
                                            <td style="text-align: left; height: 25px;">
                                                <asp:TextBox ID="begindate" TabIndex="2" runat="server" Width="249px" MaxLength="20"
                                                    BorderStyle="Groove" ToolTip="日期格式:YYYY-MM-DD，双击选择日期" ondblclick="calendar()" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="25" style="width: 202px">
                                                <div align="right">
                                                    <font color='<%=Application[Session["Style"].ToString()+"xform_requestcolor"]%>'>*</font>
                                                    结束时间：</div>
                                            </td>
                                            <td height="25" style="text-align: left">
                                                <asp:TextBox ID="enddate" TabIndex="3" runat="server" Width="249px" MaxLength="20"
                                                    BorderStyle="Groove" ToolTip="日期格式:YYYY-MM-DD，双击选择日期" ondblclick="calendar()" ></asp:TextBox><a onclick="Show(1)"></a></td>
                                        </tr>
                                       
                                        <tr>
                                            <td height="25" style="width: 202px">
                                                <div align="right">
                                                    <font color='<%=Application[Session["Style"].ToString()+"xform_requestcolor"]%>'>*</font>
                                                    提交状态：</div>
                                            </td>
                                            <td height="25" style="text-align: left">
                                                <asp:CheckBoxList ID="CheckBoxList_Reciever" runat="server" RepeatDirection="Horizontal" BorderStyle ="Groove" Height="25px" RepeatColumns="3" >
                                                </asp:CheckBoxList></td>
                                        </tr>  
                                         <tr>
                                            <td height="25" style="width: 202px"><div align="right">过期是否显示：</div>
                                            </td>
                                            <td height="25" style="text-align: left">
                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="过期显示" />
                                            </td>
                                        </tr>                                   
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 25px">
                                    <div align="center">
                                        <asp:Label ID="Label1" runat="server" Visible="False" ForeColor="Black"></asp:Label><input onclick="CA();" type="checkbox" name="allbox">全选
                                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="· 提交 ·" />&nbsp;
                                        <asp:Button ID="Button_Return" runat="server"  Text="· 返回 ·" OnClick="Button_Return_Click" /></div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <uc1:copyright ID="Copyright1" runat="server" />
        <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
