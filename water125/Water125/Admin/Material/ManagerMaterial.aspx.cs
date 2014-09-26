using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using LTP.Accounts.Bus;
using FreeTextBoxControls;



namespace Maticsoft.Web.Admin.Material
{
    public partial class ManagerMaterial : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.ImageButton ImageButton1;
        protected void Page_Load(object sender, EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            if (!Page.IsPostBack)
            {
                

                DataGrid1.BorderWidth = Unit.Pixel(1);
                DataGrid1.CellPadding = 4;
                DataGrid1.CellSpacing = 0;
                DataGrid1.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                DataGrid1.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());


                if (Session["AccountsAdminKey"] != null && Session["AccountsAdminKey"].ToString() != "")
                {
                    TextBox1.Text = Session["AccountsAdminKey"].ToString();
                }
                if (Session["AccountsAdminPage"] != null && Session["AccountsAdminPage"].ToString() != "")
                {
                    DataGrid1.CurrentPageIndex = Convert.ToInt32(Session["AccountsAdminPage"]);
                }

                dataBind();
            }
        }

        protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            dataBind();
        }

        //进行数据绑定的方法
        protected void dataBind()
        {
            this.DataGrid1.AllowPaging = true;
            this.DataGrid1.PageSize = 11;
            DataSet ds = new DataSet();
            Maticsoft.BLL.W_Material bll = new Maticsoft.BLL.W_Material();
            string key = this.TextBox1.Text.Trim();
            Session["AccountsAdminKey"] = key;
            if (key == "")
            {
                ds = bll.GetAllList();
               
                
               
            }
            else
                ds = bll.GetMaterialByType(key);
            //将数据库里面Outdisplay以前的空值转化为否：修改人学生
           
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                int id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                if (ds.Tables[0].Rows[i]["Outdisplay"].ToString() == "")
                {

                    bll.NoReleaseList(id);
                }

            }
            



            int pageIndex = this.DataGrid1.CurrentPageIndex;
            Session["AccountsAdminPage"] = pageIndex;
            DataGrid1.DataSource = ds.Tables[0].DefaultView;
            int record_Count = ds.Tables[0].Rows.Count;
            int page_Size = DataGrid1.PageSize;
            int totalPages = int.Parse(Math.Ceiling((double)record_Count / page_Size).ToString());
            if (totalPages > 0)
            {
                if (pageIndex > totalPages - 1)
                    pageIndex = totalPages - 1;
            }
            else
            {
                pageIndex = 0;
            }
            DataGrid1.CurrentPageIndex = pageIndex;
            DataGrid1.DataBind();



            //显示数量
            if (this.DataGrid1.CurrentPageIndex == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if (this.DataGrid1.PageCount == 1)
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            else if (this.DataGrid1.CurrentPageIndex == this.DataGrid1.PageCount - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            this.lblpagesum.Text = totalPages.ToString();
            this.lblpage.Text = (pageIndex + 1).ToString();
            this.lblrowscount.Text = record_Count.ToString();
        }
       

        #region NavigateToPage
        protected string FormatString(string str)
        {
            if (str.Length > 10)
            {
                str = str.Substring(0, 9) + "...";
            }
            return str;
        }
        //导航按钮事件
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
                    if (this.DataGrid1.CurrentPageIndex > 0)
                    {
                        this.DataGrid1.CurrentPageIndex -= 1;

                    }
                    break;
                case "Next":
                    if (this.DataGrid1.CurrentPageIndex < (this.DataGrid1.PageCount - 1))
                    {
                        this.DataGrid1.CurrentPageIndex += 1;

                    }
                    break;
                case "First":
                    this.DataGrid1.CurrentPageIndex = 0;
                    break;
                case "Last":
                    this.DataGrid1.CurrentPageIndex = this.DataGrid1.PageCount - 1;
                    break;
            }
            if (this.DataGrid1.CurrentPageIndex == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if (this.DataGrid1.PageCount == 1)
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            else if (this.DataGrid1.CurrentPageIndex == this.DataGrid1.PageCount - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            dataBind();
        }

        #endregion

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        protected void InitializeComponent()
        {
            this.BtnSearch.Click += new System.Web.UI.ImageClickEventHandler(this.BtnSearch_Click);
            this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
            this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
            this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
            this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

        }
        #endregion

        protected void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {

            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    ImageButton btn = (ImageButton)e.Item.FindControl("BtnDel");
                    btn.Attributes.Add("onclick", "return confirm('你是否确定删除这条记录？');");
                break;
            }

            
        }

        protected void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string btn = e.CommandName;
            switch (btn)
            {
                case "BtnEdit":
                    int Id1 = int.Parse(e.Item.Cells[8].Text.Trim());
                    Response.Redirect("AddMaterial.aspx?Id=" + Id1);
                    break;
                case "BtnDel":
                    int Id2 = int.Parse(e.Item.Cells[8].Text.Trim());
                    Maticsoft.BLL.W_Material bll2 = new Maticsoft.BLL.W_Material();
                    bll2.Delete(Id2);
                    Maticsoft.BLL.W_Receivestate bll3 = new Maticsoft.BLL.W_Receivestate();
                    bll3.Delete(Id2);
                    break;
                case "BtnManager":
                    int Id3 = int.Parse(e.Item.Cells[8].Text.Trim());
                    Response.Redirect("Manager.aspx?Id=" + Id3);                  
                    break;
            }
            dataBind();
        }
        protected void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
            dataBind();

        }

        protected void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Pager)
            {
                foreach (Control c in e.Item.Cells[0].Controls)
                {
                    if (c is Label)
                    {
                        Label lblpage = (Label)c;
                        lblpage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                        lblpage.Font.Bold = true;
                        //lblpage.Text="["+lblpage.Text+"]";//只能设置所点的页面的数字，即当前页数
                        //((Label)c).ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                        //((Label)c).ForeColor = System.Drawing.Color.Green;						
                        break;
                    }
                }


            }
        }

      

      


       
    }
}
