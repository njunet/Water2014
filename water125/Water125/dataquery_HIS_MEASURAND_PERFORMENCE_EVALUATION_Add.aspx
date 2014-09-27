<%@ Page Title="" Language="C#" MasterPageFile="~/IndexWaterInfo.Master" AutoEventWireup="true" CodeBehind="dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Add.aspx.cs" Inherits="Water125.dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div align="center">
            <table cellspacing="0" cellpadding="5" width="600" border="0" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'
                bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                <tr>
                    <td>
                        <table cellspacing="0" class="table_bordercolor" cellpadding="5" width="100%" border="1"
                            bgcolor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>' bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>'
                            bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>'>
                            <tr>
                                <td height="22" bgcolor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>'
                                    align="left">
                                    信息添加，请详细填写下列信息，带有 <font class="form_requestcolor">*</font> 的必须填写。</td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <asp:TextBox ID="Record_id" runat="server" Visible="False"></asp:TextBox>
                                        </tr>
                                        <tr>
                                            <td height="25" width="35%" align="right">
                                                年份：
                                            </td>
                                            <td height="25" width="*" align="left">
                                                <asp:TextBox ID="Year" runat="server" Width="200px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Year"
                                                    ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                                                    </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                COD排放量(万吨)：
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="COD" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                氨氮排放量（万吨）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="NH3N" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                总氮排放量（万吨）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="TN" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                总磷排放量（万吨）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="TP" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                湖体CDOMn浓度（毫克/升）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="CDO_density" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                湖体TN浓度（毫克/升）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="TN_density" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                湖体TP浓度（毫克/升）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="TP_density" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                综合营养状态指数（无量纲）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Nutrition_indicators" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                环湖河流CODMn浓度（毫克/升）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="near_COD_density" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                环湖河流TP浓度（毫克/升）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="near_TP_density" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                环湖河流TN浓度（毫克/升）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="near_TN_density" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                         <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                环湖河流氨氮浓度（毫克/升）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="near_NH3N_density" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                Ⅲ类以上地表水比例（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Grade3_water_percent" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                劣Ⅴ类地表水比例（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Grade5_water_percent" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                单位GDP的COD排放量（千克/万元）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="COD_GDP" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                单位GDP的氨氮排放量（千克/万元）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="NH3N_GDP" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                城镇污水处理率（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Sewage_Treatment_Rate" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                农田化肥施用强度（千克/公顷）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Fertilizer_intensity" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                环保投入占GDP的比重（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Environmental_investment_GDP" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                公众对环境满意率（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Public_satisfaction" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                单位GDP水耗（立方米/万元）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Water_consumption_GDP" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                GDP实际增量（万元）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="GDP_Increment" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                         <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                人均地区生产总值（元）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="GDP_per_capita" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                第一产业占GDP比重（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Primary_Industry_GDP" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                第二产业占GDP比重（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Secondary_industry_GDP" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                第三产业占GDP比重（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Tertiary_Industry_GDP" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                人口密度（人/平方公里）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="population_density" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right" style="height: 25px">
                                                城市化率（%）:
                                            </td>
                                            <td width="*" align="left" style="height: 25px">
                                                <asp:TextBox ID="Urbanization_rate" runat="server" Width="200px"></asp:TextBox>
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="22">
                                    <div align="center">
                                        <asp:Button ID="btnAdd" runat="server" Text="· 提交 ·" OnClick="btnAdd_Click"></asp:Button><font
                                            face="宋体">&nbsp;</font>
                                        <a href='dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION.aspx?'>返回</a>
                                        </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
