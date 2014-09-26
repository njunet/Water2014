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

namespace Maticsoft.Web.Admin.Total_Emission
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FreeTextBox1.AutoConfigure = AutoConfigure.EnableAll;
                this.FreeTextBox1.HelperFilesPath = "HelperScripts";
                //this.FreeTextBox1.ImageGalleryPath="images";
                string UpNewsImageFolder = LTP.Common.ConfigHelper.GetConfigString("UpNewsImageFolder");
                this.FreeTextBox1.ImageGalleryPath = UpNewsImageFolder;

                BiudTree();
                if (Session["news"] != null)
                {
                    Maticsoft.Model.NewsManage.News news = (Maticsoft.Model.NewsManage.News)Session["news"];
                    for (int i = 0; i < this.dropNewsClass.Items.Count; i++)
                    {
                        if (this.dropNewsClass.Items[i].Value == news.ClassId.ToString())
                        {
                            this.dropNewsClass.Items[i].Selected = true;
                        }
                    }
                    this.chkDormancy.Checked =news.Dormancy == "True" ? true : false;

                    this.chkAddContinue.Checked = true;
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


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErr = "";
            string heading = this.txtHeading.Text.Trim();
            string focus = this.txtFocus.Text.Trim();
            string content = this.FreeTextBox1.Text.Trim();
            string classid = this.dropNewsClass.SelectedValue;
            bool dormancy = this.chkDormancy.Checked;



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
            LTP.Accounts.Bus.User currentUser = (LTP.Accounts.Bus.User)Session["UserInfo"];
            Maticsoft.Model.NewsManage.News news = new Maticsoft.Model.NewsManage.News();
            news.ClassId = int.Parse(classid);
            news.Heading = heading;
            news.Focus = focus;
            news.Content = content;
            if (dormancy==true)
            {
                news.Dormancy = "false";                
            }
            else 
            {                
                news.Dormancy = "true";
            }
           // news.Dormancy = dormancy.ToString();
            //news.Opened = opened;
            news.Frequency = 0;
            news.IssueDate = DateTime.Now;
            //news.ParentId = 0;
            news.Priority = 0;
            news.UserId = currentUser.UserID;
            //news.DepartmentID = int.Parse(currentUser.DepartmentID);
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
                news.IsLimited= 0;
            }

            int newsid = 0;
            Maticsoft.BLL.NewsManage.News n = new Maticsoft.BLL.NewsManage.News();
           newsid=  n.Add(news);

            //处理新闻图片
          if (Session["NewsImages_tempId"] != null)
          {
              int NewsImages_tempId = (int)Session["NewsImages_tempId"];
              Maticsoft.BLL.NewsManage.NewsImages bll = new Maticsoft.BLL.NewsManage.NewsImages();
              DataSet Dset =(DataSet) Session["FileList"]; // bll.GetNewsImagesList(-1, NewsImages_tempId, false);
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
                  string strupdatestring = "newsid=" + newsid.ToString();
                  bll.Update(strupdatestring, NewsImages_tempId);
              }
          }


          //处理新闻附件
          if (Session["NewsAffix_tempId"] != null)
          {
              int NewsAffix_tempId = (int)Session["NewsAffix_tempId"];
              Maticsoft.BLL.NewsManage.NewsAffix bll = new Maticsoft.BLL.NewsManage.NewsAffix();
              DataSet Dset = (DataSet)Session["FileList_Affix"];              
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
                  string strupdatestring = "newsid=" + newsid.ToString();
                  bll.Update(strupdatestring, NewsAffix_tempId);
              }
          }



            if (chkAddContinue.Checked)
            {
                Session["news"] = news;
                Response.Redirect("Add.aspx");
            }
            else
            {
                Session["news"] = null;
                Response.Redirect("index.aspx");
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtHeading.Text = "";
            this.txtFocus.Text = "";
            this.FreeTextBox1.Text = "";
        }
    }
}
    
