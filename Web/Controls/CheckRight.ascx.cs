namespace Maticsoft.Web.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using LTP.Accounts.Bus;
	using System.Configuration;
	using System.Web.Security;

	/// <summary>
	///	CheckRight ��ժҪ˵����
	/// </summary>
	public partial class CheckRight : System.Web.UI.UserControl
	{        
        //Ȩ�ޱ��룬������֤�û��Ƿ�ӵ�и�Ȩ��
        //public int PermissionID = -1;
        private int permissionid = -1;
        public int PermissionID
        {
            set
            {
                permissionid = value;
            }
            get
            {
                return permissionid;
            }
        }
		protected void Page_Load(object sender, System.EventArgs e)
		{			
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{			
			InitializeComponent();
			base.OnInit(e);
		}		
		/// <summary>
		///	�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///	�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            if (!Page.IsPostBack)
            {
                //��վ����������Ŀ¼
                string virtualPath = ConfigurationManager.AppSettings.Get("VirtualPath");
                //��¼ҳ��ַ
                string loginPage = ConfigurationManager.AppSettings.Get("LoginPage");
                if (Context.User.Identity.IsAuthenticated)
                {
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
                    if (Session["UserInfo"] == null)
                    {
                        LTP.Accounts.Bus.User currentUser = new LTP.Accounts.Bus.User(user);
                        Session["UserInfo"] = currentUser;
                        Session["Style"] = currentUser.Style;
                        Response.Write("<script defer>location.reload();</script>");
                    }
                    if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
                    {
                        Response.Clear();
                        Response.Write("<script defer>window.alert('��û��Ȩ�޽��뱾ҳ��\\n�����µ�¼�������Ա��ϵ');history.back();</script>");
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
		}
		#endregion
	}
}
