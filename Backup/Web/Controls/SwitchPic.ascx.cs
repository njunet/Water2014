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

namespace Maticsoft.Web.Controls
{
    public partial class SwitchPic : System.Web.UI.UserControl
    {
     public   static string[] strtitle ={ "", "", "" };
        public static string[] strimg ={ "", "", "" };
        public static string[] strid ={ "", "", "" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetImagesInfo();
            }
        }


        protected  void GetImagesInfo()
        {
          
            DataSet Ds = new DataSet();
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            Ds=bll.GetTopImgScroll(3);
            try
            {
                strid[0] = "news.aspx?id=" + Ds.Tables[0].Rows[0][0].ToString();
                strid[1] = "news.aspx?id=" + Ds.Tables[0].Rows[1][0].ToString();
                strid[2] = "news.aspx?id=" + Ds.Tables[0].Rows[2][0].ToString();
            }
            catch { }
            try
            {
                strtitle[0] = Ds.Tables[0].Rows[0][1].ToString();
                strtitle[1] = Ds.Tables[0].Rows[1][1].ToString();
                strtitle[2] = Ds.Tables[0].Rows[2][1].ToString();
            }
            catch { }
            try
            {
                strimg[0] = Ds.Tables[0].Rows[0][3].ToString();
                strimg[1] = Ds.Tables[0].Rows[1][3].ToString();
                strimg[2] = Ds.Tables[0].Rows[2][3].ToString();
            }
            catch { }
        }
    }
}