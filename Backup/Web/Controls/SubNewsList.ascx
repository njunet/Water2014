<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubNewsList.ascx.cs" Inherits="Maticsoft.Web.Controls.SubNewsList" %>
<div align="left" class="loca" id="PagaNavi" runat="server">��ǰλ�ã�<a href="index.aspx">��ҳ</a>&gt;<a href="#">һ����Ŀ</a>&gt;<a href="#">������Ŀ</a></div>
    <div class="article_list"> 
      <ul> 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px" ShowHeader="False" CellPadding="0" AllowPaging="True">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                          <li> <a  href='news.aspx?id=<%# Eval("Newsid") %>' target="_blank"><%# FormatString(Eval("heading").ToString())%></a> <%# Eval("IssueDate") %> (<%# Eval("Frequency") %>)<%# Eval("Istop").ToString()=="1"?"<img src='images/index_59.gif' width='34' height='16' align='absmiddle'/>":""%></li>      
                    </ItemTemplate>                  
                </asp:TemplateField>
            </Columns>        
            <PagerTemplate>
                &nbsp;
            </PagerTemplate>
        </asp:GridView>        
      </ul>
       <div>
        <div align="center" class="page">
        <div class="box"><asp:linkbutton id="btnFirst" runat="server" OnCommand="NavigateToPage" CommandArgument="First"
								CommandName="Pager" Text="�� ҳ">�� ҳ</asp:linkbutton></div>
        <div class="box"><asp:linkbutton id="btnPrev" runat="server" OnCommand="NavigateToPage" CommandArgument="Prev"
								CommandName="Pager" Text="��һҳ">��һҳ</asp:linkbutton></div>   
        <div class="box"><asp:linkbutton id="btnNext" runat="server" OnCommand="NavigateToPage" CommandArgument="Next"
								CommandName="Pager" Text="��һҳ">��һҳ</asp:linkbutton></div>   
        <div class="box"><asp:linkbutton id="btnLast" runat="server" OnCommand="NavigateToPage" CommandArgument="Last"
								CommandName="Pager" Text="β ҳ">β ҳ</asp:linkbutton></div>         
         
          ÿҳ <%=MyPage.ToString()%> ����¼  �ܹ�<asp:Label ID="lblRowsCount" runat="server" Text="0"></asp:Label>����¼ ��ǰҳ
            <asp:DropDownList ID="PageDrop" runat="server"  style="font-size:12px;color:#990000; width:40px">
            </asp:DropDownList><asp:linkbutton id="toPagerIndex" runat="server" OnCommand="NavigateToPage" CommandArgument="toIndex"
								CommandName="Pager" Text="��ת"></asp:linkbutton>      
          </div>
      </div>
    </div>    