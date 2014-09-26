<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="Maticsoft.Web.Admin.Material.Table" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            Height="320px" Width="100%">
            <LocalReport ReportPath="Admin\Material\Report1.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetAllList_W_Material_Id" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
            TypeName="Maticsoft.Web.Admin.Material.DataSetAllListTableAdapters.W_Material_IdTableAdapter" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
