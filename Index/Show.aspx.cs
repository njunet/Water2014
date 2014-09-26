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
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = "";

            if (!IsPostBack)
            {
                try
                {
                    id = Request.QueryString[0].ToString();
                }
                catch { }
                Bind(int.Parse(id));

            }
        }
        protected void Bind(int Id)
        {
            Maticsoft.BLL.W_Material bll = new Maticsoft.BLL.W_Material();
            Maticsoft.Model.W_Material model = new Maticsoft.Model.W_Material();
            model = bll.GetModel(Id);
            this.lblId.Text = model.Id.ToString();
            this.lblName.Text = model.Name;
            this.lblBeginDate.Text = (Convert.ToDateTime(model.Begindate)).ToShortDateString();
            this.lblEnddate.Text = (Convert.ToDateTime(model.Enddate)).ToShortDateString();
            this.Label_Address.Text = model.Address;
            this.Label_Number.Text = model.Number;


            DataSet ds2 = new DataSet();
            Maticsoft.BLL.W_Receivestate bll3 = new Maticsoft.BLL.W_Receivestate();
            ds2 = bll3.GetList("MaterialId=" + Id);
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                int j = int.Parse(ds2.Tables[0].Rows[i][2].ToString());
                Maticsoft.BLL.W_Receiver bll4 = new Maticsoft.BLL.W_Receiver();
                Maticsoft.Model.W_Receiver model4 = new Maticsoft.Model.W_Receiver();
                model4 = bll4.GetModel(j);
                this.lblReceiver.Text += model4.Receiver + "  ";

            }

            DataSet ds5 = new DataSet();
            Maticsoft.BLL.W_Receivestate bll5 = new Maticsoft.BLL.W_Receivestate();
            ds5 = bll5.GetList("MaterialId=" + Id + "and Dormacy = '提交'");
            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                int j = int.Parse(ds5.Tables[0].Rows[i][2].ToString());
                Maticsoft.BLL.W_Receiver bll4 = new Maticsoft.BLL.W_Receiver();
                Maticsoft.Model.W_Receiver model4 = new Maticsoft.Model.W_Receiver();
                model4 = bll4.GetModel(j);
                this.Label_IsHanded.Text += model4.Receiver + "  ";

            }

        }
    }
}