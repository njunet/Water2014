/**  版本信息模板在安装目录下，可自行修改。
* HIS_MEASURAND_PERFORMENCE_EVALUATION.cs
*
* 功 能： N/A
* 类 名： HIS_MEASURAND_PERFORMENCE_EVALUATION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/26 14:36:38   N/A    初版
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
	/// HIS_MEASURAND_PERFORMENCE_EVALUATION:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HIS_MEASURAND_PERFORMENCE_EVALUATION
	{
		public HIS_MEASURAND_PERFORMENCE_EVALUATION()
		{}
		#region Model
		private int _id;
		private int _year;
		private decimal _cod;
		private decimal _nh3n;
		private decimal _tn;
		private decimal _tp;
		private decimal _cdo_density;
		private decimal _tn_density;
		private decimal _tp_density;
		private decimal _nutrition_indicators;
		private decimal _near_cod_density;
		private decimal _near_tp_density;
		private decimal _near_tn_density;
		private decimal _near_nh3n_density;
		private decimal _grade3_water_percent;
		private decimal _grade5_water_percent;
		private decimal _cod_gdp;
		private decimal _nh3n_gdp;
		private decimal _sewage_treatment_rate;
		private decimal _fertilizer_intensity;
		private decimal _environmental_investment_gdp;
		private decimal _public_satisfaction;
		private decimal _water_consumption_gdp;
		private decimal _gdp_increment;
		private decimal _gdp_per_capita;
		private decimal _primary_industry_gdp;
		private decimal _secondary_industry_gdp;
		private decimal _tertiary_industry_gdp;
		private decimal _population_density;
		private decimal _urbanization_rate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal COD
		{
			set{ _cod=value;}
			get{return _cod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal NH3N
		{
			set{ _nh3n=value;}
			get{return _nh3n;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TN
		{
			set{ _tn=value;}
			get{return _tn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TP
		{
			set{ _tp=value;}
			get{return _tp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CDO_density
		{
			set{ _cdo_density=value;}
			get{return _cdo_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TN_density
		{
			set{ _tn_density=value;}
			get{return _tn_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TP_density
		{
			set{ _tp_density=value;}
			get{return _tp_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Nutrition_indicators
		{
			set{ _nutrition_indicators=value;}
			get{return _nutrition_indicators;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal near_COD_density
		{
			set{ _near_cod_density=value;}
			get{return _near_cod_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal near_TP_density
		{
			set{ _near_tp_density=value;}
			get{return _near_tp_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal near_TN_density
		{
			set{ _near_tn_density=value;}
			get{return _near_tn_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal near_NH3N_density
		{
			set{ _near_nh3n_density=value;}
			get{return _near_nh3n_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Grade3_water_percent
		{
			set{ _grade3_water_percent=value;}
			get{return _grade3_water_percent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Grade5_water_percent
		{
			set{ _grade5_water_percent=value;}
			get{return _grade5_water_percent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal COD_GDP
		{
			set{ _cod_gdp=value;}
			get{return _cod_gdp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal NH3N_GDP
		{
			set{ _nh3n_gdp=value;}
			get{return _nh3n_gdp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Sewage_Treatment_Rate
		{
			set{ _sewage_treatment_rate=value;}
			get{return _sewage_treatment_rate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Fertilizer_intensity
		{
			set{ _fertilizer_intensity=value;}
			get{return _fertilizer_intensity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Environmental_investment_GDP
		{
			set{ _environmental_investment_gdp=value;}
			get{return _environmental_investment_gdp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Public_satisfaction
		{
			set{ _public_satisfaction=value;}
			get{return _public_satisfaction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Water_consumption_GDP
		{
			set{ _water_consumption_gdp=value;}
			get{return _water_consumption_gdp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal GDP_Increment
		{
			set{ _gdp_increment=value;}
			get{return _gdp_increment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal GDP_per_capita
		{
			set{ _gdp_per_capita=value;}
			get{return _gdp_per_capita;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Primary_Industry_GDP
		{
			set{ _primary_industry_gdp=value;}
			get{return _primary_industry_gdp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Secondary_industry_GDP
		{
			set{ _secondary_industry_gdp=value;}
			get{return _secondary_industry_gdp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Tertiary_Industry_GDP
		{
			set{ _tertiary_industry_gdp=value;}
			get{return _tertiary_industry_gdp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal population_density
		{
			set{ _population_density=value;}
			get{return _population_density;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Urbanization_rate
		{
			set{ _urbanization_rate=value;}
			get{return _urbanization_rate;}
		}
		#endregion Model

	}
}

