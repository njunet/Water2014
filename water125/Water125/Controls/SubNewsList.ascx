<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubNewsList.ascx.cs" Inherits="Water125.Controls.SubNewsList" %>
<div align="left" class="loca" id="PagaNavi" runat="server">��ǰλ��test��<a href="../map.html"><font size="3" color="blue">��ҳtest</font></a>&gt;<a href="#"><font size="3" color="blue">һ����Ŀ</font></a>&gt;<a href="#"><font size="3" color="blue">������Ŀ</font></a></div>
    <div align="left" class="article_list" > 
      <ul > 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
              BorderWidth="0px" ShowHeader="False" CellPadding="0" AllowPaging="True"
              Width="1631px">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                          <li style="#0000FF"> <a  href='News.aspx?id=<%# Eval("Newsid") %>' target="_blank"><font size="3" color="blue"><%# FormatString(Eval("heading").ToString())%></font></a><font size="3"> <%# Eval("IssueDate") %> (<%# Eval("Frequency") %>)<%# Eval("Istop").ToString()=="1"?"<img src='images/index_59.gif' width='34' height='16' align='absmiddle'/>":""%></font></li>      
                    </ItemTemplate>                  
                </asp:TemplateField>
            </Columns>        
            <PagerTemplate>
                &nbsp;
            </PagerTemplate>
        </asp:GridView>        
      </ul>
       <div>
        <div class="page">
            <br />
            <br />
            <br />
            <br />
            <br />
        <div class="box" style="width: 52px;float:left;"><asp:linkbutton id="btnFirst" runat="server" OnCommand="NavigateToPage" CommandArgument="First"
								CommandName="Pager" Text="�� ҳ" ><font size="3" color="blue">�� ҳ</font></asp:linkbutton></div>
        <div class="box" style="width: 52px;float:left;"><asp:linkbutton id="btnPrev" runat="server" OnCommand="NavigateToPage" CommandArgument="Prev"
								CommandName="Pager" Text="��һҳ"><font size="3" color="blue">��һҳ</font></asp:linkbutton></div>   
        <div class="box" style="width: 52px;float:left;"><asp:linkbutton id="btnNext" runat="server" OnCommand="NavigateToPage" CommandArgument="Next"
								CommandName="Pager" Text="��һҳ"><font size="3" color="blue">��һҳ</font></asp:linkbutton></div>   
        <div class="box" style="width: 52px;float:left;"><asp:linkbutton id="btnLast" runat="server" OnCommand="NavigateToPage" CommandArgument="Last"
								CommandName="Pager" Text="β ҳ"><font size="3" color="blue">β ҳ</font></asp:linkbutton></div>         
         
          <font size="3">ÿҳ <%=MyPage.ToString()%> ����¼  �ܹ�<asp:Label ID="lblRowsCount" runat="server" Text="0"></asp:Label>����¼ ��ǰҳ</font>
            <asp:DropDownList ID="PageDrop" runat="server"  style="font-size:12px;color:#990000; width:40px">
            </asp:DropDownList><asp:linkbutton id="toPagerIndex" runat="server" OnCommand="NavigateToPage" CommandArgument="toIndex"
								 ForeColor="Blue" CommandName="Pager" Text="��ת"></asp:linkbutton>      
          </div>
      </div>
    </div>    