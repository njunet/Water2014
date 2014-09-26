<%@ Page Language="C#" MasterPageFile="~/IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="dataquery_MEASURAND_STATION.aspx.cs" Inherits="Maticsoft.Web.waterInfo.dataquery_MEASURAND_STATION" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="5" width="1200" border="0">
                <tr>
                    <td height="40" align="left">
                        &nbsp;&nbsp;&nbsp; 快速查询：
                        站点名称：
                        <asp:DropDownList ID="ddlStationName" runat="server" Width="10%" ToolTip="关键字" OnSelectedIndexChanged="ddlOnSelectedIndexChanged"></asp:DropDownList>&nbsp;

                        <asp:ImageButton ID="btn_Search" runat="server" ImageUrl="Admin/images/button_search.GIF"
                            ToolTip="快速检索" OnClick="btn_Search_Click"></asp:ImageButton>
                    </td>
                </tr>
            </table>
            
            <table cellspacing="0" cellpadding="5" width="1200" border="0">                
                <tr>
                <td align="left">○页次：<asp:Label ID="lblCurrentPage" runat="server" ForeColor="#e78a29"></asp:Label>页/<asp:Label ID="lblPageCount"
                        runat="server"></asp:Label>页，共<asp:Label ID="lblRowsCount" runat="server" ForeColor="#e78a29"></asp:Label>条记录
                        </td>
                <td align="right">
                [<asp:linkbutton id="btnFirst" runat="server" OnCommand="NavigateToPage" CommandArgument="First"
								CommandName="Pager" Text="首 页">首 页</asp:linkbutton>]
				[<asp:linkbutton id="btnPrev" runat="server" OnCommand="NavigateToPage" CommandArgument="Prev"
								CommandName="Pager" Text="上一页">上一页</asp:linkbutton>]
				[<asp:linkbutton id="btnNext" runat="server" OnCommand="NavigateToPage" CommandArgument="Next"
								CommandName="Pager" Text="下一页">下一页</asp:linkbutton>]
				[<asp:linkbutton id="btnLast" runat="server" OnCommand="NavigateToPage" CommandArgument="Last"
								CommandName="Pager" Text="尾 页">尾 页</asp:linkbutton>]
                </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="5" width="1200" border="0">                
                <tr>
                    <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
                        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" Width="100%"
                            AllowPaging="false" AllowSorting="True" OnRowCreated="gridView_RowCreated" OnPageIndexChanging="gridView_PageIndexChanging"
                            OnRowDataBound="gridView_RowDataBound" CellPadding="5" BorderWidth="1px" PageSize="15" OnSorting="gridView_Sorting"
                            >
                            <Columns> 
                                <asp:BoundField DataField="id" HeaderText="站点号" SortExpression="id" /> 
                                <asp:BoundField DataField="station_name" HeaderText="站点名称" SortExpression="station_name" /> 
                                <asp:BoundField DataField="river_name" HeaderText="河道名" SortExpression="river_name" />        
                               <%-- <asp:BoundField DataField="state" HeaderText="状态" SortExpression="state" />  --%>
                                <asp:BoundField DataField="posx" HeaderText="经度" SortExpression="posx" />
                                <asp:BoundField DataField="posy" HeaderText="纬度" SortExpression="posy" />
                                <%--<asp:BoundField DataField="dynamic" HeaderText="是否为自动站" SortExpression="dynamic" />
                                <asp:BoundField DataField="procince_city" HeaderText="所在省市" SortExpression="procince_city" />--%>                               
                                <asp:BoundField DataField="comments" HeaderText="备注信息" SortExpression="comments" />       
                                
                                <asp:HyperLinkField HeaderText="修改" DataNavigateUrlFields="id" DataNavigateUrlFormatString="modify.aspx?id={0}"
                                    Text="修改" Visible="False" />
                                <asp:TemplateField HeaderText="删除" ShowHeader="False" Visible="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                            OnClientClick='return confirm("您真的要删除这条记录吗？")' Text="删除"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        </asp:GridView>
                        <asp:Label ID="Label1" runat="server" Visible="False" ForeColor="Red">没有数据！！</asp:Label>
                    </td>
                </tr>
            </table>           
</asp:Content>
