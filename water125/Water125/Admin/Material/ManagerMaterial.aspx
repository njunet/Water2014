<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerMaterial.aspx.cs" Inherits="Maticsoft.Web.Admin.Material.ManagerMaterial" %>
<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="../../Controls/CheckRight.ascx" %>
<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>用户管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
    
    <link href="../../style.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div align="center">
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
                                                <b>材料管理</b></td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" style="height: 22px">
                                                &nbsp;
                                                <asp:Label ID="Label1" runat="server">材料关键字：材料名</asp:Label>
                                                <asp:TextBox ID="TextBox1" runat="server" Width="100px" BorderStyle="Groove"></asp:TextBox>
                                                <asp:ImageButton ID="BtnSearch" runat="server" ImageUrl="..\images\button_search.GIF"
                                                    OnClick="BtnSearch_Click"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                &nbsp;<a href="AddMaterial.aspx">【添加新材料】</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 840px">
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
                                <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>' style="width: 840px">
                                    <asp:DataGrid ID="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False"
                                        AllowPaging="True" HorizontalAlign="Center" PageSize="20">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <Columns>
                                       
                                           <asp:TemplateColumn HeaderText="编号" SortExpression="Id">
                                                <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <%# DataGrid1.CurrentPageIndex*DataGrid1.PageSize+DataGrid1.Items.Count+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn SortExpression="Id" HeaderText="材料名称">
                                                <ItemTemplate>
                                                    <a href='ShowingMaterial.aspx?Id=<%# DataBinder.Eval(Container, "DataItem.Id") %>&PageIndex=<%# DataGrid1.CurrentPageIndex %>'>
                                                        <%# DataBinder.Eval(Container, "DataItem.Name")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="Begindate" SortExpression="Begindate" ReadOnly="True" HeaderText="开始时间">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Enddate" SortExpression="Enddate" ReadOnly="True" HeaderText="结束时间">
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Outdisplay" SortExpression="Outdisplay" ReadOnly="True" HeaderText="过期显示">
                                            </asp:BoundColumn>
                                           
                                            <asp:TemplateColumn HeaderText="管理">
                                             <HeaderStyle Width="30px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="BtnManager" runat="server" ImageUrl="..\Accounts\images\button_manage.gif"
                                                        CommandName="BtnManager"></asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="修改">
                                                <HeaderStyle Width="30px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="BtnEdit" runat="server" ImageUrl="..\Accounts\images\button_edit.gif"
                                                        CommandName="BtnEdit"></asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="删除">
                                                <HeaderStyle Width="30px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="BtnDel" runat="server" ImageUrl="..\Accounts\images\button_del.gif" CommandName="BtnDel">
                                                    </asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True" HeaderText="材料Id">
                                                <HeaderStyle Width="30px"></HeaderStyle>
                                            </asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle Font-Size="Medium" HorizontalAlign="Right" Wrap="False" Mode="NumericPages">
                                        </PagerStyle>
                                    </asp:DataGrid>
                                </td>
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
