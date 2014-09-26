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
    public partial class AddMaterial : System.Web.UI.Page
    {
        Maticsoft.Model.W_Material model = new Maticsoft.Model.W_Material();
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckBoxList_Reciever初始化
            if (!IsPostBack)
            {
                string id = "";
                try
                {
                    id = Request.QueryString[0].ToString();
                    this.Label_materialId.Text  = id;
                }
                catch { }
                DataSet ds = new DataSet();
                Maticsoft.BLL.W_Receiver bll = new Maticsoft.BLL.W_Receiver();
                ds = bll.GetAllList();
                this.CheckBoxList_Reciever.DataSource = ds;
                CheckBoxList_Reciever.DataTextField = "Receiver";
                CheckBoxList_Reciever.DataValueField = "Id";
                CheckBoxList_Reciever.DataBind();
                 if (id == "")
                {
                    this.TextBox_Address.Text = "http://kjc.jstu.edu.cn/";
                    this.TextBox_Number.Text = "申报书一式三份";
                    this.begindate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.enddate.Text = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
                }

                else
                {
                    Maticsoft.BLL.W_Material bll2 = new Maticsoft.BLL.W_Material();
                    model = bll2.GetModel(int.Parse(id));
                    this.Name.Text = model.Name;
                    this.Label_materialId.Text = model.Id.ToString();
                    this.begindate.Text = (Convert.ToDateTime( model.Begindate)).ToShortDateString();
                    this.enddate.Text = (Convert.ToDateTime(model.Enddate)).ToShortDateString();
                    this.TextBox_Address.Text = model.Address;
                    this.TextBox_Number.Text = model.Number;

                    DataSet ds2 = new DataSet();
                    Maticsoft.BLL.W_Receivestate bll3 = new Maticsoft.BLL.W_Receivestate();
                    ds2 = bll3.GetList("MaterialId=" + id);
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                       int j = int.Parse(ds2.Tables[0].Rows[i][2].ToString());
                       this.CheckBoxList_Reciever.Items[j-1].Selected=true ;                       
                    
                     }
                
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


            //对Material表的输入
            DateTime begindate = Convert .ToDateTime (this .begindate .Text );
            DateTime enddate = Convert.ToDateTime(this.enddate .Text);
            string name = this.Name .Text.Trim();
            string address = this.TextBox_Address.Text.Trim();
            string number = this.TextBox_Number.Text.Trim();
           // Maticsoft.Model.W_Material material = new Maticsoft.Model.W_Material();
            Maticsoft.BLL.W_Material bll = new Maticsoft.BLL.W_Material();
            model.Name = name;
            model.Begindate = begindate;
            model.Enddate = enddate;
            model.Address = address;
            model.Number = number;

            int id;
            Maticsoft.Model.W_Receivestate receivestate = new Maticsoft.Model.W_Receivestate();
            Maticsoft.BLL.W_Receivestate bllstate = new Maticsoft.BLL.W_Receivestate();
   
            if (this.Label_materialId.Text == "")　//添加
                id = bll.Add(model);
            else //修改
            {
                id = int.Parse( this.Label_materialId.Text.Trim());
                model.Id = int.Parse(this.Label_materialId.Text.Trim());
                bll.Update(model);

                //对W_Receivestate表的操作 添加时是否需要　bllstate.delete??
                bllstate.Delete(id);
  
            }

             
            receivestate.MaterialId = id;
            for (int i = 0; i < this.CheckBoxList_Reciever.Items.Count; i++)
            {
                if (this.CheckBoxList_Reciever.Items[i].Selected)
                {
                    receivestate.ReceiverId = this.CheckBoxList_Reciever.Items[i].Value;                    
                        bllstate.Add(receivestate);                   
                }
            }
            if (id > 1)
            {
                //this.Label_Msg.Text = "提交成功!";
            }
            Response.Redirect("ManagerMaterial.aspx");
        }


       
        ////实现CheckdownList的全选功能
        //protected void Button_AllSelected_Click(object sender, EventArgs e)
        //{




        //    for (int i = 0; i < this.CheckBoxList_Reciever.Items.Count; i++)
        //        this.CheckBoxList_Reciever.Items[i].Selected = true;
        //}
        ////全不选
        //protected void Button_NoSeleced_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < this.CheckBoxList_Reciever.Items.Count; i++)
        //        this.CheckBoxList_Reciever.Items[i].Selected = false;
        //}
        //返回页面
        protected void Button_Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerMaterial.aspx");
        }
    }
}
