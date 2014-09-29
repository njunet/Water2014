<%@ Page Title="" Language="C#" MasterPageFile="~/IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION.aspx.cs" Inherits="Water125.dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table cellspacing="0" cellpadding="5" width="1200" border="0">
            <%--<table cellspacing="0" cellpadding="5" width="700" border="0">--%>
                <tr>
                    <td height="40" align="left" style="width: 274px">
                        &nbsp;&nbsp;&nbsp; 快速查询：
                        年份：
                        <asp:DropDownList ID="ddlYear" runat="server" Width="80px" ToolTip="关键字" OnSelectedIndexChanged="ddlOnSelectedIndexChanged"></asp:DropDownList>&nbsp;                              
                        <asp:ImageButton ID="btn_Search" runat="server" ImageUrl="Admin/images/button_search.GIF"
                            ToolTip="快速检索" OnClick="btn_Search_Click"></asp:ImageButton>
                    </td>
                    <td height="40" align="left" style="width: 80px">
                    <%--<button onclick="href()">添加</button>--%>
                    <a href='dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Add.aspx?'>添加</a>
                    </td>
                    
                </tr>
            </table>     
            
            <table cellspacing="0" cellpadding="5" width="1200" border="0">                
                <tr>
                    <td bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>' style="text-align:left">
                        <asp:Panel ID="Panel1" runat="server"  >
                            <%--<asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White" 
                                Height="300px" Width="150px" >ttt</asp:Label>
                       
                            <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="White" 
                                Height="300px" Width="150px" >xxxx</asp:Label>
                                  <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="White" 
                                Height="300px" Width="150px" ></asp:Label>
                  
                    <asp:Label ID="Label4" runat="server" Text="Label" ForeColor="White" 
                                Height="300px" Width="150px" >xxxx</asp:Label>--%>
                  
                        </asp:Panel>
                       
                    </td>
                </tr>
            </table>  
<script type="text/javascript" language="javascript">
    function href() {
        //window.location.href = "dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Add.aspx";
        window.open("dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Add.aspx");
//        window.location.href = "Main.aspx";
    }
</script>
</asp:Content>
