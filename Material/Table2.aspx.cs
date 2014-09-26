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
using Microsoft.Reporting.WebForms;
namespace Maticsoft.Web.Admin.Material
{
    public partial class Table2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Maticsoft.BLL.W_Receivestate bll = new Maticsoft.BLL.W_Receivestate();
            DataSet ds = new DataSet();
            try 
            {
                ds = bll.GetMaterial(Session["SelectedNode"].ToString());
                ReportDataSource datasource = new ReportDataSource("DataSetGetList_W_Material_list", ds.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Sorry, 没有材料提交!";
                }
                ReportViewer1.LocalReport.Refresh();
            }
            catch 
            {                
                Response.Redirect("AllList.aspx");
            }

        }
    }
}
