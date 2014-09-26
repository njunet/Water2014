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

namespace Maticsoft.Web.Admin.Material
{
    public partial class AllList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                TreeBind();
                TreeView1.ShowLines = true;//显示连接父节点与子节点间的线条
                TreeView1.ExpandDepth = 1;//控件显示时所展开的层数
                dataBind();
            }
        }
      
        ////材料搜索
        //protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
        //{
           
        //}

        //TreeView的绑定操作
        protected void TreeBind()
        {
            DataSet ds = new DataSet();
            Maticsoft.BLL.W_Receiver bll = new Maticsoft.BLL.W_Receiver();
            ds = bll.GetAllList();
            TreeNode tree1 = new TreeNode("学院信息","0");
            this.TreeView1.Nodes.Add(tree1);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeNode tree2 = new TreeNode(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
                tree1.ChildNodes.Add(tree2);

            }
        
        
        }
        //GridView数据绑定的方法
        protected void dataBind()
        {
            this.DataGrid1.AllowPaging = true;
            this.DataGrid1.PageSize = 11;
            DataSet ds = new DataSet();
            Maticsoft.BLL.W_Receivestate bll = new Maticsoft.BLL.W_Receivestate();
            //string key = this.TextBox1.Text.Trim();
            string treeselect="";
            try
            {
                treeselect = this.TreeView1.SelectedNode.Value;
                Session["SelectedNode"] = this.TreeView1.SelectedNode.Value;
            }
            catch { }
            //Session["AccountsAdminKey"] = key;
            //if (key == 
            if (this.txtKey.Text != "")
            {
                ds = bll.GetMaterial_MaterialName(this.txtKey.Text);
                this.txtKey.Text = "";
            }

            else if (treeselect == "" || treeselect == "0")
                ds = bll.GetMaterial();
            //else
            else
                ds = bll.GetMaterial(this.TreeView1.SelectedNode.Value);
                //ds = bll.GetMaterialByType(key);
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

        //TreeView触发事件
        protected void SelectedList(object sender, EventArgs e)
        {
            this.txtKey.Text = "";
            btnLast.Enabled = true ;
            btnNext.Enabled = true ;
            dataBind();

        }

        //查询操作
        protected void btn_Search_Click(object sender, ImageClickEventArgs e)
        {
            dataBind();


        }

        protected void btn_Relese_Click(object sender, EventArgs e)
        {

        }

        protected void btn_NoRelease_Click(object sender, EventArgs e)
        {

        }

        protected void Confirm_Click(object sender, EventArgs e)
        {

        }

        protected void grid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

        }
    }
}
