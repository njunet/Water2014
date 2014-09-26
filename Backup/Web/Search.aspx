<%@ Page Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Maticsoft.Web.Search" Title="信息检索" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table width="990" border="0" align="center" cellpadding="0" cellspacing="10" bgcolor="#ffffff">
  <tr><td>
  <div id="searchInfo" runat="server"></div>
  
  <div class="article_list"> 
      <ul> 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px" ShowHeader="False" CellPadding="0">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                          <li><span class='graytxt'>[ <%# Eval("ClassDesc")%> ]</span> <a  href='news.aspx?id=<%# Eval("Newsid") %>' target="_blank"><%# Eval("heading").ToString()%></a> <%# Eval("IssueDate") %> (<%# Eval("Frequency") %>)</li>      
                    </ItemTemplate>                  
                </asp:TemplateField>
            </Columns>        
           
        </asp:GridView>        
      </ul>
      
      </div>
  
  </td></tr></table>
</asp:Content>
