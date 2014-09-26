/**  版本信息模板在安装目录下，可自行修改。
* MEASURAND_STATION.cs
*
* 功 能： N/A
* 类 名： MEASURAND_STATION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/18 11:02:02   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// MEASURAND_STATION:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MEASURAND_STATION
	{
		public MEASURAND_STATION()
		{}
		#region Model
		private long _id;
		private string _station_name;
		private int? _state;
		private decimal? _posx;
		private decimal? _posy;
		private int? _dynamic;
		private string _procince_city;
		private long? _river_id;
		private string _comments;
		private string _address;
		private string _river_name;
		/// <summary>
		/// 
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string station_name
		{
			set{ _station_name=value;}
			get{return _station_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? posx
		{
			set{ _posx=value;}
			get{return _posx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? posy
		{
			set{ _posy=value;}
			get{return _posy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dynamic
		{
			set{ _dynamic=value;}
			get{return _dynamic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string procince_city
		{
			set{ _procince_city=value;}
			get{return _procince_city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? river_id
		{
			set{ _river_id=value;}
			get{return _river_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string river_name
		{
			set{ _river_name=value;}
			get{return _river_name;}
		}
		#endregion Model

	}
}

