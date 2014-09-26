<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllList.aspx.cs" Inherits="Maticsoft.Web.Admin.Material.AllList" %>
<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="../../Controls/CheckRight.ascx" %>
<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
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
     <link href="../../style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
     <table width="90%" border="0" cellspacing="0" cellpadding="0" align="center" id="Table1">
                <tr>
                    <td class="TableBody1" valign="top">
                        <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0">
                            <tr>
                                <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>' style="width: 840px; height: 99px;">
                                    <table bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                                        cellpadding="5" width="100%" bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'
                                        border="1" cellspacing="0">
                                        <tr>
                                            <td height="25" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>'
                                                align="center">
                                                <b>材料汇总</b></td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" style="height: 22px">
                                                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                &nbsp; &nbsp; <a href="Table.aspx" >【打印全部信息】</a>
                                                &nbsp; &nbsp; <a href="Table2.aspx" >【打印学院信息】</a><asp:Label ID="Label1" runat="server"
                                                    ForeColor="Red" Text="(先选择接受对象)"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 840px; height: 39px;">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tr id="TrGrid" runat="server">
                                            <td align="left" style="height: 15px">
                                                ○ 页次：<asp:Label ID="lblpage" runat="server" ForeColor="#E78A29"></asp:Label>/
                                                <asp:Label ID="lblpagesum" runat="server"></asp:Label>，共：<font color="#e78a29"><asp:Label
                                                    ID="lblrowscount" runat="server"></asp:Label></font>条</td>
                                            <td align="right" style="height: 15px">
                                                <asp:LinkButton ID="btnFirst" runat="server" ForeColor="#E78A29" OnCommand="NavigateToPage"
                                                    CommandArgument="First" CommandName="Pager" Text="首 页">[首 页]</asp:LinkButton><asp:LinkButton
                                                        ID="btnPrev" runat="server" ForeColor="#E78A29" OnCommand="NavigateToPage" CommandArgument="Prev"
                                                        CommandName="Pager" Text="上一页">[上一页]</asp:LinkButton><asp:LinkButton ID="btnNext"
                                                            runat="server" ForeColor="#E78A29" OnCommand="NavigateToPage" CommandArgument="Next"
                                                            CommandName="Pager" Text="下一页">[下一页]</asp:LinkButton><asp:LinkButton ID="btnLast"
                                                                runat="server" ForeColor="#E78A29" OnCommand="NavigateToPage" CommandArgument="Last"
                                                                CommandName="Pager" Text="尾 页">[尾 页]</asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
						<td vAlign="middle" height="25">&nbsp;&nbsp;&nbsp; 快速查询（材料名称）：
							<asp:textbox id="txtKey" runat="server" ToolTip="材料名称关键字"></asp:textbox>&nbsp;
							<asp:imagebutton id="btn_Search" runat="server" ToolTip="快速检索所查材料" ImageUrl="../images/button_search.GIF" OnClick="btn_Search_Click"></asp:imagebutton></td>
					</tr>
                            <tr>
                                <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>' style="width: 840px; height: 24px;">
                                    <table width ="100%">
                                        <tr>
                                            <td style="width:25%; vertical-align: top;" align="left">
                                                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="SelectedList">
                                                </asp:TreeView>
                                            </td>
                                        
                                            <td style="width:75%; vertical-align: top;">
                                            <asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%"
							DataKeyField="Id" OnItemDataBound="grid_ItemDataBound"  SkinID="datagridSkin" CellPadding="10" BorderWidth="1px" HeaderStyle-Font-Bold="true">
							<Columns>
							
								
								<asp:BoundColumn DataField="Id" ReadOnly="True" HeaderText="编号">
                                    <HeaderStyle Width="30px" />
                                </asp:BoundColumn>
								 <asp:BoundColumn DataField="Name" HeaderText="材料名称"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Receiver" HeaderText="学院"></asp:BoundColumn>
								<asp:BoundColumn DataField="Dormacy" ReadOnly="True" HeaderText="状态">
									<HeaderStyle Wrap="False" Width="28px"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IssureTime" HeaderText="时间">
									<HeaderStyle Wrap="False" Width="110px"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								
								
							</Columns>
							<PagerStyle Visible="False"></PagerStyle>
                                                <HeaderStyle Font-Bold="True" />
						</asp:datagrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 25%">
                                            </td>
                                            <td style="width: 75%">
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <uc1:CheckRight ID="CheckRight1" runat="server" PermissionID="3"></uc1:CheckRight>
        <uc2:copyright ID="Copyright1" runat="server" />
    </form>
</body>
</html>
