using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ʵ����W_Receivestate ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class W_Receivestate
	{
		public W_Receivestate()
		{}
		#region Model
		private int _id;
		private int _materialid;
		private string _receiverid;
		private string _dormacy;
		private DateTime? _issuretime;
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
		public int MaterialId
		{
			set{ _materialid=value;}
			get{return _materialid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceiverId
		{
			set{ _receiverid=value;}
			get{return _receiverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dormacy
		{
			set{ _dormacy=value;}
			get{return _dormacy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? IssureTime
		{
			set{ _issuretime=value;}
			get{return _issuretime;}
		}
		#endregion Model

	}
}

