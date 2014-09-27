using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Water125
{
    public partial class dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION bll = new Maticsoft.BLL.HIS_MEASURAND_PERFORMENCE_EVALUATION();
                string id = Request.Params["id"];
                bll.Delete(int.Parse(id));
                Response.Redirect("dataquery_HIS_MEASURAND_PERFORMENCE_EVALUATION.aspx");
            }
        }

       
    }
}