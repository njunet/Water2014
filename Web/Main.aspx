<%@ Page Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Maticsoft.Web.Main1" Title="江苏技术师范学院科技产业处" %>

<%@ Register Src="Controls/SubNewsList.ascx" TagName="SubNewsList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
 <table width="990" border="0" align="center" cellpadding="0" cellspacing="10" bgcolor="#ffffff">
  <tr>
    <td width="220" valign="top"><table border="0" cellpadding="0" cellspacing="0" class="index_left" id="sub">
      <tr>
        <td height="47" background="images/sub_nav.jpg"><div align="left" class="nav_1" id="ClassName" runat="server"></div></td>
      </tr>
      <tr>
        <td valign="top" background="images/index_left_bj1.jpg">
            <ul id="ClassList" runat="server">
             </ul></td>
      </tr>
    </table>
      <table border="0" cellpadding="0" cellspacing="0" style="margin-bottom:10px">
        <tr>
          <td width="218" height="70" background="images/search1.jpg">
          
             <iframe scrolling="No" src="search.html" height="70px" width="218px" vspace="0" frameborder="0" allowtransparency="1"></iframe>

          
          </td>
        </tr>
      </table>
    <a href="#"><img src="images/index2.jpg" width="218" height="48" border="0" class="index_left" /></a><a href="#"><img src="images/index6.jpg" width="218" height="56" border="0" class="index_right" /></a></td>
    <td width="738" valign="top" id="sub_article_list">
    <uc1:SubNewsList id="SubNewsList1" runat="server" MyPage="15">
    </uc1:SubNewsList>    </td>
  </tr>
</table>
 
   
</asp:Content>
