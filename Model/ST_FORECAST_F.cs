/**  版本信息模板在安装目录下，可自行修改。
* ST_FORECAST_F.cs
*
* 功 能： N/A
* 类 名： ST_FORECAST_F
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/6/4 10:07:24   N/A    初版
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
	/// ST_FORECAST_F:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ST_FORECAST_F
	{
		public ST_FORECAST_F()
		{}
		#region Model
		private string _stcd;
		private DateTime _ymdh;
		private DateTime _fymdh;
		private decimal? _codmn;
		private decimal? _nh3_n;
		private decimal? _tp;
		private decimal? _tn;
		private decimal? _flow;
		private string _unitname;
		private string _plcd;
		/// <summary>
		/// 
		/// </summary>
		public string STCD
		{
			set{ _stcd=value;}
			get{return _stcd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime YMDH
		{
			set{ _ymdh=value;}
			get{return _ymdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime FYMDH
		{
			set{ _fymdh=value;}
			get{return _fymdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CODMn
		{
			set{ _codmn=value;}
			get{return _codmn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NH3_N
		{
			set{ _nh3_n=value;}
			get{return _nh3_n;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TP
		{
			set{ _tp=value;}
			get{return _tp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TN
		{
			set{ _tn=value;}
			get{return _tn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? flow
		{
			set{ _flow=value;}
			get{return _flow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UNITNAME
		{
			set{ _unitname=value;}
			get{return _unitname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PLCD
		{
			set{ _plcd=value;}
			get{return _plcd;}
		}
		#endregion Model

	}
}

