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
namespace Maticsoft.Web
{
    public partial class News : System.Web.UI.Page
    {
        public string strHeading = "";
        public string strDate = "";
        public string strContent = "";
        public string strfrquency = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Page.Title = "新闻";
                if ((Request.Params["id"] != null) && (Request.Params["id"].ToString() != ""))
                {
                    string id = Request.Params["id"];
                    ShowNews(int.Parse(id));
                    Page.Title = strHeading;
                }
            }
        }

        private void ShowNews(int NewsId)//显示新闻
        {
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            Maticsoft.Model.NewsManage.News model = bll.GetModelByCache(NewsId);

            strHeading = model.Heading;
            strDate = model.IssueDate.ToString();
            strContent = model.Content;
            strfrquency = model.Frequency.ToString();

            if (model.IsLimited == 1)
            {
             string XmlPath=Server.MapPath("~/app_data/AllowIp.xml");
             string thisIp = "";
             thisIp = Page.Request.UserHostAddress;
            Maticsoft.BLL.NewsManage.NewsViewIpcontrol newsipcontrol= new Maticsoft.BLL.NewsManage.NewsViewIpcontrol();

            if (!newsipcontrol.IpAllow(thisIp,XmlPath))
            {
                strContent = "对不起，您的IP:" + thisIp + "不在本文允许的访问范围内，请联系管理员！";
                return;
            }            
            }

            //附件信息
            this.newsimagescontent.InnerHtml = ShowNewsImage(NewsId).ToString();
            this.newsaffixcontent.InnerHtml = ShowNewsAffix(NewsId).ToString();
            GenNavigate(model.ClassId);

            //点击率增加
           model.Frequency++;
           bll.FrequencyAdd(model);
        }

        private StringBuilder ShowNewsImage(int NewsId)
        {
            Maticsoft.BLL.NewsManage.NewsImages bll = new Maticsoft.BLL.NewsManage.NewsImages();
            string strWhere = "newsid=" + NewsId.ToString();
            DataSet Ds =   bll.GetList(strWhere);
            StringBuilder StrBNewsImage = new StringBuilder();
            if (Ds != null && Ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                 StrBNewsImage.Append( " <p align='center'><img border='0' alt='' class='contentimg' src='");
                   StrBNewsImage.Append("upload/img/"+Ds.Tables[0].Rows[i][3].ToString()+"'width=760px /></p>");
                   StrBNewsImage.Append(Ds.Tables[0].Rows[i][2].ToString());
                } 
            }
            return StrBNewsImage;
        }


        private StringBuilder ShowNewsAffix(int NewsId)
        {
            Maticsoft.BLL.NewsManage.NewsAffix bll = new Maticsoft.BLL.NewsManage.NewsAffix();
            string strWhere = "newsid=" + NewsId.ToString();
            DataSet Ds = bll.GetList(strWhere);
            StringBuilder StrBNewsAffix = new StringBuilder();
            if (Ds != null && Ds.Tables[0].Rows.Count > 0)
            {
                StrBNewsAffix.Append(" 附件：<br />");
                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                {
                    StrBNewsAffix.Append(" <img  src='Images/HasAffix.gif'/><a href='upload/affix/");
                    StrBNewsAffix.Append(Ds.Tables[0].Rows[i][3].ToString() + "'>");
                    StrBNewsAffix.Append( Ds.Tables[0].Rows[i][2].ToString() + "</a><br />");
                }
            }
            return StrBNewsAffix;
        }


        //生成导航条
        public void GenNavigate(int ClassId)
        {
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            this.PagaNavi.InnerHtml = bll.GenNavigate(ClassId);
        }
    }
}
