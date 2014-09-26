<%@ Page Language="C#" MasterPageFile="IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="Info_show.aspx.cs" Inherits="Water125.Info_show" %>

<%@ Register Src="Controls/SubNewsList.ascx" TagName="SubNewsList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <table width="990" border="0" align="center" cellpadding="0" cellspacing="10" bgcolor="#ffffff">
  <tr>
    <td width="738" valign="top" id="sub_article_list">
    <uc1:SubNewsList id="SubNewsList1" runat="server" MyPage="15">
    </uc1:SubNewsList>    </td>
  </tr>
</table>
 
   
</asp:Content>