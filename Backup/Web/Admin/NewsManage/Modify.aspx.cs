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
using FreeTextBoxControls;
using System.IO;
namespace Maticsoft.Web.Admin.NewsManage
{
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BiudTree();
                string id = Request.Params["id"];
                if (id == null || id.Trim() == "")
                {
                    Response.Redirect("index.aspx");
                    Response.End();
                }
                else
                {
                    ShowInfo(int.Parse(id));
                }
            }
        }

        #region 类别树
        private void BiudTree()
        {
            if (Session["UserInfo"] == null)
            {
                return;
            }

            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            DataTable dt;
            dt = bll.GetList("").Tables[0];
            this.dropNewsClass.Items.Clear();

            //加载树
            DataRow[] drs = dt.Select("ParentId= 0");

            foreach (DataRow r in drs)
            {
                string nodeid = r["ClassId"].ToString();
                string text = r["ClassDesc"].ToString();
                string parentid = r["ParentId"].ToString();
                text = "╋" + text;
                this.dropNewsClass.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(sonparentid, dt, blank);

            }
            this.dropNewsClass.DataBind();

        }
        private void BindNode(int parentid, DataTable dt, string blank)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);

            foreach (DataRow r in drs)
            {
                string nodeid = r["ClassId"].ToString();
                string text = r["ClassDesc"].ToString();
                text = blank + "『" + text + "』";

                this.dropNewsClass.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";


                BindNode(sonparentid, dt, blank2);
            }
        }
        #endregion

        private void ShowInfo(int Id)
        {
            Navigation011.Para_Str = "id=" + Id;
            Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
            Maticsoft.Model.NewsManage.News model = bll.GetModel(Id);

            Session["news"] = model;
            lblNewsId.Text = model.NewsId.ToString();
            for (int i = 0; i < this.dropNewsClass.Items.Count; i++)
            {
                if (this.dropNewsClass.Items[i].Value == model.ClassId.ToString())
                {
                    this.dropNewsClass.Items[i].Selected = true;
                }
            }

            this.txtHeading.Text = model.Heading;
            this.txtFocus.Text = model.Focus;
            this.txtIssueDate.Text = model.IssueDate.ToString();
            this.chkIsTop.Checked = (model.IsTop == 1);
            this.chkIsLimited.Checked = (model.IsLimited == 1);
            if (model.Dormancy.ToString().ToLower() == "true")
            {
                this.chkDormancy.Checked = false;
            }
            else
            {
                this.chkDormancy.Checked = true;
            }

            //			if(news.Opened.ToString().ToLower()=="true")
            //			{
            //				this.radlistOpened.SelectedIndex=1;
            //			}
            //			else
            //			{
            //				this.radlistOpened.SelectedIndex=0;
            //			}

            this.FreeTextBox1.Text = model.Content;


        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            int newid = int.Parse(lblNewsId.Text);
            string heading = this.txtHeading.Text.Trim();
            string focus = this.txtFocus.Text.Trim();
            string content = this.FreeTextBox1.Text.Trim();
            string classid = this.dropNewsClass.SelectedValue;
            string strissuedate = this.txtIssueDate.Text;
            //bool opened = this.radlistOpened.SelectedValue == "1" ? true : false;
            bool dormancy = !this.chkDormancy.Checked;

            if (heading == "")
            {
                strErr += "标题不能为空\\n";

            }
            if (content == "")
            {
                strErr += "内容不能为空\\n";

            }
            if ((this.dropNewsClass.Items.Count == 0) || (classid.Trim() == ""))
            {
                strErr += "没有可以选择的类别！\\n";
            }

            if (strErr != "")
            {
                LTP.Common.MessageBox.Show(this, strErr);
                return;
            }

            if (Session["UserInfo"] == null)
                return;
            DateTime issuedate = DateTime.Now;
            try
            {
                issuedate = Convert.ToDateTime(strissuedate);
            }
            catch { }
            LTP.Accounts.Bus.User currentUser = (LTP.Accounts.Bus.User)Session["UserInfo"];
            Maticsoft.Model.NewsManage.News news = new Maticsoft.Model.NewsManage.News();
            news.NewsId = newid;
            news.ClassId = int.Parse(classid);
            news.Heading = heading;
            news.Focus = focus;
            news.Content = content;
            news.IssueDate = issuedate;
        //    news.Frequency = 0;
            if (dormancy)
            {
                news.Dormancy = "True";
            }
            else
            {
                news.Dormancy = "False";
            }
            news.IssueDate = issuedate;// DateTime.Now;
            news.Priority = 0;
            news.UserId = currentUser.UserID;
            if (chkIsTop.Checked)
            {
                news.IsTop = 1;
            }
            else
            {
                news.IsTop = 0;
            }

            if (chkIsLimited.Checked)
            {
                news.IsLimited = 1;
            }
            else
            {
                news.IsLimited = 0;
            }

            Maticsoft.BLL.NewsManage.News n = new Maticsoft.BLL.NewsManage.News();
            n.Update(news);



            //处理新闻图片
            if (Session["NewsImages_tempId"] != null)
            {
                int NewsImages_tempId = (int)Session["NewsImages_tempId"];
                Maticsoft.BLL.NewsManage.NewsImages bll = new Maticsoft.BLL.NewsManage.NewsImages();
                DataSet Dset = (DataSet)Session["FileList"]; //bll.GetNewsImagesList(-1, NewsImages_tempId, false);
                if (Dset != null && Dset.Tables[0].Rows.Count > 0)
                {
                    string Sourcepath = Server.MapPath("~/upload/Temp/");
                    string Despath = Server.MapPath("~/upload/img/");
                    for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            string FileName = Dset.Tables[0].Rows[i]["linkurl"].ToString();
                            if (File.Exists(Sourcepath + FileName))
                                File.Copy(Sourcepath + FileName, Despath + FileName);
                            if (File.Exists(Sourcepath + FileName))
                                File.Delete(Sourcepath + FileName);
                        }
                        catch
                        {
                            //this.Label_Msg.Text = "文件复制出错:" + Ex.Message.ToString();
                        }
                    }
                    //修改图片
                  //  string strupdatestring = "newsid=" + newsid.ToString();
                 //   bll.Update(strupdatestring, NewsImages_tempId);
                }
            }


            //处理新闻附件
            if (Session["NewsAffix_tempId"] != null)
            {
                int NewsAffix_tempId = (int)Session["NewsAffix_tempId"];
                Maticsoft.BLL.NewsManage.NewsAffix bll = new Maticsoft.BLL.NewsManage.NewsAffix();
                DataSet Dset = (DataSet)Session["FileList_Affix"]; //bll.GetNewsAffixList(-1, NewsAffix_tempId, false);
                if (Dset != null && Dset.Tables[0].Rows.Count > 0)
                {
                    string Sourcepath = Server.MapPath("~/upload/Temp/");
                    string Despath = Server.MapPath("~/upload/affix/");
                    for (int i = 0; i < Dset.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            string FileName = Dset.Tables[0].Rows[i]["linkurl"].ToString();
                            if (File.Exists(Sourcepath + FileName))
                                File.Copy(Sourcepath + FileName, Despath + FileName);
                            if (File.Exists(Sourcepath + FileName))
                                File.Delete(Sourcepath + FileName);
                        }
                        catch
                        {
                            //this.Label_Msg.Text = "文件复制出错:" + Ex.Message.ToString();
                        }
                    }
                    //修改附件
                    //string strupdatestring = "newsid=" + newsid.ToString();
                    //bll.Update(strupdatestring, NewsAffix_tempId);
                }
            }

            Response.Redirect("show.aspx?id=" + newid);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}
