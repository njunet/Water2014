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
namespace Maticsoft.Web
{
    public partial class dataquery_HIS_MEASURAND_DischargeAmount_Month : System.Web.UI.Page
    {
        //int PermId_Modify = 56;
        //int PermId_Delete = 57;
        Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Month bll = new Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Month();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                Session["strWhereNews"] = "";
                BindData();
                BindDropDownList();
            }
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
            //暂时显示100条记录，数据太多内存不够
            //ds = bll.GetList(100, strWhere, "systime desc");
            ds = bll.GetList(strWhere);

            DataView dv = ds.Tables[0].DefaultView;
            gridView.DataSource = dv;
            gridView.DataBind();

            //分页
            int rows_Count = ds.Tables[0].Rows.Count;
            int page_Size = gridView.PageSize;
            int page_Count = gridView.PageCount;
            int page_Current = gridView.PageIndex + 1;

            lblRowsCount.Text = rows_Count.ToString();
            lblPageCount.Text = page_Count.ToString();
            lblCurrentPage.Text = page_Current.ToString();


            #region 显示页导航

            btnFirst.Enabled = true;
            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            if (gridView.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if (gridView.PageCount == 1)
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            else if (gridView.PageIndex == gridView.PageCount - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }

            #endregion

        }
        #endregion

        #region 页导航事件
        public void NavigateToPage(object sender, CommandEventArgs e)
        {
            btnFirst.Enabled = true;
            btnPrev.Enabled = true;
            btnNext.Enabled = true;
            btnLast.Enabled = true;
            string pageinfo = e.CommandArgument.ToString();
            switch (pageinfo)
            {
                case "Prev":
                    if (gridView.PageIndex > 0)
                    {
                        gridView.PageIndex -= 1;

                    }
                    break;
                case "Next":
                    if (gridView.PageIndex < (gridView.PageCount - 1))
                    {
                        gridView.PageIndex += 1;

                    }
                    break;
                case "First":
                    gridView.PageIndex = 0;
                    break;
                case "Last":
                    gridView.PageIndex = gridView.PageCount - 1;
                    break;
            }
            if (gridView.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if (gridView.PageCount == 1)
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            else if (gridView.PageIndex == gridView.PageCount - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            BindData();
        }
        #endregion

        #region btn_Search
        protected void btn_Search_Click(object sender, ImageClickEventArgs e)
        {
            string Name = this.ddlStationName.SelectedItem.Value.ToString();
            string begindate = this.D411.Value.ToString();
            string overdate = this.D412.Value.ToString();

            string strsql = "";
            if (this.ddlStationName.SelectedIndex > 0)
            {
                strsql += " and (id=" + this.ddlStationName.DataValueField + ")";
            }
            else
            {
                strsql += "";
            }
            if (begindate != "")
            {
                strsql += " and (YYYY_MM >='" + begindate + "')";
            }
            if (overdate != "")
            {
                strsql += " and (YYYY_MM <='" + overdate + "')";
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

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        { }

        protected void gridView_RowDeleting(object sender, GridViewRowEventArgs e)
        { }
        protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string strWhere = "";
            if (Session["strWhereNews"] != null && Session["strWhereNews"].ToString() != "")
            {
                strWhere += Session["strWhereNews"].ToString();
            }
            DataSet ds = new DataSet();
            ds = bll.GetList(strWhere);
            DataView dv = ds.Tables[0].DefaultView;
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = "desc";
            }
            else
            {
                if (ViewState["SortDirection"].ToString() == "asc")
                {
                    ViewState["SortDirection"] = "desc";
                }
                else
                {
                    ViewState["SortDirection"] = "asc";
                }
            }
            dv.Sort = e.SortExpression + " " + ViewState["SortDirection"].ToString();
            gridView.DataSource = dv;
            gridView.DataBind();


        }
        #endregion

        protected void BindDropDownList()
        {
            Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Month stationBll = new BLL.HIS_MEASURAND_DischargeAmount_Month();
            string strWhere = "";
            if (Session["strWhereNews"] != null && Session["strWhereNews"].ToString() != "")
            {
                strWhere += Session["strWhereNews"].ToString();
            }
            DataSet stationDs = new DataSet();
            stationDs = stationBll.GetList(strWhere, "systime desc");
            DataTable stationDt = stationDs.Tables[0];//读取数据库站点信息表

            ddlStationName.DataSource = stationDt;//下拉菜单绑定数据源
            ddlStationName.DataTextField = "station_name";
            ddlStationName.DataValueField = "id";//更新表格
            ddlStationName.DataBind();
            ddlStationName.Items.Insert(0, new ListItem("请选择", "0"));
        }
        protected void ddlOnSelectedIndexChanged(object sender, EventArgs e)
        {
            ddlStationName.DataValueField = ddlStationName.SelectedValue;

        }
        protected void buttonToImageClick(object sender, EventArgs e)
        {
            //string stationId = ddlStationName.DataValueField.ToString();
            Response.Redirect("Monthly_Discharge_Amount_new.aspx");
        }
    }
}
