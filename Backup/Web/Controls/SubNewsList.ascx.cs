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
using System.Text;

namespace Maticsoft.Web.Controls
{
    public partial class SubNewsList : System.Web.UI.UserControl
    {
       
        protected int ClassId = -1;
        public int MyClassId
        {
            get { return ClassId; }
            set { ClassId = value; }
        }
        protected int TitleLength = -1;
        public int MyTitleLenth
        {
            get { return TitleLength; }
            set { TitleLength = value; }
        }
        protected int intTop = -1;
        public int MyintTop
        {
            get { return intTop; }
            set { intTop = value; }
        }

        protected int intPageSize = -1;
        public int MyPage
        {
            get { return intPageSize; }
            set { intPageSize = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GridView1.AllowSorting = true;
                this.GridView1.PageSize = MyPage;
                ShowNews();
                GenNavigate(MyClassId);
            }
        }
        private void ShowNews()
        {
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            DataSet Ds = bll.GetNewsList(MyintTop, MyClassId, false); //bll.GetTopScroll(4);//
            this.GridView1.DataSource = Ds;
            this.GridView1.DataBind();

            //处理记录信息 
            try
            {
                this.lblRowsCount.Text = Ds.Tables[0].Rows.Count.ToString();
            }
            catch { };

            this.PageDrop.Items.Clear();
            for (int i = 0; i < this.GridView1.PageCount; i++) 
            {
                ListItem dropitem = new ListItem();
                dropitem.Value = i.ToString();
                dropitem.Text = (i + 1).ToString();
                this.PageDrop.Items.Add(dropitem);
            }
            if(this.PageDrop.Items.Count>0)
            this.PageDrop.SelectedIndex = this.GridView1.PageIndex;
        }

        protected string FormatString(string str)
        {
            if (MyTitleLenth>0 && str.Length > MyTitleLenth)
            {
                str = str.Substring(0, MyTitleLenth - 1) + "...";
            }
            return str;
        }


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
                    if (GridView1.PageIndex > 0)
                    {
                        GridView1.PageIndex -= 1;

                    }
                    break;
                case "Next":
                    if (GridView1.PageIndex < (GridView1.PageCount - 1))
                    {
                        GridView1.PageIndex += 1;

                    }
                    break;
                case "First":
                    GridView1.PageIndex = 0;
                    break;
                case "Last":
                    GridView1.PageIndex = (GridView1.PageCount - 1)>-1?GridView1.PageCount - 1:0;
                    break;
                case "toIndex":
                    int index = this.PageDrop.SelectedIndex>-1?this.PageDrop.SelectedIndex:0;
                    GridView1.PageIndex = index;
                    break;

            }
            if (GridView1.PageIndex == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                if (GridView1.PageCount == 1)
                {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            else if (GridView1.PageIndex == GridView1.PageCount - 1)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            ShowNews();
        }
        public void GenNavigate(int ClassId)
        {            
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            this.PagaNavi.InnerHtml = bll.GenNavigate(ClassId);
        }
        #endregion
    }
}