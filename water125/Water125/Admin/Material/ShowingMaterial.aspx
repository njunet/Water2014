<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowingMaterial.aspx.cs" Inherits="Maticsoft.Web.Admin.Material.ShowingMaterial" %>
<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Src="../../Controls/copyright.ascx" TagName="copyright" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="LtpPageControl" Assembly="LtpPageControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../style.css" type="text/css" rel="stylesheet">
      <script language="javascript" src="../../js/date.js">function Button_NoSelected_onclick() {

}

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    <cc1:Navigation01 ID="Navigation011" runat="server" Key_Str="Id" Page_Mode="Show"
                Page_Index="Index.aspx" Page_Add="add.aspx" Page_Modify="modify.aspx"></cc1:Navigation01>
                 <table width="600" border="0" align="center" cellpadding="5" cellspacing="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
            bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                <tr>
                    <td style="height: 298px" >
                        <table width="100%" border="0" cellpadding="5" cellspacing="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
            bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                            <tr  align="left">
                                <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' align="left" style="height: 22px">
                                    详细信息，点击修改可以修改当前信息，点击删除可删除当前信息</td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
												<td width="150" align="right" style="height: 16px">
													编号：
												</td>
												<td width="*" align="left" style="height: 16px">
													&nbsp;<asp:Label id="lblId" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
                                                    材料名称：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblName" runat="server"></asp:Label></td>
											</tr>
											<tr>
											<tr>
												<td width="150" height="22" align="right">
                                                    提交份数：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="Label_Number" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
                                                    是否需要排序：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="Label2" runat="server">是</asp:Label></td>
											</tr>
												<td width="150" height="22" align="right">
                                                    开始时间：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblBeginDate" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="150" height="22" align="right">
                                                    结束时间：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="lblEnddate" runat="server"></asp:Label></td>
											</tr>
											<tr>
											<tr>
												<td width="150" height="22" align="right">
                                                    申报通知网段：
												</td>
												<td height="22" align="left">
													&nbsp;<asp:Label id="Label_Address" runat="server"></asp:Label></td>
											</tr>
												<td width="150" align="right" style="height: 22px">
                                                    接收对象：
												</td>
												<td align="left" style="height: 22px">
													&nbsp;<asp:Label id="lblReceiver" runat="server"></asp:Label></td>
											<tr>
												<td width="150" align="right" style="height: 22px">
                                                    已经提交的部门：
												</td>
												<td align="left" style="height: 22px">
													&nbsp;<asp:Label id="Label_IsHanded" runat="server"></asp:Label></td>
											</tr>
                                       
                                    </table>
                                </td>
                            </tr>
                            <tr>
                            <td align=left>
                                &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
    
    </div>
    <uc1:CopyRight ID="CopyRight1" runat="server" />
        &nbsp;&nbsp;
        <uc2:checkright ID="Checkright1" runat="server" />
    </form>
										
</body>
</html>
