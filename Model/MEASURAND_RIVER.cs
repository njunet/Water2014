/**  版本信息模板在安装目录下，可自行修改。
* MEASURAND_RIVER.cs
*
* 功 能： N/A
* 类 名： MEASURAND_RIVER
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
	/// MEASURAND_RIVER:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MEASURAND_RIVER
	{
		public MEASURAND_RIVER()
		{}
		#region Model
		private long _river_id;
		private string _river_name;
		/// <summary>
		/// 
		/// </summary>
		public long river_id
		{
			set{ _river_id=value;}
			get{return _river_id;}
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

