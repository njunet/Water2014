<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBackRecover.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.DataBackRecover" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据维护</title>
     <link href="../../Style.css" type="text/css" rel="stylesheet">
</head>
<body>
     <form id="form2" runat="server">
    
    <div style="text-align:center">
			<table cellSpacing="0" cellPadding="5" width="90%" align="center" border="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
			bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
				<tr>
					<td >
                        
                    <table style="width: 100%">
                                                    <tr>
                                                        <td >
                                                            <div style="text-align:right; width:100px; float:left">数据库备份路径：</div><asp:TextBox ID="TextBoxPath" runat="server" ToolTip="请在这里输入完整的备份文件位置与文件名。如E:\Backup\CZJTDJ"
                                                                Width="415px" Enabled="False"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td  >
                                                           <div style="text-align:right; width:100px;float:left"> 备份文件名：</div><asp:TextBox ID="TextBoxFile" runat="server" Width="415px" ToolTip="请在这里输入完整的备份文件位置与文件名。如CZJTDJ.BAK。"></asp:TextBox></td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td align="center" >
                                                            <asp:HyperLink ID="HyperLinkDownDB" runat="server" ToolTip="点击此处下载最新备份数据库!" Visible="False">下载备份数据库</asp:HyperLink>&nbsp;&nbsp;<a href="DataBackManager.aspx">备份文件管理</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                           <asp:Button ID="Button_Confirm" runat="server" OnClick="Button_Confirm_Click" Text="确定" />
                                                                        <asp:Button ID="Button_Cancel" runat="server" OnClick="Button_Cancel_Click" Text="取消" /></td>
                                                    </tr>
                                                    </table>
                    
                    
                    
                    </td>
					
				</tr>
			</table>			
        <uc1:CopyRight ID="CopyRight1" runat="server" />
        <uc2:checkright id="Checkright1" runat="server">
        </uc2:checkright></div>
    </form>
</body>
</html>
