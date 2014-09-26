<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBackManager.aspx.cs" Inherits="Maticsoft.Web.Admin.SysManage.DataBackManager" %>

<%@ Register Src="../../Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Src="~/Controls/copyright.ascx" TagName="CopyRight" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="LtpPageControl" Assembly="LtpPageControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>链接管理</title>
    <link href="../style.css" type="text/css" rel="stylesheet" />
</head>
<body>
   <form id="form1" runat="server">
    
    <div style="text-align:center">
    <cc1:page01 id="Page011" runat="server" Page_Index="#" Page_Add="DataBackRecover.aspx" Page_Makesql="#" Page_Search="#"></cc1:page01>
			<table cellSpacing="0" cellPadding="5" width="90%" align="center" border="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
			bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
				<tr>
					<td >
                        <asp:GridView ID="grid" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" Width="100%" 
                        CellPadding="5" BorderWidth="1px" DataKeyNames="Name" 
                            OnRowCreated="grid_RowCreated" OnRowCommand="grid_RowCommand">
                            <Columns>
                                 <asp:BoundField DataField="Name" HeaderText="名称">
                                <ItemStyle HorizontalAlign="Center" />
                               </asp:BoundField> 
                                
                                <asp:BoundField DataField="CreationTime" HeaderText="备份时间" />
                                 
                                <asp:TemplateField HeaderText="下载">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "~/upload/db/"+Eval("Name") %>' 
                                            runat="server">下载</asp:HyperLink>
                                           
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                
                                
                                  
                               
                                <asp:TemplateField HeaderText="删除" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="DeleteById"
                                            OnClientClick='return confirm("您真的要删除这条记录吗？")' Text="删除" CommandArgument='<%#Eval("Name") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Visible="False" />
                        </asp:GridView>
					
				</tr>
			</table>
			<cc1:page02 id="Page2" runat="server" Page_Index="index.aspx"></cc1:page02>
        <uc1:CopyRight ID="CopyRight1" runat="server" />
        <uc2:checkright id="Checkright1" runat="server">
        </uc2:checkright></div>
    </form>
</body>
</html>
