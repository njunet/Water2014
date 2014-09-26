<%@ Page Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="MaterialIndex.aspx.cs" Inherits="Maticsoft.Web.MaterialIndex" Title="材料催交" %>

<%@ Register Src="Controls/ShowInIndex.ascx" TagName="ShowInIndex" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="width:950px; background-color:#FFFFFF; padding:20px; margin-left:auto;margin-right:auto; text-align:center; ">
    <uc1:ShowInIndex ID="ShowInIndex1" runat="server" />

</div>



</asp:Content>
