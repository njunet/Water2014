<%@ Page Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Maticsoft.Web.News" Title="科技产业处" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="990" border="0" align="center" cellpadding="0" cellspacing="10" bgcolor="#FFFFFF">
  <tr>
    <td valign="top" id="content">
    <div align="left" class="loca" id="PagaNavi" runat="server">当前位置：<a href="index.aspx">首页</a>&gt;<a href="#">一级栏目</a>&gt;<a href="#">二级栏目</a>&gt;文章阅读</div>    
    <div align="center" class="title" id="heading" runat="server"><%=strHeading %></div>
    <div align="center" class="subtitle" id="newsInfo" runat="server">阅读<%=strfrquency %>：发布时间：<%=strDate %></div>
    
    <div  id="newscontent" runat="server">
    
        <div class="content" id="newsimagescontent" runat="server" ></div>


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
