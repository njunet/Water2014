<%@ Page Language="C#" MasterPageFile="~/IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Water125.News" Title="江苏省太湖流域主要水污染物总量动态监控和评估示范平台" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
    </asp:Panel>
    <asp:Localize ID="Localize1" runat="server"></asp:Localize>
    
<table width="990" border="0" align="center" cellpadding="0" cellspacing="10" bgcolor="#FFFFFF">
  <tr>
    <td valign="top" id="content">
    <div align="left" class="loca" id="PagaNavi" runat="server">当前位置：<a href="map.html">首页</a>&gt;<a href="#">一级栏目</a>&gt;<a href="#">二级栏目</a>&gt;文章阅读</div>    
    <div align="center" class="title" id="heading" runat="server"><%=strHeading %></div>
    <div align="center" class="subtitle" id="newsInfo" runat="server">阅读<%=strfrquency %>：发布时间：<%=strDate %></div>
    
    <div  id="newscontent" runat="server" align="left">
    
        <div class="content" id="newsimagescontent" runat="server" align="left"></div>


   <%=strContent%>
   
           <div class="content" id="newsaffixcontent" runat="server" style="padding:30px; text-indent:-0.5cm;"></div>

     </div>
    <div class="op">
      <div align="center">[<a href="javascript:window.close()">关闭窗口</a>][<a href="javascript:window.print()">打印本页</a>]</div>
    </div>
    </td>
  </tr>
</table>
    
</asp:Content>
