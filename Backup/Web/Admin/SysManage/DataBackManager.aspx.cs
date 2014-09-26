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
using LTP.Common;
using System.Drawing;
using System.IO;



namespace Maticsoft.Web.Admin.SysManage
{
    public partial class DataBackManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                grid.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                grid.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                int pageIndex = 1;
                if (Request.Params["page"] != null && Request.Params["page"].ToString() != "")
                {
                    Session["pageNewsClass"] = Convert.ToInt32(Request.Params["page"]);
                    pageIndex = Convert.ToInt32(Request.Params["page"]);
                }
                else
                {
                    if (Session["pageNewsClass"] != null && Session["pageNewsClass"].ToString() != "")
                    {
                        pageIndex = Convert.ToInt32(Session["pageNewsClass"]);
                    }
                    else
                    {
                        pageIndex = 1;
                        Session["pageNewsClass"] = 1;
                    }
                }
                dataBind(pageIndex);



            }





        }






        private void dataBind(int pageIndex)
        {


            //绑定Gridview         
            DataSet ds = new DataSet();
            DirectoryInfo Dinfo = new DirectoryInfo(ConfigurationSettings.AppSettings["DBBackupPath"]);

            this.grid.DataSource = Dinfo.GetFiles();
            this.grid.DataBind();
            int record_Count = this.grid.Rows.Count;
            int page_Size = grid.PageSize;
            int totalPages = int.Parse(Math.Ceiling((double)record_Count / page_Size).ToString());
            if (totalPages > 0)
            {
                if ((pageIndex + 1) > totalPages)
                    pageIndex = totalPages - 1;
            }
            else
            {
                pageIndex = 0;
            }
            grid.PageIndex = pageIndex;
            grid.DataBind();
            int page_Count = grid.PageCount;
            int page_Current = pageIndex + 1;

            Page011.Record_Count = record_Count;
            Page011.Page_Count = page_Count;
            Page2.Page_Count = page_Count;

            Page011.Page_Size = page_Size;
            Page2.Page_Size = page_Size;
            Page011.Page_Current = page_Current;
            Page2.Page_Current = page_Current;





        }
        protected void grid_RowCreated(object sender, GridViewRowEventArgs e)
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

        protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string StrDbPath = ConfigurationSettings.AppSettings["DBBackupPath"];
            //string strpath = StrUpPath + "Temp/";
            //string strCopypath = StrUpPath + "APic/";
            //    string strpath = Server.MapPath("~/upload/db/");
            if (e.CommandName == "DeleteById")
            {

                string name = e.CommandArgument.ToString();
                if (File.Exists(StrDbPath + name))
                {
                    File.Delete(StrDbPath + name);
                    LTP.Common.MessageBox.Show(this, "删除成功");
                }
                Response.Redirect("DataBackManager.aspx");

            }


        }









    }
}





