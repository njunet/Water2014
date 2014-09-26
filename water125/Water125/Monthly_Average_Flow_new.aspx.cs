using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Water125
{
    public partial class Monthly_Average_Flow_new : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void buttonToTableClick(object sender, EventArgs e)
        {
            //string stationId = ddlStationName.DataValueField.ToString();
            Response.Redirect("dataquery_HIS_MEASURAND_AverageFlow_Month.aspx");
        }

    }
}