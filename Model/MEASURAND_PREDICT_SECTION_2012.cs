/**  版本信息模板在安装目录下，可自行修改。
* MEASURAND_PREDICT_SECTION_2012.cs
*
* 功 能： N/A
* 类 名： MEASURAND_PREDICT_SECTION_2012
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/9 21:38:44   N/A    初版
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
	/// MEASURAND_PREDICT_SECTION_2012:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MEASURAND_PREDICT_SECTION_2012
	{
		public MEASURAND_PREDICT_SECTION_2012()
		{}
		#region Model
		private int _tt;
		private int _ii;
		private decimal? _cod;
		private decimal? _nh4;
		private decimal? _tn;
		private decimal? _tp;
		/// <summary>
		/// 
		/// </summary>
		public int TT
		{
			set{ _tt=value;}
			get{return _tt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int II
		{
			set{ _ii=value;}
			get{return _ii;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? COD
		{
			set{ _cod=value;}
			get{return _cod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NH4
		{
			set{ _nh4=value;}
			get{return _nh4;}
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
		public decimal? TP
		{
			set{ _tp=value;}
			get{return _tp;}
		}
		#endregion Model

	}
}

