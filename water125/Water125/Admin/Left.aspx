<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Water125.Admin.Left" %>

<%@ Register src="~/Controls/checkright.ascx" tagname="checkright" tagprefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link href="images/style.css" type="text/css" rel="stylesheet">

</head>
<body bgColor='<%=Application[Session["Style"].ToString()+"xtree_bgcolor"]%>' 
	text=#000000 leftMargin=0 topMargin=0 onload="" marginheight="0" marginwidth="0" >
		<form id="Form1" method="post" runat="server">
			<table width="204" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td height="27px"><img src='<%=Application[Session["Style"].ToString()+"xleft1_bgimage"]%>' width="200" height="27"></td>
					<td rowspan="3" bgColor='<%=Application[Session["Style"].ToString()+"xtree_bgcolor"]%>'></td>
				</tr>
				<tr>
					<td height="85%" valign="top" background='<%=Application[Session["Style"].ToString()+"xleftbj_bgimage"]%>'>
						<div align="left"><font color="#314a72">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= strWelcome %></font></div>
						<br>						
						<asp:TreeView ID="TreeView1" runat="server">
                        </asp:TreeView>
                    </td>
				</tr>
				<tr>
					<td height="19"><img src='<%=Application[Session["Style"].ToString()+"xleft2_bgimage"]%>' width="200" height="19"></td>
				</tr>
			</table>
			<uc1:checkright id="CheckRight1" runat="server"/>
		</form>
	</body>
</html>
