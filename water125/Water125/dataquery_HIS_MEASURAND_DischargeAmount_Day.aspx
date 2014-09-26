<%@ Page Language="C#" MasterPageFile="~/IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="dataquery_HIS_MEASURAND_DischargeAmount_Day.aspx.cs" Inherits="Maticsoft.Web.dataquery_HIS_MEASURAND_DischargeAmount_Day" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="5" width="1200" border="0">
            <%--<table cellspacing="0" cellpadding="5" width="700" border="0">--%>
                <tr>
                    <td height="40" align="left">
                        &nbsp;&nbsp;&nbsp; 快速查询：
                        站点名称：
                        <asp:DropDownList ID="ddlStationName" runat="server" Width="10%" ToolTip="关键字" OnSelectedIndexChanged="ddlOnSelectedIndexChanged"></asp:DropDownList>&nbsp;                 

                        <%--<asp:Label ID="Label2" runat="server">日期：</asp:Label>
                           <asp:TextBox ID="txtdate" runat="server" BorderStyle="Groove" Width="130px" 
                            ToolTip="日期格式:YYYY-MM-DD，双击选择日期" 
                            ondblclick="WdatePicker({startDate:'2013-01-23',dateFmt:'yyyy-MM-dd'})" 
                            EnableViewState="false" autocomplete="off" ></asp:TextBox>--%>
                         <asp:Label ID="Label2" runat="server">起始时间：</asp:Label>
                        <input id="D411" class="Wdate" runat="server" type="text" onclick="WdatePicker({dateFmt:'yyyy/MM/dd'})"/> 

                        <asp:Label ID="Label3" runat="server">终止时间：</asp:Label>
                        <input id="D412" class="Wdate" runat="server" type="text" onclick="WdatePicker({dateFmt:'yyyy/MM/dd'})"/>

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
                            AllowPaging="True" AllowSorting="True" OnRowCreated="gridView_RowCreated" OnPageIndexChanging="gridView_PageIndexChanging"
                            OnRowDataBound="gridView_RowDataBound" CellPadding="5" BorderWidth="1px" PageSize="15" OnSorting="gridView_Sorting"
                            >
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="站点号" SortExpression="id" />  
                                <asp:BoundField DataField="station_name" HeaderText="站点名称" SortExpression="station_name" /> 
                                <asp:BoundField DataField="date" HeaderText="日期" SortExpression="date"/>        
                                <asp:BoundField DataField="CODMn" HeaderText="高锰酸钾耗氧量(t)" SortExpression="CODMn"/>  
                                <asp:BoundField DataField="NH3_N" HeaderText="氨氮（t）" SortExpression="NH3_N"/>
                                <asp:BoundField DataField="TP" HeaderText="总磷（t）" SortExpression="TP"/>
                                <asp:BoundField DataField="TN" HeaderText="总氮（t）" SortExpression="TN"/>
                                <asp:BoundField DataField="flow" HeaderText="流量（m3/h）" SortExpression="flow"/>
                                 
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
                        <asp:Button ID="buttonToImage" runat="server" OnClick="buttonToImageClick" Text="日排放量图" />
                    </td>
                </tr>
            </table>  
</asp:Content>
