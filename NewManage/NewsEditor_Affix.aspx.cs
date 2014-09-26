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
using System.IO;

namespace Maticsoft.Web.Admin.NewsManage
{
    public partial class NewsEditor_Affix : System.Web.UI.Page
    {
        static public int NewsId = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ArticleId"] == null)
                {
                   NewsId = 999999;// Response.End();
                
                }
                else
                {
                   NewsId = int.Parse(Request.QueryString["ArticleId"].ToString());
                }
                Session["NewsAffix_tempId"] = NewsId;
                try
                {
                    //this.Label_ArticleId.Text = Request.QueryString["ArticleId"].ToString();

                    // Maticsoft.BLL.NewsManage.News bll = new Maticsoft.BLL.NewsManage.News();
                    Maticsoft.BLL.NewsManage.NewsAffix bll = new Maticsoft.BLL.NewsManage.NewsAffix();
                    DataSet Ds = bll.GetNewsAffixList(-1, NewsId, false); //bll.GetTopScroll(4);//
                    Session["FileList_Affix"] = Ds; 
                    this.GridView1.DataSource = Ds;// Dbs.BindGrid("document_info_Pic", "*", "where Articleid='" + this.Label_ArticleId.Text + "'", "");
                    this.GridView1.DataBind();

                    if (NewsId < 999999)
                    {
                        string strDespath = Server.MapPath("~/upload/Temp/");
                        string strSourcepath = Server.MapPath("~/upload/Affix/");
                        for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                        {
                            string strFileName = Ds.Tables[0].Rows[i]["LinkUrl"].ToString();
                            CopyFile(strSourcepath + strFileName, strDespath + strFileName);
                        }
                    }
                    Ds = null;
                }
                catch { }
            }

        }
        protected void CopyFile(string strSource, string strDes)
        {
            //将图片Copy至临时文件夹中;
            if (File.Exists(strSource))
            {
                File.Copy(strSource, strDes);
                File.Delete(strSource);
            }
        }
        protected void Button_addfix_Click(object sender, EventArgs e)
        {
            if (!this.FileUpload1.HasFile)
            {
                this.Label_Msg.Text += "请先上传一个文件";
                return;
            }
            string Filename = DateTime.Now.Ticks.ToString() + Path.GetExtension(FileUpload1.FileName).ToLower();
            string strpath = Server.MapPath("~/upload/Temp/");
            try
            {
                this.FileUpload1.PostedFile.SaveAs(strpath + Filename);

                //  id,newsid,descrip,linkurl,issuedate

                LTP.Accounts.Bus.User currentUser = (LTP.Accounts.Bus.User)Session["UserInfo"];
                Maticsoft.Model.NewsManage.NewsAffix NewsAffix = new Maticsoft.Model.NewsManage.NewsAffix();

                NewsAffix.NewsId = NewsId;
                NewsAffix.Descrip = this.TextBox_affixname.Text.Trim();
                NewsAffix.IssueDate = DateTime.Now;
                NewsAffix.LinkUrl = Filename;


                Maticsoft.BLL.NewsManage.NewsAffix n = new Maticsoft.BLL.NewsManage.NewsAffix();
                n.Add(NewsAffix);

                Maticsoft.BLL.NewsManage.NewsAffix bll = new Maticsoft.BLL.NewsManage.NewsAffix();
             
                DataSet Ds = bll.GetNewsAffixList(-1, NewsId, false); //bll.GetTopScroll(4);//
                this.GridView1.DataSource = Ds;// Dbs.BindGrid("document_info_pic", "*", "where Articleid='" + this.Label_ArticleId.Text + "'", "");
                this.GridView1.DataBind();      

                
                this.Label_Msg.Text = "已经上传了 " + this.GridView1.Rows.Count.ToString() + "  个文件，您可以删除已上传文件，如需修改文件，请先该上传文件，再重新上传！";
            }
            catch
            {
                this.Label_Msg.Text = "文件上传失败！";
            }
        }
        protected void GridViewCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt16(e.CommandArgument);
            string Sourcepath = Server.MapPath("~/upload/Temp/");
            string Despath = Server.MapPath("~/upload/Affix/");
            int affixid = 0; //int.Parse(this.GridView1.Rows[index].Cells[0].Text.Trim());

         
            try
            {
                if (File.Exists(Sourcepath + this.GridView1.Rows[index].Cells[2].Text))
                    File.Delete(Sourcepath + this.GridView1.Rows[index].Cells[2].Text);
                if (File.Exists(Despath + this.GridView1.Rows[index].Cells[2].Text))
                    File.Delete(Despath + this.GridView1.Rows[index].Cells[2].Text);

                affixid = int.Parse(this.GridView1.Rows[index].Cells[0].Text);

            }
            catch { }


            Maticsoft.BLL.NewsManage.NewsAffix bll = new Maticsoft.BLL.NewsManage.NewsAffix();
            bll.Delete(affixid);

            DataSet Ds = bll.GetNewsAffixList(-1, NewsId, false); //bll.GetTopScroll(4);//
            this.GridView1.DataSource = Ds;// Dbs.BindGrid("document_info_pic", "*", "where Articleid='" + this.Label_ArticleId.Text + "'", "");
            this.GridView1.DataBind();      

            this.Label_Msg.Text = "已经上传了 " + this.GridView1.Rows.Count.ToString() + " 个文件，您可以删除已上传文件，如需修改文件，请先该上传文件，再重新上传！";
            this.Button1.Enabled = (this.GridView1.Rows.Count > 0);
        }
        protected void GridViewDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                ((LinkButton)this.GridView1.Rows[i].Cells[3].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除文件：\"" + this.GridView1.Rows[i].Cells[2].Text + "\"吗?')");
            }
            this.Button1.Enabled = (this.GridView1.Rows.Count > 0);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.returnValue='0'</script>");
            Response.Write("<script>window.close()</script>");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.returnValue='" + this.GridView1.Rows.Count.ToString() + "'</script>");
            Response.Write("<script>window.close()</script>");
        }
    }
}
