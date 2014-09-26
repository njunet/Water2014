<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsEditor_Affix.aspx.cs" Inherits="Maticsoft.Web.Admin.NewsManage.NewsEditor_Affix" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>附件上传</title>
        <link href="../../Style.css" type="text/css" rel="stylesheet"/>
      <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
   <div align="center">
           <table cellspacing="0" cellpadding="5" style="width:600px;height:400px;" border="0" >
                <tr>
                    <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                        <table cellspacing="0" cellpadding="5" width="100%" border="1" bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                            bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                                                      <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>'>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td height="14" style="height: 14px; text-align: left; width: 447px;" width="*">
                                                <asp:Label ID="Label_ArticleId" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                类别：</td>
                                            <td height="14" width="*" style="height: 14px; text-align: left; width: 447px;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button_addfix"
                                                    runat="server" OnClick="Button_addfix_Click" Text="上传附件" ToolTip="提示：上传附件不能超过4M!" /></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                附件名称：&nbsp;</td>
                                            <td height="14" style="width: 447px; height: 14px; text-align: left" width="*">
                                                <asp:TextBox ID="TextBox_affixname" runat="server" Width="400px">附件</asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                文件列表：
                                            </td>
                                            <td height="25" width="*" style="text-align: left; width: 447px;">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    ForeColor="#333333" GridLines="None" OnRowCommand="GridViewCommand" OnRowDataBound="GridViewDataBound">
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <Columns>
                                                    
                                                        <asp:BoundField DataField="id" HeaderText="附件ID">
                                                            <ItemStyle Width="80px" />
                                                        </asp:BoundField>
                                                    
                                                   
                                                        <asp:BoundField DataField="descrip" HeaderText="附件名称">
                                                            <ItemStyle Width="80px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="linkurl" HeaderText="文件名">
                                                            <ItemStyle Width="100px" />
                                                        </asp:BoundField>
                                                        <asp:ButtonField CommandName="Del" Text="删除" />
                                                    </Columns>
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td height="22" style="width: 447px; text-align: left">
                                                <asp:Label ID="Label_Msg" runat="server" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                            </td>
                                            <td height="22" style="width: 447px; text-align: left">
                                                <asp:Button ID="Button1" runat="server" Enabled="False" OnClick="Button1_Click" Text="确定" /><asp:Button
                                                    ID="Button2" runat="server" OnClick="Button2_Click" Text="取消" /></td>
                                        </tr>
                                        
                                    </table>
                        </td>
                            </tr> 
                        </table>
                        </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
