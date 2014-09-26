<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAgentAdmin.aspx.cs" Inherits="Maticsoft.Web.Accounts.Admin.UserAgentAdmin" %>

<%@ Register Src="../../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>代理商ppc和400的汇总统计用户查看权限分配</title>
    <link rel="stylesheet" href="../style/style.css" type="text/css">
</head>
<body topmargin="5">
    <form id="Form1" method="post" runat="server">
			<div align="center">
				<table cellSpacing="0" cellPadding="5" width="600" align="center" border="0">
					<tr>
						<td bgColor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>' 
    >
							<table cellSpacing=0 
      borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
      cellPadding=5 width="100%" 
      borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
      border=1>
								<tr>
									<td align="center" height="25" bgColor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' colspan="2">
										<STRONG>代理商ppc和400的汇总统计用户查看权限分配</STRONG></td>
								</tr>
								
								<tr>
									<td height="30" valign="middle" align="left" colspan="2">
										<B>&nbsp;&nbsp; 选择用户</B>：<asp:DropDownList id="ddlUser" runat="server" AutoPostBack="True" Width="120px" BackColor="GhostWhite" onselectedindexchanged="ddlUser_SelectedIndexChanged"></asp:DropDownList>
									</td>
								</tr>
								<TR>
									<TD height="22" colspan="2">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
											<TR>
												<TD vAlign="top" align="center" width="43%">
													<asp:listbox id="AllAgentList" runat="server" Width="100%" Rows="15" BackColor="AliceBlue" Font-Size="9pt" SelectionMode="Multiple"></asp:listbox>
												</TD>
												<td align="center" valign="middle" width="14%">
													<P>
														<asp:Button id="btnAdd" runat="server" Width="85px" Text="增 加 >>" Height="22px"
															BorderStyle="Solid" BorderColor="DarkGray" BackColor="GhostWhite" Font-Size="9pt" OnClick="btnAdd_Click"></asp:Button></P>
													<P>
														<asp:Button id="btnRemove" runat="server" Width="85px" Text="<< 移 除" Height="22px"
															BorderStyle="Solid" BorderColor="DarkGray" BackColor="GhostWhite" Font-Size="9pt" OnClick="btnRemove_Click"></asp:Button></P>
												</td>
												<TD vAlign="top" align="center" width="43%">
													<asp:listbox id="SelectedAgentList" runat="server" Width="100%" Rows="15" BackColor="AliceBlue"
														Font-Size="9pt" SelectionMode="Multiple"></asp:listbox>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</table>
							<DIV></DIV>
							<br>
						</td>
					</tr>
				</table>
				</div>
        <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
