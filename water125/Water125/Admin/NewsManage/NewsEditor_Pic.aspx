<%@ Page Language="C#"  ValidateRequest="false" AutoEventWireup="true" CodeBehind="NewsEditor_Pic.aspx.cs" Inherits="Water125.Admin.NewsManage.NewsEditor_Pic" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<%@ Register Src="~/Controls/copyright.ascx" TagName="CopyRight" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="LtpPageControl" Assembly="LtpPageControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>图片上传</title>
    <link href="../../Style.css" type="text/css" rel="stylesheet"/>
      <base target="_self" />
   
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
           <table cellspacing="0" cellpadding="5" width="85%" border="0" >
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
                                                <asp:Label ID="Label_ArticleId" runat="server" ForeColor="White"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                类别：</td>
                                            <td height="14" width="*" style="height: 14px; text-align: left; width: 447px;">
                                                <asp:FileUpload ID="FileUpload1" runat="server" Width="368px" /><asp:Button ID="Button_Upload"
                                                    runat="server" OnClick="Button_Upload_Click" Text="上传图片" /></td>
                                        </tr>
                                        <tr>
                                            <td height="25" width="30%" align="right">
                                                标题：
                                            </td>
                                            <td height="25" width="*" style="text-align: left; width: 447px;">
                                                &nbsp;<ce:editor id="FreeTextBox1" runat="server" autoconfigure="Minimal" height="150px"
                                                    showhtmlmode="False" showpreviewmode="False" width="100%"><FRAMESTYLE Width="100%" Height="100%" BackColor="White" CssClass="CuteEditorFrame" BorderWidth="1px" BorderStyle="Solid" BorderColor="#DDDDDD" /></ce:editor></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                图片预览：</td>
                                            <td height="22" style="text-align: left; width: 447px;">
          <div style="overflow: auto; height: 200px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowCommand="GridViewCommand" OnRowDataBound="GridViewDataBound">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            <asp:BoundField DataField="id" >
                                <ItemStyle Width="0px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="linkurl" >
                                <ItemStyle Width="0px" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>                                
                                    <div style="width:100%;text-align:left"><img  alt="" src='<%# "../../upload/Temp/"+ Eval("linkurl") %>' height="100" width="120"/></div>
                                   <div style="width:100%;text-align:left"><%#Eval("descrip")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField CommandName="Del" Text="删除" />
                        </Columns>
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    </div>
                                            </td>
                                        </tr>
                                        
                                    </table>
                        <asp:Label ID="Label_Msg" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr> 
                        </table>
                        <asp:Button
                            ID="Button1" runat="server" Enabled="False" OnClick="Button1_Click" Text="保存" Visible="False" /><asp:Button
                                ID="Button2" runat="server" OnClick="Button2_Click" Text="取消" Visible="False" /></td>
                </tr>
            </table>
        </div>
      
    </form>
</body>
</html>
