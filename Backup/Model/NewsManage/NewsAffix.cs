using System;
namespace Maticsoft.Model.NewsManage
{
    /// <summary>
    /// ʵ����T_NewsImages ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class NewsAffix
    {
        public NewsAffix()
        { }
        #region Model
        private int _id;
        private int? _newsid;
        private string _descrip;
        private string _linkurl;
        private DateTime? _issuedate;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? NewsId
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Descrip
        {
            set { _descrip = value; }
            get { return _descrip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? IssueDate
        {
            set { _issuedate = value; }
            get { return _issuedate; }
        }
        #endregion Model

    }
}

