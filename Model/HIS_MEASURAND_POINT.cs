﻿/**  版本信息模板在安装目录下，可自行修改。
* HIS_MEASURAND_POINT.cs
*
* 功 能： N/A
* 类 名： HIS_MEASURAND_POINT
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/16 15:54:21   N/A    初版
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
	/// HIS_MEASURAND_POINT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HIS_MEASURAND_POINT
	{
		public HIS_MEASURAND_POINT()
		{}
		#region Model
		private long _id;
		private DateTime _systime;
		private decimal? _codmn;
		private decimal? _nh3_n;
		private decimal? _tp;
		private decimal? _tn;
		private decimal? _flow;
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
		public DateTime systime
		{
			set{ _systime=value;}
			get{return _systime;}
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
		#endregion Model

	}
}

