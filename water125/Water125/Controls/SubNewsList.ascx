<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubNewsList.ascx.cs" Inherits="Water125.Controls.SubNewsList" %>
<div align="left" class="loca" id="PagaNavi" runat="server">当前位置test：<a href="../map.html"><font size="3" color="blue">首页test</font></a>&gt;<a href="#"><font size="3" color="blue">一级栏目</font></a>&gt;<a href="#"><font size="3" color="blue">二级栏目</font></a></div>
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
								CommandName="Pager" Text="首 页" ><font size="3" color="blue">首 页</font></asp:linkbutton></div>
        <div class="box" style="width: 52px;float:left;"><asp:linkbutton id="btnPrev" runat="server" OnCommand="NavigateToPage" CommandArgument="Prev"
								CommandName="Pager" Text="上一页"><font size="3" color="blue">上一页</font></asp:linkbutton></div>   
        <div class="box" style="width: 52px;float:left;"><asp:linkbutton id="btnNext" runat="server" OnCommand="NavigateToPage" CommandArgument="Next"
								CommandName="Pager" Text="下一页"><font size="3" color="blue">下一页</font></asp:linkbutton></div>   
        <div class="box" style="width: 52px;float:left;"><asp:linkbutton id="btnLast" runat="server" OnCommand="NavigateToPage" CommandArgument="Last"
								CommandName="Pager" Text="尾 页"><font size="3" color="blue">尾 页</font></asp:linkbutton></div>         
         
          <font size="3">每页 <%=MyPage.ToString()%> 条记录  总共<asp:Label ID="lblRowsCount" runat="server" Text="0"></asp:Label>条记录 当前页</font>
            <asp:DropDownList ID="PageDrop" runat="server"  style="font-size:12px;color:#990000; width:40px">
            </asp:DropDownList><asp:linkbutton id="toPagerIndex" runat="server" OnCommand="NavigateToPage" CommandArgument="toIndex"
								 ForeColor="Blue" CommandName="Pager" Text="跳转"></asp:linkbutton>      
          </div>
      </div>
    </div>    