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

namespace Maticsoft.Web
{
    public partial class ShowInIndex1 : System.Web.UI.UserControl
    {
        //定义了一个全局变量：修改人学生
        DataSet ds1 = new DataSet();
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
                if (MyPage == -1)
                    MyPage = this.GridView1.PageSize;
                else
                    this.GridView1.PageSize = MyPage;
                this.GridView1.AllowSorting = true;
                ShowNews();
             //   GenNavigate(MyClassId);
            }
        }
        private void ShowNews()
        {
            Maticsoft.BLL.W_Material bll = new Maticsoft.BLL.W_Material();
            string strWhrere = "";
            //显示没有过期的和允许过期显示的：修改人学生
            strWhrere = "EndDate>'" + DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")+"'or Outdisplay='是'" ;
            //DataSet Ds = bll.GetList(MyintTop, strWhrere, "enddate desc");
            //写入了全局变量：修改人学生
            ds1=bll.GetList(MyintTop, strWhrere, "enddate desc");
            this.GridView1.DataSource = ds1;
            this.GridView1.DataBind();

            //处理记录信息 
            try
            {
                this.lblRowsCount.Text = ds1.Tables[0].Rows.Count.ToString();
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
       
        #endregion

     

        protected void BindReceiver(object sender, EventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                //int id = int.Parse(this.GridView1.Rows[i].Cells[0].Text);
               
               //id从全局变量的DS取出来：修改人学生
                int id = int.Parse(ds1.Tables[0].Rows[i]["Id"].ToString()) ;
                Label lbl = (Label)this.GridView1.Rows[i].Cells[4].FindControl("Label_Receiver");
                Maticsoft.BLL.W_Receivestate bll = new Maticsoft.BLL.W_Receivestate();
                DataSet Ds = bll.W_Material_ShowIndex(id);
                if (Ds != null && Ds.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < Ds.Tables[0].Rows.Count; j++)
                    {
                        lbl.Text += Ds.Tables[0].Rows[j]["Receiver"] + " ";
                        if ((j+1) % 4 == 0) lbl.Text += "<br/>";

                    }
                }
            }

        }
    }
}