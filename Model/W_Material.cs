using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 实体类W_Material 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class W_Material
	{
		public W_Material()
		{}
        #region Model
        private int _id;
        private string _name;
        private DateTime? _begindate;
        private DateTime? _enddate;
        private string _number;
        private string _address;
        private string _outdisplay;
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Begindate
        {
            set { _begindate = value; }
            get { return _begindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Enddate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Outdisplay
        {
            set { _outdisplay = value; }
            get { return _outdisplay; }
        }
        #endregion Model

	}
}

