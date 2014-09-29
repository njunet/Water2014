using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using LTP.Accounts.Bus;
using System.IO;

namespace Water125
{
    public partial class dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION : System.Web.UI.Page
    {
        Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION bll = new Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
               // gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                //gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                Session["strWhereNews"] = "";
                BindData();
                BindDropDownList();
               
           // }
        }

        #region BindData
        private void BindData()
        {

            string strWhere = "";
            if (Session["strWhereNews"] != null && Session["strWhereNews"].ToString() != "")
            {
                strWhere += Session["strWhereNews"].ToString();
            }
            DataSet ds = new DataSet();
            ds = bll.GetList(3,strWhere,"year desc");
            DataTable dtl = ds.Tables[0];
            int rowcount = dtl.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                Label lb = new Label();
                //lb.Height = 600;
                lb.Width=300;
                lb.BorderWidth=1;
                DataRow col = dtl.Rows[i];
                lb.Text ="年份:" + col["year"].ToString() + "<br/>"
                        + "COD排放量(万吨):" + col["COD"].ToString() + "<br/>"
                        + "氨氮排放量（万吨）:" + col["NH3N"].ToString() + "<br/>"
                        + "总氮排放量（万吨）:" + col["TN"].ToString() + "<br/>"
                         + "总磷排放量（万吨）:" + col["TP"].ToString() + "<br/>"
                         + "湖体CDOMn浓度（毫克/升）:" + col["CDO_density"].ToString() + "<br/>"
                         + "湖体TN浓度（毫克/升）:" + col["TN_density"].ToString() + "<br/>"
                         + "湖体TP浓度（毫克/升）:" + col["TP_density"].ToString() + "<br/>"
                         + "综合营养状态指数（无量纲）:" + col["Nutrition_indicators"].ToString() + "<br/>"
                         + "环湖河流CODMn浓度（毫克/升）:" + col["near_COD_density"].ToString() + "<br/>"
                         + "环湖河流TP浓度（毫克/升）:" + col["near_TP_density"].ToString() + "<br/>"
                         + "环湖河流TN浓度（毫克/升）:" + col["near_TN_density"].ToString() + "<br/>"
                         + "环湖河流氨氮浓度（毫克/升）:" + col["near_NH3N_density"].ToString() + "<br/>"
                         + "Ⅲ类以上地表水比例（%）:" + col["Grade3_water_percent"].ToString() + "<br/>"
                         + "劣Ⅴ类地表水比例（%）:" + col["Grade5_water_percent"].ToString() + "<br/>"
                         + "单位GDP的COD排放量（千克/万元）:" + col["COD_GDP"].ToString() + "<br/>"
                         + "单位GDP的氨氮排放量（千克/万元）:" + col["NH3N_GDP"].ToString() + "<br/>"
                         + "城镇污水处理率（%）:" + col["Sewage_Treatment_Rate"].ToString() + "<br/>"
                         + "农田化肥施用强度（千克/公顷）:" + col["Fertilizer_intensity"].ToString() + "<br/>"
                         + "环保投入占GDP的比重（%）:" + col["Environmental_investment_GDP"].ToString() + "<br/>"
                         + "公众对环境满意率（%）:" + col["Public_satisfaction"].ToString() + "<br/>"
                         + "单位GDP水耗（立方米/万元）:" + col["Water_consumption_GDP"].ToString() + "<br/>"
                         + "GDP实际增量（万元）:" + col["GDP_Increment"].ToString() + "<br/>"
                         + "人均地区生产总值（元）:" + col["GDP_per_capita"].ToString() + "<br/>"
                         + "第一产业占GDP比重（%）:" + col["Primary_Industry_GDP"].ToString() + "<br/>"
                         + "第二产业占GDP比重（%）:" + col["Secondary_industry_GDP"].ToString() + "<br/>"
                         + "第三产业占GDP比重（%）:" + col["Tertiary_Industry_GDP"].ToString() + "<br/>"
                         + "人口密度（人/平方公里）:" + col["population_density"].ToString() + "<br/>"
                         + "城市化率（%）:" + col["Urbanization_rate"].ToString() + "<br/>"
                         + "<a href='dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Modify.aspx?id="+col["id"].ToString()+"'>修改</a>"
                         + "&nbsp;&nbsp;&nbsp;<a href='dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Delete.aspx?id=" + col["id"].ToString() + "'>删除</a>";
                this.Panel1.Controls.Add(lb);

            }
            
        }
        #endregion

      
       

        #region gridView事件
        protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //页导航
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                TableRow row = e.Row.Controls[0].Controls[0].Controls[0] as TableRow;
                foreach (TableCell cell in row.Cells)
                {
                    Control lb = cell.Controls[0];
                    if (lb is Label)
                    {
                        Label lblpage = (Label)lb;
                        lblpage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#e78a29");
                        lblpage.Font.Bold = true;
                        lblpage.Text = "[" + lblpage.Text + "]";
                        //((Label)lb).Font.Size = new FontUnit("40px");
                    }
                    else
                        if (lb is LinkButton)
                        {
                            LinkButton lblpage = (LinkButton)lb;
                            lblpage.Font.Bold = true;
                            lblpage.Text = "[" + lblpage.Text + "]";
                        }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string title = Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString();
                //string bgcolor = Application[Session["Style"].ToString() + "xtable_bgcolor"].ToString();
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='" + title + "';this.style.cursor='hand';");
                //当鼠标移走时还原该行的背景色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            }

        }

      
        #endregion


        #region btn_Search
        protected void btn_Search_Click(object sender, ImageClickEventArgs e)
        {
            string year = this.ddlYear.SelectedItem.Value.ToString();

            string strsql = "";
            if (this.ddlYear.SelectedIndex > 0)
            {
                strsql += " and (year=" + this.ddlYear.DataValueField + ")";
            }
            else
            {
                strsql += "";
            }
            
            if (strsql != "")
            {
                Session["strWhereNews"] = " (1=1) " + strsql;
            }
            else
            {
                Session["strWhereNews"] = "";
            }
            BindData();
        }
        #endregion

        protected void BindDropDownList()
        {
            Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION EvaluationBll = new Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION();
            string strWhere = "";
            if (Session["strWhereNews"] != null && Session["strWhereNews"].ToString() != "")
            {
                strWhere += Session["strWhereNews"].ToString();
            }
            DataSet yearDs = new DataSet();
            yearDs = EvaluationBll.GetYearList();
            DataTable yearDt = yearDs.Tables[0];//读取数据库站点信息表

            ddlYear.DataSource = yearDt;//下拉菜单绑定数据源
            ddlYear.DataTextField = "year";
            ddlYear.DataValueField = "year";//更新表格
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("请选择", "0"));
        }
        protected void ddlOnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlYear.DataValueField = ddlYear.SelectedValue;

        }
       

      
    }
}