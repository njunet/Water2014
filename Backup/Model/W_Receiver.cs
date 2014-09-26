using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 实体类W_Receiver 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class W_Receiver
	{
		public W_Receiver()
		{}
		#region Model
		private int _id;
		private string _receiver;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		#endregion Model

	}
}

