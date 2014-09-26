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
    public partial class Main1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ClassId = 0;
            try { ClassId =int.Parse(Request.QueryString["ClassId"].ToString()); }
            catch { };
            this.SubNewsList1.MyClassId =ClassId;  

            if (!IsPostBack)
            {
                  BindClassList(ClassId);
            }

        }

        protected void BindClassList(int ClassID)
        {
            string strWhere="";
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            Maticsoft.Model.NewsManage.NewsClass model = new Maticsoft.Model.NewsManage.NewsClass();
            model = bll.GetModel(ClassID);
            int parentid = model.ParentId;
            if (parentid != 0)
            {
                model= bll.GetModelByCache(parentid);
                parentid = model.ParentId;
            }
    
            strWhere = "parentid="+model.ClassId;
            DataSet ds = new DataSet();
            ds = bll.GetList(strWhere);
            DataTable dt = ds.Tables[0];
            this.ClassName.InnerHtml = model.ClassDesc;


            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string classname="nav_2";
                   // 选中状态样式
                    if (ClassID.ToString() == dt.Rows[i][0].ToString())
                        classname = "nav_2_on";
                    this.ClassList.InnerHtml += "<li class='" + classname + "'><img src='images/picto_feuilles.gif' align='absmiddle' /><a href='main.aspx?classid=" + dt.Rows[i][0].ToString() + "' >" + dt.Rows[i][1].ToString() + "</a></li>";
                    
                }
            }
        }
    }
}
