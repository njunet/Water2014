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

namespace Water125
{
    public partial class Info_show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ClassId = 0;
            try { ClassId = int.Parse(Request.QueryString["ClassId"].ToString()); }
            catch { };
            this.SubNewsList1.MyClassId = ClassId;

            if (!IsPostBack)
            {
                BindClassList(ClassId);
            }

        }

        protected void BindClassList(int ClassID)
        {
            string strWhere = "";
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            Maticsoft.Model.NewsManage.NewsClass model = new Maticsoft.Model.NewsManage.NewsClass();
            model = bll.GetModel(ClassID);
            int parentid = model.ParentId;
            if (parentid != 0)
            {
                model = bll.GetModelByCache(parentid);
                parentid = model.ParentId;
            }

            strWhere = "parentid=" + model.ClassId;
            DataSet ds = new DataSet();
            ds = bll.GetList(strWhere);
            DataTable dt = ds.Tables[0];


        }
    }
}