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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:MEASURAND_PREDICT_SECTION_2012
	/// </summary>
	public partial class MEASURAND_PREDICT_SECTION_2012
	{
		public MEASURAND_PREDICT_SECTION_2012()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.MEASURAND_PREDICT_SECTION_2012 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MEASURAND_PREDICT_SECTION_2012(");
			strSql.Append("TT,II,COD,NH4,TN,TP)");
			strSql.Append(" values (");
			strSql.Append("@TT,@II,@COD,@NH4,@TN,@TP)");
			SqlParameter[] parameters = {
					new SqlParameter("@TT", SqlDbType.Int,4),
					new SqlParameter("@II", SqlDbType.Int,4),
					new SqlParameter("@COD", SqlDbType.Decimal,9),
					new SqlParameter("@NH4", SqlDbType.Decimal,9),
					new SqlParameter("@TN", SqlDbType.Decimal,9),
					new SqlParameter("@TP", SqlDbType.Decimal,9)};
			parameters[0].Value = model.TT;
			parameters[1].Value = model.II;
			parameters[2].Value = model.COD;
			parameters[3].Value = model.NH4;
			parameters[4].Value = model.TN;
			parameters[5].Value = model.TP;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.MEASURAND_PREDICT_SECTION_2012 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MEASURAND_PREDICT_SECTION_2012 set ");
			strSql.Append("TT=@TT,");
			strSql.Append("II=@II,");
			strSql.Append("COD=@COD,");
			strSql.Append("NH4=@NH4,");
			strSql.Append("TN=@TN,");
			strSql.Append("TP=@TP");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@TT", SqlDbType.Int,4),
					new SqlParameter("@II", SqlDbType.Int,4),
					new SqlParameter("@COD", SqlDbType.Decimal,9),
					new SqlParameter("@NH4", SqlDbType.Decimal,9),
					new SqlParameter("@TN", SqlDbType.Decimal,9),
					new SqlParameter("@TP", SqlDbType.Decimal,9)};
			parameters[0].Value = model.TT;
			parameters[1].Value = model.II;
			parameters[2].Value = model.COD;
			parameters[3].Value = model.NH4;
			parameters[4].Value = model.TN;
			parameters[5].Value = model.TP;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MEASURAND_PREDICT_SECTION_2012 ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.MEASURAND_PREDICT_SECTION_2012 GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TT,II,COD,NH4,TN,TP from MEASURAND_PREDICT_SECTION_2012 ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.MEASURAND_PREDICT_SECTION_2012 model=new Maticsoft.Model.MEASURAND_PREDICT_SECTION_2012();
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
		public Maticsoft.Model.MEASURAND_PREDICT_SECTION_2012 DataRowToModel(DataRow row)
		{
			Maticsoft.Model.MEASURAND_PREDICT_SECTION_2012 model=new Maticsoft.Model.MEASURAND_PREDICT_SECTION_2012();
			if (row != null)
			{
				if(row["TT"]!=null && row["TT"].ToString()!="")
				{
					model.TT=int.Parse(row["TT"].ToString());
				}
				if(row["II"]!=null && row["II"].ToString()!="")
				{
					model.II=int.Parse(row["II"].ToString());
				}
				if(row["COD"]!=null && row["COD"].ToString()!="")
				{
					model.COD=decimal.Parse(row["COD"].ToString());
				}
				if(row["NH4"]!=null && row["NH4"].ToString()!="")
				{
					model.NH4=decimal.Parse(row["NH4"].ToString());
				}
				if(row["TN"]!=null && row["TN"].ToString()!="")
				{
					model.TN=decimal.Parse(row["TN"].ToString());
				}
				if(row["TP"]!=null && row["TP"].ToString()!="")
				{
					model.TP=decimal.Parse(row["TP"].ToString());
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
			strSql.Append("select TT,II,COD,NH4,TN,TP ");
			strSql.Append(" FROM MEASURAND_PREDICT_SECTION_2012 ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" TT,II,COD,NH4,TN,TP ");
			strSql.Append(" FROM MEASURAND_PREDICT_SECTION_2012 ");
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
			strSql.Append("select count(1) FROM MEASURAND_PREDICT_SECTION_2012 ");
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
				strSql.Append("order by T.II desc");
			}
			strSql.Append(")AS Row, T.*  from MEASURAND_PREDICT_SECTION_2012 T ");
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
			parameters[0].Value = "MEASURAND_PREDICT_SECTION_2012";
			parameters[1].Value = "II";
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

