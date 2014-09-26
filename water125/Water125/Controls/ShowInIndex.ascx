<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowInIndex.ascx.cs" Inherits="Water125.Controls.ShowInIndex1" %>
<div align="left" class="loca" id="PagaNavi" runat="server">当前位置：<a href="index.aspx">首页</a>&gt;<a href="#">材料催交</a>&gt;</div>
    <div class="article_list"> 
      <ul> 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="4" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" Width="95%" OnDataBound="BindReceiver">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="序号" Visible="False" />
                   <asp:BoundField DataField="Name" HeaderText="项目名称" />
                <asp:BoundField DataField="Enddate" HeaderText="提交时间" DataFormatString="{0:d}" >
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Number" HeaderText="提交份数" />
               
                <asp:TemplateField HeaderText="申报网址">
                    <ItemTemplate>
                        <a href='<%#Eval("Address")%>' target="_blank"><%#Eval("Address")%></a>
                    </ItemTemplate>                  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="已提交单位">
                    <ItemTemplate>
                        <asp:Label ID="Label_Receiver" runat="server" Text=""></asp:Label>     
                    </ItemTemplate>                  
                    <ItemStyle Width="120px" />
                </asp:TemplateField>
            </Columns>        
            <PagerTemplate>
                &nbsp;
            </PagerTemplate>
            <RowStyle BackColor="White" ForeColor="#003399" />
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        </asp:GridView>        
      </ul>
       <div>
        <div align="center" class="page">
        <span class="box"><asp:linkbutton id="btnFirst" runat="server" OnCommand="NavigateToPage" CommandArgument="First"
								CommandName="Pager" Text="首 页">首 页</asp:linkbutton></span>
        <span class="box"><asp:linkbutton id="btnPrev" runat="server" OnCommand="NavigateToPage" CommandArgument="Prev"
								CommandName="Pager" Text="上一页">上一页</asp:linkbutton></span>   
        <span class="box"><asp:linkbutton id="btnNext" runat="server" OnCommand="NavigateToPage" CommandArgument="Next"
								CommandName="Pager" Text="下一页">下一页</asp:linkbutton></span>   
        <span class="box"><asp:linkbutton id="btnLast" runat="server" OnCommand="NavigateToPage" CommandArgument="Last"
								CommandName="Pager" Text="尾 页">尾 页</asp:linkbutton></span>         
         
          每页 <%=MyPage.ToString()%> 条记录  总共<asp:Label ID="lblRowsCount" runat="server" Text="0"></asp:Label>条记录 当前页
            <asp:DropDownList ID="PageDrop" runat="server"  style="font-size:12px;color:#990000; width:40px">
            </asp:DropDownList><asp:linkbutton id="toPagerIndex" runat="server" OnCommand="NavigateToPage" CommandArgument="toIndex"
								CommandName="Pager" Text="跳转"></asp:linkbutton>      
          </div>
      </div>
</div>