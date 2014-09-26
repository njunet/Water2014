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
    public partial class ShowInIndex1 : System.Web.UI.UserControl
    {
        
        protected int TitleLength = -1;
        public int MyTitleLenth
        {
            get { return TitleLength; }
            set { TitleLength = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }
        protected void Bind()
        {


            DataSet ds = new DataSet();
            Maticsoft.BLL.W_Receivestate bll = new Maticsoft.BLL.W_Receivestate();
            ds = bll.W_Material_ShowIndex(12);
            MyTitleLenth = 22;
            this.GridViewArticle.DataSource = ds;
            this.GridViewArticle.DataBind();


        
        }
    }
}