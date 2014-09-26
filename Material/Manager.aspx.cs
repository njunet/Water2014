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
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string id = "";
            //CheckBoxList_Reciever初始化
            if (!IsPostBack)
            {
                try
                {
                    id = Request.QueryString[0].ToString();
                    this.Label1.Text = id;
                }
                catch { }

                if (id == "")
                {
                    this.begindate.Text = DateTime.Now.ToShortDateString();
                    this.enddate.Text = DateTime.Now.AddDays(7).ToShortDateString();
                }

                else
                {
                    //绑定CheckBoxList前面的部分
                    Maticsoft.BLL.W_Material bll2 = new Maticsoft.BLL.W_Material();
                    Maticsoft.Model.W_Material model = new Maticsoft.Model.W_Material();
                    model = bll2.GetModel(int.Parse(id));
                    this.Name.Text = model.Name;
                    this.begindate.Text = (Convert.ToDateTime(model.Begindate)).ToShortDateString();
                    this.enddate.Text = (Convert.ToDateTime(model.Enddate)).ToShortDateString();
                    //绑定CheckBoxList
                    DataSet ds = new DataSet();
                    Maticsoft.BLL.W_Receiver bll = new Maticsoft.BLL.W_Receiver();
                    ds = bll.W_Receiver_Mid(id);
                    this.CheckBoxList_Reciever.DataSource = ds;
                    CheckBoxList_Reciever.DataTextField = "Receiver";
                    CheckBoxList_Reciever.DataValueField = "Id";
                    CheckBoxList_Reciever.DataBind();




                }
            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.Name.Text == "")
            {
                this.Label2.Text = "请输入材料名";
                return;

            }




            Maticsoft.Model.W_Receivestate receivestate = new Maticsoft.Model.W_Receivestate();
            Maticsoft.BLL.W_Receivestate bllstate = new Maticsoft.BLL.W_Receivestate();


            for (int i = 0; i < this.CheckBoxList_Reciever.Items.Count; i++)
            {
                if (this.CheckBoxList_Reciever.Items[i].Selected)
                {
                    receivestate.ReceiverId = this.CheckBoxList_Reciever.Items[i].Value;
                    receivestate.MaterialId = int.Parse(this.Label1.Text.Trim());
                    receivestate.Dormacy = "提交";
                    receivestate.IssureTime = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                    bllstate.Update(receivestate);





                }
            }
            if (int.Parse(this.Label1.Text) > 1)
            {
                //this.Label_Msg.Text = "提交成功!";
            }
            Response.Redirect("AllList.aspx");
        }





        //返回页面
        protected void Button_Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerMaterial.aspx");
        }
    }
}