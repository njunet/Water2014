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
using LTP.Common;

namespace Maticsoft.Web.Admin.SysManage
{
    public partial class DataBackRecover : System.Web.UI.Page
    {
        LTP.Common.DBRecover dbrecover = new LTP.Common.DBRecover();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                // string strData = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                this.TextBoxFile.Text = "MaticsoftFramework_" + DateTime.Now.ToString("yy-MM-dd") + ".rar";
                this.TextBoxPath.Text = ConfigurationSettings.AppSettings["DBBackupPath"];

            }
            
        }
         protected void BackupDb()
        {
            int i = 0;            
            try
            {
                i = dbrecover.DbRecover(""+this.TextBoxPath.Text +  this.TextBoxFile.Text + "");
            }
            catch
            { }
            string SourceFile = this.TextBoxPath.Text +  this.TextBoxFile.Text;
         //   string DesFile =this.TextBoxPath.Text + "\\" + this.TextBoxFile.Text.Trim() + ".rar";
            if (i == -1)
            {
                LTP.Common.MessageBox.Show(this,"数据库备份成功!");
         //       File.Copy(SourceFile, DesFile, true);
                this.HyperLinkDownDB.NavigateUrl = "~/upload/db/" + this.TextBoxFile.Text;
                //this.HyperLinkftp.NamingContainer = "ftp://WYXY:WYXY@210.29.192.25/";
                this.HyperLinkDownDB.Visible = true;
            }
            else
            {
                Exception ex = new Exception();
                LTP.Common.MessageBox.Show(this, "备份失败:" + ex.Message.ToString());
            }
            
        }
    
      

        protected void Button_Confirm_Click(object sender, EventArgs e)
        {
            BackupDb();           
        }      

        protected void Button_Cancel_Click(object sender, EventArgs e)
        {

        }
       
    
    }
}
