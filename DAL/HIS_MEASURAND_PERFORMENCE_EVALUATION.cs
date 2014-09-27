/**  版本信息模板在安装目录下，可自行修改。
* HIS_MEASURAND_PERFORMENCE_EVALUATION.cs
*
* 功 能： N/A
* 类 名： HIS_MEASURAND_PERFORMENCE_EVALUATION
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/26 14:36:39   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:HIS_MEASURAND_PERFORMENCE_EVALUATION
	/// </summary>
	public partial class HIS_MEASURAND_PERFORMENCE_EVALUATION
	{
		public HIS_MEASURAND_PERFORMENCE_EVALUATION()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "HIS_MEASURAND_PERFORMENCE_EVALUATION"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from HIS_MEASURAND_PERFORMENCE_EVALUATION");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HIS_MEASURAND_PERFORMENCE_EVALUATION(");
			strSql.Append("year,COD,NH3N,TN,TP,CDO_density,TN_density,TP_density,Nutrition_indicators,near_COD_density,near_TP_density,near_TN_density,near_NH3N_density,Grade3_water_percent,Grade5_water_percent,COD_GDP,NH3N_GDP,Sewage_Treatment_Rate,Fertilizer_intensity,Environmental_investment_GDP,Public_satisfaction,Water_consumption_GDP,GDP_Increment,GDP_per_capita,Primary_Industry_GDP,Secondary_industry_GDP,Tertiary_Industry_GDP,population_density,Urbanization_rate)");
			strSql.Append(" values (");
			strSql.Append("@year,@COD,@NH3N,@TN,@TP,@CDO_density,@TN_density,@TP_density,@Nutrition_indicators,@near_COD_density,@near_TP_density,@near_TN_density,@near_NH3N_density,@Grade3_water_percent,@Grade5_water_percent,@COD_GDP,@NH3N_GDP,@Sewage_Treatment_Rate,@Fertilizer_intensity,@Environmental_investment_GDP,@Public_satisfaction,@Water_consumption_GDP,@GDP_Increment,@GDP_per_capita,@Primary_Industry_GDP,@Secondary_industry_GDP,@Tertiary_Industry_GDP,@population_density,@Urbanization_rate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@year", SqlDbType.Int,4),
					new SqlParameter("@COD", SqlDbType.Decimal,9),
					new SqlParameter("@NH3N", SqlDbType.Decimal,9),
					new SqlParameter("@TN", SqlDbType.Decimal,9),
					new SqlParameter("@TP", SqlDbType.Decimal,9),
					new SqlParameter("@CDO_density", SqlDbType.Decimal,9),
					new SqlParameter("@TN_density", SqlDbType.Decimal,9),
					new SqlParameter("@TP_density", SqlDbType.Decimal,9),
					new SqlParameter("@Nutrition_indicators", SqlDbType.Decimal,9),
					new SqlParameter("@near_COD_density", SqlDbType.Decimal,9),
					new SqlParameter("@near_TP_density", SqlDbType.Decimal,9),
					new SqlParameter("@near_TN_density", SqlDbType.Decimal,9),
					new SqlParameter("@near_NH3N_density", SqlDbType.Decimal,9),
					new SqlParameter("@Grade3_water_percent", SqlDbType.Decimal,9),
					new SqlParameter("@Grade5_water_percent", SqlDbType.Decimal,9),
					new SqlParameter("@COD_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@NH3N_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@Sewage_Treatment_Rate", SqlDbType.Decimal,9),
					new SqlParameter("@Fertilizer_intensity", SqlDbType.Decimal,9),
					new SqlParameter("@Environmental_investment_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@Public_satisfaction", SqlDbType.Decimal,9),
					new SqlParameter("@Water_consumption_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@GDP_Increment", SqlDbType.Decimal,9),
					new SqlParameter("@GDP_per_capita", SqlDbType.Decimal,9),
					new SqlParameter("@Primary_Industry_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@Secondary_industry_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@Tertiary_Industry_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@population_density", SqlDbType.Decimal,9),
					new SqlParameter("@Urbanization_rate", SqlDbType.Decimal,9)};
			parameters[0].Value = model.year;
			parameters[1].Value = model.COD;
			parameters[2].Value = model.NH3N;
			parameters[3].Value = model.TN;
			parameters[4].Value = model.TP;
			parameters[5].Value = model.CDO_density;
			parameters[6].Value = model.TN_density;
			parameters[7].Value = model.TP_density;
			parameters[8].Value = model.Nutrition_indicators;
			parameters[9].Value = model.near_COD_density;
			parameters[10].Value = model.near_TP_density;
			parameters[11].Value = model.near_TN_density;
			parameters[12].Value = model.near_NH3N_density;
			parameters[13].Value = model.Grade3_water_percent;
			parameters[14].Value = model.Grade5_water_percent;
			parameters[15].Value = model.COD_GDP;
			parameters[16].Value = model.NH3N_GDP;
			parameters[17].Value = model.Sewage_Treatment_Rate;
			parameters[18].Value = model.Fertilizer_intensity;
			parameters[19].Value = model.Environmental_investment_GDP;
			parameters[20].Value = model.Public_satisfaction;
			parameters[21].Value = model.Water_consumption_GDP;
			parameters[22].Value = model.GDP_Increment;
			parameters[23].Value = model.GDP_per_capita;
			parameters[24].Value = model.Primary_Industry_GDP;
			parameters[25].Value = model.Secondary_industry_GDP;
			parameters[26].Value = model.Tertiary_Industry_GDP;
			parameters[27].Value = model.population_density;
			parameters[28].Value = model.Urbanization_rate;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HIS_MEASURAND_PERFORMENCE_EVALUATION set ");
			strSql.Append("year=@year,");
			strSql.Append("COD=@COD,");
			strSql.Append("NH3N=@NH3N,");
			strSql.Append("TN=@TN,");
			strSql.Append("TP=@TP,");
			strSql.Append("CDO_density=@CDO_density,");
			strSql.Append("TN_density=@TN_density,");
			strSql.Append("TP_density=@TP_density,");
			strSql.Append("Nutrition_indicators=@Nutrition_indicators,");
			strSql.Append("near_COD_density=@near_COD_density,");
			strSql.Append("near_TP_density=@near_TP_density,");
			strSql.Append("near_TN_density=@near_TN_density,");
			strSql.Append("near_NH3N_density=@near_NH3N_density,");
			strSql.Append("Grade3_water_percent=@Grade3_water_percent,");
			strSql.Append("Grade5_water_percent=@Grade5_water_percent,");
			strSql.Append("COD_GDP=@COD_GDP,");
			strSql.Append("NH3N_GDP=@NH3N_GDP,");
			strSql.Append("Sewage_Treatment_Rate=@Sewage_Treatment_Rate,");
			strSql.Append("Fertilizer_intensity=@Fertilizer_intensity,");
			strSql.Append("Environmental_investment_GDP=@Environmental_investment_GDP,");
			strSql.Append("Public_satisfaction=@Public_satisfaction,");
			strSql.Append("Water_consumption_GDP=@Water_consumption_GDP,");
			strSql.Append("GDP_Increment=@GDP_Increment,");
			strSql.Append("GDP_per_capita=@GDP_per_capita,");
			strSql.Append("Primary_Industry_GDP=@Primary_Industry_GDP,");
			strSql.Append("Secondary_industry_GDP=@Secondary_industry_GDP,");
			strSql.Append("Tertiary_Industry_GDP=@Tertiary_Industry_GDP,");
			strSql.Append("population_density=@population_density,");
			strSql.Append("Urbanization_rate=@Urbanization_rate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@year", SqlDbType.Int,4),
					new SqlParameter("@COD", SqlDbType.Decimal,9),
					new SqlParameter("@NH3N", SqlDbType.Decimal,9),
					new SqlParameter("@TN", SqlDbType.Decimal,9),
					new SqlParameter("@TP", SqlDbType.Decimal,9),
					new SqlParameter("@CDO_density", SqlDbType.Decimal,9),
					new SqlParameter("@TN_density", SqlDbType.Decimal,9),
					new SqlParameter("@TP_density", SqlDbType.Decimal,9),
					new SqlParameter("@Nutrition_indicators", SqlDbType.Decimal,9),
					new SqlParameter("@near_COD_density", SqlDbType.Decimal,9),
					new SqlParameter("@near_TP_density", SqlDbType.Decimal,9),
					new SqlParameter("@near_TN_density", SqlDbType.Decimal,9),
					new SqlParameter("@near_NH3N_density", SqlDbType.Decimal,9),
					new SqlParameter("@Grade3_water_percent", SqlDbType.Decimal,9),
					new SqlParameter("@Grade5_water_percent", SqlDbType.Decimal,9),
					new SqlParameter("@COD_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@NH3N_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@Sewage_Treatment_Rate", SqlDbType.Decimal,9),
					new SqlParameter("@Fertilizer_intensity", SqlDbType.Decimal,9),
					new SqlParameter("@Environmental_investment_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@Public_satisfaction", SqlDbType.Decimal,9),
					new SqlParameter("@Water_consumption_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@GDP_Increment", SqlDbType.Decimal,9),
					new SqlParameter("@GDP_per_capita", SqlDbType.Decimal,9),
					new SqlParameter("@Primary_Industry_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@Secondary_industry_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@Tertiary_Industry_GDP", SqlDbType.Decimal,9),
					new SqlParameter("@population_density", SqlDbType.Decimal,9),
					new SqlParameter("@Urbanization_rate", SqlDbType.Decimal,9),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.year;
			parameters[1].Value = model.COD;
			parameters[2].Value = model.NH3N;
			parameters[3].Value = model.TN;
			parameters[4].Value = model.TP;
			parameters[5].Value = model.CDO_density;
			parameters[6].Value = model.TN_density;
			parameters[7].Value = model.TP_density;
			parameters[8].Value = model.Nutrition_indicators;
			parameters[9].Value = model.near_COD_density;
			parameters[10].Value = model.near_TP_density;
			parameters[11].Value = model.near_TN_density;
			parameters[12].Value = model.near_NH3N_density;
			parameters[13].Value = model.Grade3_water_percent;
			parameters[14].Value = model.Grade5_water_percent;
			parameters[15].Value = model.COD_GDP;
			parameters[16].Value = model.NH3N_GDP;
			parameters[17].Value = model.Sewage_Treatment_Rate;
			parameters[18].Value = model.Fertilizer_intensity;
			parameters[19].Value = model.Environmental_investment_GDP;
			parameters[20].Value = model.Public_satisfaction;
			parameters[21].Value = model.Water_consumption_GDP;
			parameters[22].Value = model.GDP_Increment;
			parameters[23].Value = model.GDP_per_capita;
			parameters[24].Value = model.Primary_Industry_GDP;
			parameters[25].Value = model.Secondary_industry_GDP;
			parameters[26].Value = model.Tertiary_Industry_GDP;
			parameters[27].Value = model.population_density;
			parameters[28].Value = model.Urbanization_rate;
			parameters[29].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HIS_MEASURAND_PERFORMENCE_EVALUATION ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HIS_MEASURAND_PERFORMENCE_EVALUATION ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,year,COD,NH3N,TN,TP,CDO_density,TN_density,TP_density,Nutrition_indicators,near_COD_density,near_TP_density,near_TN_density,near_NH3N_density,Grade3_water_percent,Grade5_water_percent,COD_GDP,NH3N_GDP,Sewage_Treatment_Rate,Fertilizer_intensity,Environmental_investment_GDP,Public_satisfaction,Water_consumption_GDP,GDP_Increment,GDP_per_capita,Primary_Industry_GDP,Secondary_industry_GDP,Tertiary_Industry_GDP,population_density,Urbanization_rate from HIS_MEASURAND_PERFORMENCE_EVALUATION ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION model=new Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION DataRowToModel(DataRow row)
		{
			Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION model=new Maticsoft.Model.HIS_MEASURAND_PERFORMENCE_EVALUATION();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["year"]!=null && row["year"].ToString()!="")
				{
					model.year=int.Parse(row["year"].ToString());
				}
				if(row["COD"]!=null && row["COD"].ToString()!="")
				{
					model.COD=decimal.Parse(row["COD"].ToString());
				}
				if(row["NH3N"]!=null && row["NH3N"].ToString()!="")
				{
					model.NH3N=decimal.Parse(row["NH3N"].ToString());
				}
				if(row["TN"]!=null && row["TN"].ToString()!="")
				{
					model.TN=decimal.Parse(row["TN"].ToString());
				}
				if(row["TP"]!=null && row["TP"].ToString()!="")
				{
					model.TP=decimal.Parse(row["TP"].ToString());
				}
				if(row["CDO_density"]!=null && row["CDO_density"].ToString()!="")
				{
					model.CDO_density=decimal.Parse(row["CDO_density"].ToString());
				}
				if(row["TN_density"]!=null && row["TN_density"].ToString()!="")
				{
					model.TN_density=decimal.Parse(row["TN_density"].ToString());
				}
				if(row["TP_density"]!=null && row["TP_density"].ToString()!="")
				{
					model.TP_density=decimal.Parse(row["TP_density"].ToString());
				}
				if(row["Nutrition_indicators"]!=null && row["Nutrition_indicators"].ToString()!="")
				{
					model.Nutrition_indicators=decimal.Parse(row["Nutrition_indicators"].ToString());
				}
				if(row["near_COD_density"]!=null && row["near_COD_density"].ToString()!="")
				{
					model.near_COD_density=decimal.Parse(row["near_COD_density"].ToString());
				}
				if(row["near_TP_density"]!=null && row["near_TP_density"].ToString()!="")
				{
					model.near_TP_density=decimal.Parse(row["near_TP_density"].ToString());
				}
				if(row["near_TN_density"]!=null && row["near_TN_density"].ToString()!="")
				{
					model.near_TN_density=decimal.Parse(row["near_TN_density"].ToString());
				}
				if(row["near_NH3N_density"]!=null && row["near_NH3N_density"].ToString()!="")
				{
					model.near_NH3N_density=decimal.Parse(row["near_NH3N_density"].ToString());
				}
				if(row["Grade3_water_percent"]!=null && row["Grade3_water_percent"].ToString()!="")
				{
					model.Grade3_water_percent=decimal.Parse(row["Grade3_water_percent"].ToString());
				}
				if(row["Grade5_water_percent"]!=null && row["Grade5_water_percent"].ToString()!="")
				{
					model.Grade5_water_percent=decimal.Parse(row["Grade5_water_percent"].ToString());
				}
				if(row["COD_GDP"]!=null && row["COD_GDP"].ToString()!="")
				{
					model.COD_GDP=decimal.Parse(row["COD_GDP"].ToString());
				}
				if(row["NH3N_GDP"]!=null && row["NH3N_GDP"].ToString()!="")
				{
					model.NH3N_GDP=decimal.Parse(row["NH3N_GDP"].ToString());
				}
				if(row["Sewage_Treatment_Rate"]!=null && row["Sewage_Treatment_Rate"].ToString()!="")
				{
					model.Sewage_Treatment_Rate=decimal.Parse(row["Sewage_Treatment_Rate"].ToString());
				}
				if(row["Fertilizer_intensity"]!=null && row["Fertilizer_intensity"].ToString()!="")
				{
					model.Fertilizer_intensity=decimal.Parse(row["Fertilizer_intensity"].ToString());
				}
				if(row["Environmental_investment_GDP"]!=null && row["Environmental_investment_GDP"].ToString()!="")
				{
					model.Environmental_investment_GDP=decimal.Parse(row["Environmental_investment_GDP"].ToString());
				}
				if(row["Public_satisfaction"]!=null && row["Public_satisfaction"].ToString()!="")
				{
					model.Public_satisfaction=decimal.Parse(row["Public_satisfaction"].ToString());
				}
				if(row["Water_consumption_GDP"]!=null && row["Water_consumption_GDP"].ToString()!="")
				{
					model.Water_consumption_GDP=decimal.Parse(row["Water_consumption_GDP"].ToString());
				}
				if(row["GDP_Increment"]!=null && row["GDP_Increment"].ToString()!="")
				{
					model.GDP_Increment=decimal.Parse(row["GDP_Increment"].ToString());
				}
				if(row["GDP_per_capita"]!=null && row["GDP_per_capita"].ToString()!="")
				{
					model.GDP_per_capita=decimal.Parse(row["GDP_per_capita"].ToString());
				}
				if(row["Primary_Industry_GDP"]!=null && row["Primary_Industry_GDP"].ToString()!="")
				{
					model.Primary_Industry_GDP=decimal.Parse(row["Primary_Industry_GDP"].ToString());
				}
				if(row["Secondary_industry_GDP"]!=null && row["Secondary_industry_GDP"].ToString()!="")
				{
					model.Secondary_industry_GDP=decimal.Parse(row["Secondary_industry_GDP"].ToString());
				}
				if(row["Tertiary_Industry_GDP"]!=null && row["Tertiary_Industry_GDP"].ToString()!="")
				{
					model.Tertiary_Industry_GDP=decimal.Parse(row["Tertiary_Industry_GDP"].ToString());
				}
				if(row["population_density"]!=null && row["population_density"].ToString()!="")
				{
					model.population_density=decimal.Parse(row["population_density"].ToString());
				}
				if(row["Urbanization_rate"]!=null && row["Urbanization_rate"].ToString()!="")
				{
					model.Urbanization_rate=decimal.Parse(row["Urbanization_rate"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,year,COD,NH3N,TN,TP,CDO_density,TN_density,TP_density,Nutrition_indicators,near_COD_density,near_TP_density,near_TN_density,near_NH3N_density,Grade3_water_percent,Grade5_water_percent,COD_GDP,NH3N_GDP,Sewage_Treatment_Rate,Fertilizer_intensity,Environmental_investment_GDP,Public_satisfaction,Water_consumption_GDP,GDP_Increment,GDP_per_capita,Primary_Industry_GDP,Secondary_industry_GDP,Tertiary_Industry_GDP,population_density,Urbanization_rate ");
			strSql.Append(" FROM HIS_MEASURAND_PERFORMENCE_EVALUATION ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得年份
        /// </summary>
        public DataSet GetYearList( )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct");
           
            strSql.Append(" year");
            strSql.Append(" FROM HIS_MEASURAND_PERFORMENCE_EVALUATION ");
           
            strSql.Append(" order by year");
            return DbHelperSQL.Query(strSql.ToString());
        }


		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,year,COD,NH3N,TN,TP,CDO_density,TN_density,TP_density,Nutrition_indicators,near_COD_density,near_TP_density,near_TN_density,near_NH3N_density,Grade3_water_percent,Grade5_water_percent,COD_GDP,NH3N_GDP,Sewage_Treatment_Rate,Fertilizer_intensity,Environmental_investment_GDP,Public_satisfaction,Water_consumption_GDP,GDP_Increment,GDP_per_capita,Primary_Industry_GDP,Secondary_industry_GDP,Tertiary_Industry_GDP,population_density,Urbanization_rate ");
			strSql.Append(" FROM HIS_MEASURAND_PERFORMENCE_EVALUATION ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM HIS_MEASURAND_PERFORMENCE_EVALUATION ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from HIS_MEASURAND_PERFORMENCE_EVALUATION T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "HIS_MEASURAND_PERFORMENCE_EVALUATION";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

