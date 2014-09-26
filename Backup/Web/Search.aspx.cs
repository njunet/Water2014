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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Request.Form.Count < 2)
                    Response.Write("<script>window.close()</script>");
                newssearch();
            }
        }

        protected void newssearch()
        {
            string key = Request.Form[0].ToString();
            int type = int.Parse(Request.Form[1]);
            string strType = "";

            this.searchInfo.InnerHtml = key + type.ToString();
            string strwhere="";
            switch (type)
            {
                case 1:
                    strwhere = " ( heading  like'%" + key + "%')";
                    strType = "标题";
                    break;
                case 2:
                    strwhere = " ( content  like'%" + key + "%')";
                    strType = "内容";
                    break;
                case 3:
                    string strdate="1900-01-01";
                    try { strdate = Convert.ToDateTime(key).ToShortDateString(); }
                    catch { }
                    strwhere = " issuedate>'" + strdate + "' and issuedate-1<'" + strdate + "'";                    
                   strType = "日期";
                    break;
            }
            

            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();           
            DataSet ds = new DataSet();
            ds = bll.GetList(strwhere);
            this.GridView1.DataSource = ds.Tables[0].DefaultView;
            this.GridView1.DataBind();

            int count=0;
            try
            {
                count=ds.Tables[0].Rows.Count;               
            }
            catch { }
           this.searchInfo.InnerHtml = "搜索关键字：<b>" + key + " </b>搜索方式：<b>" + strType;
           this.searchInfo.InnerHtml += "</b>共找到记录：<b>" +count.ToString() +"</b>";
        }

    }
}
