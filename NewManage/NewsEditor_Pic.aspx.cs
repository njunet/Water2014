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
    public partial class NewsEditor_Pic : System.Web.UI.Page
    {
        static public int NewsId = -1;
        static public string StrWebUrl = "";
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
                Session["NewsImages_tempId"] = NewsId;
                try
                {
                    StrWebUrl = ConfigurationSettings.AppSettings["WebURL"];
                    Maticsoft.BLL.NewsManage.NewsImages bll = new Maticsoft.BLL.NewsManage.NewsImages();
                    DataSet Ds = bll.GetNewsImagesList(-1, NewsId, false); //bll.GetTopScroll(4);//
                    this.GridView1.DataSource = Ds;// Dbs.BindGrid("document_info_Pic", "*", "where Articleid='" + this.Label_ArticleId.Text + "'", "");
                    this.GridView1.DataBind();
                    Session["FileList"] = Ds;

                    if (NewsId < 999999)
                    {
                        string strDespath = Server.MapPath("~/upload/Temp/");
                        string strSourcepath = Server.MapPath("~/upload//img/");
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
        protected void Button_Upload_Click(object sender, EventArgs e)
        {
            if (!this.FileUpload1.HasFile)
            {
                this.Label_Msg.Text += "请先上传一个图片";
                return;
            }
            string Filename = DateTime.Now.Ticks.ToString() + Path.GetExtension(FileUpload1.FileName).ToLower();
            if (!IsPic(Path.GetExtension(FileUpload1.FileName).ToLower()))
            {
                this.Label_Msg.Text += "图片格式不对！";
                return;
            }

            string strpath = Server.MapPath("~/upload/Temp/");
            try
            {
              this.FileUpload1.PostedFile.SaveAs(strpath + Filename);
      

              //  id,newsid,descrip,linkurl,issuedate

                LTP.Accounts.Bus.User currentUser = (LTP.Accounts.Bus.User)Session["UserInfo"];
                Maticsoft.Model.NewsManage.NewsImages newsimages = new Maticsoft.Model.NewsManage.NewsImages();

                newsimages.NewsId = NewsId;
                newsimages.Descrip = this.FreeTextBox1.Text;
                newsimages.IssueDate = DateTime.Now;
                newsimages.LinkUrl = Filename;


                Maticsoft.BLL.NewsManage.NewsImages n = new Maticsoft.BLL.NewsManage.NewsImages();
                n.Add(newsimages);


                Maticsoft.BLL.NewsManage.NewsImages bll = new Maticsoft.BLL.NewsManage.NewsImages();
                DataSet Ds = bll.GetNewsImagesList(-1, NewsId, false); //bll.GetTopScroll(4);//

                this.GridView1.DataSource = Ds;// Dbs.BindGrid("document_info_pic", "*", "where Articleid='" + this.Label_ArticleId.Text + "'", "");
                this.GridView1.DataBind();
                this.Label_Msg.Text = "已经上传了 " + this.GridView1.Rows.Count.ToString() + "  个图片，您可以删除已上传图片，如需修改图片，请先该上传图片，再重新上传！";

            }
            catch
            {
                this.Label_Msg.Text = "图片上传失败！";
            }
        }

        protected bool IsPic(string ExtensionFileName)
        {

            bool strIspic = false;
            string[] Pic ={ ".jpg", ".gif", ".bmp" };
            for (int i = 0; i < Pic.Length; i++)
            {
                if (ExtensionFileName == Pic[i])
                {
                    strIspic = true;
                    break;
                }
            }
            return strIspic;

        }

        protected void GridViewCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt16(e.CommandArgument);
            string Sourcepath = Server.MapPath("~/upload/Temp/");
            string Despath = Server.MapPath("~/upload/img/");
            int picid = 0; //int.Parse(this.GridView1.Rows[index].Cells[0].Text.Trim());
            try
            {
                if (File.Exists(Sourcepath + this.GridView1.Rows[index].Cells[1].Text))
                    File.Delete(Sourcepath + this.GridView1.Rows[index].Cells[1].Text);
                if (File.Exists(Despath + this.GridView1.Rows[index].Cells[1].Text))
                    File.Delete(Despath + this.GridView1.Rows[index].Cells[1].Text);
               picid= int.Parse(this.GridView1.Rows[index].Cells[0].Text);
            }
            catch { }
        //    Dbs.DeleteData("document_info_pic", Conditioin);

            Maticsoft.BLL.NewsManage.NewsImages bll = new Maticsoft.BLL.NewsManage.NewsImages();

            bll.Delete(picid);

            DataSet Ds = bll.GetNewsImagesList(-1, NewsId, false); //bll.GetTopScroll(4);//
            this.GridView1.DataSource = Ds;// Dbs.BindGrid("document_info_pic", "*", "where Articleid='" + this.Label_ArticleId.Text + "'", "");
            this.GridView1.DataBind();
            this.Label_Msg.Text = "已经上传了 " + this.GridView1.Rows.Count.ToString() + "  个图片，您可以删除已上传图片，如需修改图片，请先该上传图片，再重新上传！";

         this.Button1.Enabled = (this.GridView1.Rows.Count > 0);
       }
        protected void GridViewDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                ((LinkButton)this.GridView1.Rows[i].Cells[3].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除文件：\"" + this.GridView1.Rows[i].Cells[1].Text + "\"吗?')");
            }
            this.Button1.Enabled = (this.GridView1.Rows.Count > 0);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
           // Response.Write("<script>window.returnValue='" + NewsId.ToString() + "'</script>");
            Response.Write("<script>window.close()</script>");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.returnValue='0'</script>");
            Response.Write("<script>window.close()</script>");
        }
    }
}