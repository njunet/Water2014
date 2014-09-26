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
    /// 页面基类
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new System.EventHandler(this.Page_Load);
            this.Error += new System.EventHandler(this.Page_Error);
        }

        #region 权限检查
        /// <summary>
        /// 页面访问权限ID。
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
        /// 当前用户信息
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

        #region 页面事件
        private void Page_Load(object sender, System.EventArgs e)
        {
            //网站域名或虚拟目录
            string virtualPath = ConfigurationManager.AppSettings.Get("VirtualPath");
            //登录页地址
            string loginPage = ConfigurationManager.AppSettings.Get("LoginPage");
            if (Context.User.Identity.IsAuthenticated)
            {
                AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('您没有权限进入本页！');history.back();</script>");
                    Response.End();
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                Response.Clear();
                Response.Write("<script defer>window.alert('您没有权限进入本页或当前登录用户已过期！\\n请重新登录或与管理员联系！');parent.location='" + virtualPath + "/" + loginPage + "';</script>");
                Response.End();
            }
        }

        protected void Page_Error(object sender, System.EventArgs e)
        {
            string errMsg = "";
            Exception currentError = Server.GetLastError();
            errMsg += "系统发生错误:<br/>" +
                "错误地址： " + Request.Url.ToString() + "<br/>" +
                "错误信息： " + currentError.Message.ToString() + "<br/>";
            Response.Write(errMsg);
            Server.ClearError();//要注意这句代码的使用，清除异常。

        }
        #endregion


        #region URL参数
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
