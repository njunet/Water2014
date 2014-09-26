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
    public partial class NewsList : System.Web.UI.UserControl
    {
        protected int ClassId =-1;
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

        protected int ShowDate = 1;
        public int MyShowDate
        {
            get { return ShowDate; }
            set { ShowDate = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                ShowNews();
            }

        }
        private void ShowNews()
        {
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            DataSet Ds = bll.GetNewsList(MyintTop, MyClassId, false); //bll.GetTopScroll(4);//
            StringBuilder strList = new StringBuilder();			
            
            if (Ds != null && Ds.Tables.Count > 0)
            {
                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                    strList.Append("<li> <span class='graytxt'>[" + Ds.Tables[0].Rows[i]["ClassDesc"] + "] </span>");
                    strList.Append("<a  href='news.aspx?id=" + Ds.Tables[0].Rows[i]["NewsId"] + "' target='_blank'>");
                    strList.Append(FormatString(Ds.Tables[0].Rows[i]["Heading"].ToString(), TitleLength)+"</a>");
                  
                    if (MyShowDate==1)
                    {
                        strList.Append("<span class='date_time'>[");
                        strList.Append(FormatsortDateString(Ds.Tables[0].Rows[i]["IssueDate"].ToString()));
                        strList.Append("]</span>");

                    }        

                    strList.Append("</li>");                    
                }
            }

            this.newListDiv.InnerHtml = strList.ToString();
        }

        protected string FormatString(string str,int Mylength)
        {
            if (Mylength>0 && str.Length > Mylength)
            {
                str = str.Substring(0, Mylength-1) + "...";
            }
            return str;
        }

        //日期格式转换,0表示短型，1表示长型
        protected string FormatsortDateString(string strDate)
        {
            string strreturn = "";
            try
            {
                strreturn = Convert.ToDateTime(strDate).ToShortDateString();
            }
            catch { }

            return strreturn;
        }
    }
}