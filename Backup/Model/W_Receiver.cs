using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ʵ����W_Receiver ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

