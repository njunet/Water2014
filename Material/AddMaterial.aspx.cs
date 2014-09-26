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
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";
            //CheckBoxList_Reciever初始化
            if (!IsPostBack)
            {
                try
                {
                    id = Request.QueryString[0].ToString();
                    this.Label1.Text  = id;
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
                    this.TextBox_Address.Text = "http://kjc.jstu.edu.cn/news.aspx?id=205";
                    this.TextBox_Number.Text = "申报书一式三份，活页7份";
                    this.begindate.Text = DateTime.Now.ToShortDateString();
                    this.enddate.Text = DateTime.Now.AddDays(7).ToShortDateString();
                }

                else
                {
                    Maticsoft.BLL.W_Material bll2 = new Maticsoft.BLL.W_Material();
                    Maticsoft.Model.W_Material model = new Maticsoft.Model.W_Material();
                    model = bll2.GetModel(int.Parse( id));
                    this.Name.Text = model.Name;
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
            Maticsoft.Model.W_Material material = new Maticsoft.Model.W_Material();
            Maticsoft.BLL.W_Material bll = new Maticsoft.BLL.W_Material();
            material.Name = name;
            material.Begindate = begindate;
            material.Enddate = enddate;
            material.Address = address;
            material.Number = number;
            int id;
            if (this.Label1.Text == "")

                id = bll.Add(material);
            else
            {
                id = int.Parse( this.Label1.Text.Trim());
                bll.Update(material);

            }

            Maticsoft.Model.W_Receivestate receivestate = new Maticsoft.Model.W_Receivestate();
            Maticsoft.BLL.W_Receivestate bllstate = new Maticsoft.BLL.W_Receivestate();
           
            receivestate.MaterialId = id;
            //对W_Receivestate表的操作
            bllstate.Delete(id);
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
