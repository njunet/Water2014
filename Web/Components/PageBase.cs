using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LTP.Accounts.Bus;

namespace Maticsoft.Web
{
    /// <summary>
    /// ҳ�����
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new System.EventHandler(this.Page_Load);
            this.Error += new System.EventHandler(this.Page_Error);
        }

        #region Ȩ�޼��
        /// <summary>
        /// ҳ�����Ȩ��ID��
        /// </summary>
        public virtual int PermissionID
        {
            get { return -1; }
        }

        public AccountsPrincipal CurrentPrincipal
        {
            get
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                    return user;
                }
                return null;
            }
        }
        /// <summary>
        /// ��ǰ�û���Ϣ
        /// </summary>
        public LTP.Accounts.Bus.User CurrentUser
        {
            get
            {
                if (CurrentPrincipal == null)
                {
                    return null;
                }
                if (Session["UserInfo"] == null)
                {
                    LTP.Accounts.Bus.User currentUser = new LTP.Accounts.Bus.User(CurrentPrincipal);
                    Session["UserInfo"] = currentUser;
                }
                return Session["UserInfo"] as LTP.Accounts.Bus.User;
            }
        }
        #endregion

        #region ҳ���¼�
        private void Page_Load(object sender, System.EventArgs e)
        {
            //��վ����������Ŀ¼
            string virtualPath = ConfigurationManager.AppSettings.Get("VirtualPath");
            //��¼ҳ��ַ
            string loginPage = ConfigurationManager.AppSettings.Get("LoginPage");
            if (Context.User.Identity.IsAuthenticated)
            {
                AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('��û��Ȩ�޽��뱾ҳ��');history.back();</script>");
                    Response.End();
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                Response.Clear();
                Response.Write("<script defer>window.alert('��û��Ȩ�޽��뱾ҳ��ǰ��¼�û��ѹ��ڣ�\\n�����µ�¼�������Ա��ϵ��');parent.location='" + virtualPath + "/" + loginPage + "';</script>");
                Response.End();
            }
        }

        protected void Page_Error(object sender, System.EventArgs e)
        {
            string errMsg = "";
            Exception currentError = Server.GetLastError();
            errMsg += "ϵͳ��������:<br/>" +
                "�����ַ�� " + Request.Url.ToString() + "<br/>" +
                "������Ϣ�� " + currentError.Message.ToString() + "<br/>";
            Response.Write(errMsg);
            Server.ClearError();//Ҫע���������ʹ�ã�����쳣��

        }
        #endregion


        #region URL����
        public virtual string Name
        {
            get
            {
                if ((Request["name"] != null) && (Request["name"].ToString() != ""))
                {
                    return Request.QueryString["name"].Trim();
                }
                return "";
            }
        }
        #endregion
    }

}
