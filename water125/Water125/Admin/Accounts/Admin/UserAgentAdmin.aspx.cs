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
using LTP.Accounts.Bus;

namespace Maticsoft.Web.Accounts.Admin
{
    public partial class UserAgentAdmin : System.Web.UI.Page
    {
        MmyeeAd.BLL.Call_SuppSumList csbll = new MmyeeAd.BLL.Call_SuppSumList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                InitialDataBind();

                ddlUser_SelectedIndexChanged(sender, e);
            }
        }

        #region 功能函数

        #region 初始化数据绑定
        private void InitialDataBind()
        {
            DataSet ds;

            #region 绑定用户下拉列表
            string[] str = new string[3] { "AA", "AG", "PG" };

            User user = new User();

            for (int i = 0; i < str.Length;i++ )
            {
                ds = new DataSet();
                ds = user.GetUsersByType(str[i].ToString(),"");

                for (int j = 0; j < ds.Tables[0].Rows.Count;j++ )
                {
                    string userID = ds.Tables[0].Rows[j]["UserID"].ToString();
                    string userName = ds.Tables[0].Rows[j]["UserName"].ToString();

                    ListItem li = new ListItem(userName,userID);
                    this.ddlUser.Items.Add(li);
                }

                ds.Dispose();
            }
            #endregion

            #region 绑定代理商列表

            string strWhere = "";
            MmyeeAd.BLL.ADManage.AdAgent bll = new MmyeeAd.BLL.ADManage.AdAgent();

            ds = new DataSet();
            ds = bll.GetList(strWhere);

            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                string agentID = ds.Tables[0].Rows[i]["AgentID"].ToString();
                string agentName = ds.Tables[0].Rows[i]["AgentName"].ToString();

                ListItem li = new ListItem(agentName, agentID);
                this.AllAgentList.Items.Add(li);
            }

            ds.Dispose();

            #endregion
        }
        #endregion

        //填充用户已有阅读权限的代理商列表
        private void FillSelectedAgentList(int userid)
        {
            this.SelectedAgentList.Items.Clear();
            
            string strWhere = " UserID=" + userid;

            DataSet ds = new DataSet();
            ds = csbll.GetUserAgentList(strWhere);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string agentID = ds.Tables[0].Rows[i]["AgentID"].ToString();
                string agentName = ds.Tables[0].Rows[i]["AgentName"].ToString();

                ListItem li = new ListItem(agentName, agentID);
                this.SelectedAgentList.Items.Add(li);
            }

            ds.Dispose();

        }

        #endregion

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int userid = int.Parse(this.ddlUser.SelectedValue);
            FillSelectedAgentList(userid);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string userid = this.ddlUser.SelectedValue;

            int num = this.AllAgentList.Items.Count;

            for (int i = 0; i < num;i++ )
            { 
                if(this.AllAgentList.Items[i].Selected)
                {
                    string agentid = this.AllAgentList.Items[i].Value;
                    string agentname = this.AllAgentList.Items[i].Text;

                    string strWhere = " UserID="+ userid +" and AgentID=" + agentid;

                    if(!csbll.UserAgentListExists(strWhere))
                    {
                        csbll.AddToUserAgentList(userid, agentid, agentname);
                    }
                }
            }

            ddlUser_SelectedIndexChanged(sender, e);
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            string userid = this.ddlUser.SelectedValue;

            int num = this.SelectedAgentList.Items.Count;

            for (int i = 0; i < num; i++)
            {
                if (this.SelectedAgentList.Items[i].Selected)
                {
                    string agentid = this.SelectedAgentList.Items[i].Value;

                    string strWhere = " UserID=" + userid + " and AgentID=" + agentid;

                    csbll.DeleteFromUserAgentList(strWhere);
                }
            }

            ddlUser_SelectedIndexChanged(sender, e);
        }
    }
}
