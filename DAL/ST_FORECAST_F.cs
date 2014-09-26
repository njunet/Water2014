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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:ST_FORECAST_F
	/// </summary>
	public partial class ST_FORECAST_F
	{
		public ST_FORECAST_F()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string STCD,DateTime YMDH,DateTime FYMDH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ST_FORECAST_F");
			strSql.Append(" where STCD=@STCD and YMDH=@YMDH and FYMDH=@FYMDH ");
			SqlParameter[] parameters = {
					new SqlParameter("@STCD", SqlDbType.Char,8),
					new SqlParameter("@YMDH", SqlDbType.DateTime),
					new SqlParameter("@FYMDH", SqlDbType.DateTime)			};
			parameters[0].Value = STCD;
			parameters[1].Value = YMDH;
			parameters[2].Value = FYMDH;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.ST_FORECAST_F model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ST_FORECAST_F(");
			strSql.Append("STCD,YMDH,FYMDH,CODMn,NH3_N,TP,TN,flow,UNITNAME,PLCD)");
			strSql.Append(" values (");
			strSql.Append("@STCD,@YMDH,@FYMDH,@CODMn,@NH3_N,@TP,@TN,@flow,@UNITNAME,@PLCD)");
			SqlParameter[] parameters = {
					new SqlParameter("@STCD", SqlDbType.Char,8),
					new SqlParameter("@YMDH", SqlDbType.DateTime),
					new SqlParameter("@FYMDH", SqlDbType.DateTime),
					new SqlParameter("@CODMn", SqlDbType.Decimal,5),
					new SqlParameter("@NH3_N", SqlDbType.Decimal,5),
					new SqlParameter("@TP", SqlDbType.Decimal,5),
					new SqlParameter("@TN", SqlDbType.Decimal,5),
					new SqlParameter("@flow", SqlDbType.Decimal,9),
					new SqlParameter("@UNITNAME", SqlDbType.Char,30),
					new SqlParameter("@PLCD", SqlDbType.Char,20)};
			parameters[0].Value = model.STCD;
			parameters[1].Value = model.YMDH;
			parameters[2].Value = model.FYMDH;
			parameters[3].Value = model.CODMn;
			parameters[4].Value = model.NH3_N;
			parameters[5].Value = model.TP;
			parameters[6].Value = model.TN;
			parameters[7].Value = model.flow;
			parameters[8].Value = model.UNITNAME;
			parameters[9].Value = model.PLCD;

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
		public bool Update(Maticsoft.Model.ST_FORECAST_F model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ST_FORECAST_F set ");
			strSql.Append("CODMn=@CODMn,");
			strSql.Append("NH3_N=@NH3_N,");
			strSql.Append("TP=@TP,");
			strSql.Append("TN=@TN,");
			strSql.Append("flow=@flow,");
			strSql.Append("UNITNAME=@UNITNAME,");
			strSql.Append("PLCD=@PLCD");
			strSql.Append(" where STCD=@STCD and YMDH=@YMDH and FYMDH=@FYMDH ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODMn", SqlDbType.Decimal,5),
					new SqlParameter("@NH3_N", SqlDbType.Decimal,5),
					new SqlParameter("@TP", SqlDbType.Decimal,5),
					new SqlParameter("@TN", SqlDbType.Decimal,5),
					new SqlParameter("@flow", SqlDbType.Decimal,9),
					new SqlParameter("@UNITNAME", SqlDbType.Char,30),
					new SqlParameter("@PLCD", SqlDbType.Char,20),
					new SqlParameter("@STCD", SqlDbType.Char,8),
					new SqlParameter("@YMDH", SqlDbType.DateTime),
					new SqlParameter("@FYMDH", SqlDbType.DateTime)};
			parameters[0].Value = model.CODMn;
			parameters[1].Value = model.NH3_N;
			parameters[2].Value = model.TP;
			parameters[3].Value = model.TN;
			parameters[4].Value = model.flow;
			parameters[5].Value = model.UNITNAME;
			parameters[6].Value = model.PLCD;
			parameters[7].Value = model.STCD;
			parameters[8].Value = model.YMDH;
			parameters[9].Value = model.FYMDH;

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
		public bool Delete(string STCD,DateTime YMDH,DateTime FYMDH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ST_FORECAST_F ");
			strSql.Append(" where STCD=@STCD and YMDH=@YMDH and FYMDH=@FYMDH ");
			SqlParameter[] parameters = {
					new SqlParameter("@STCD", SqlDbType.Char,8),
					new SqlParameter("@YMDH", SqlDbType.DateTime),
					new SqlParameter("@FYMDH", SqlDbType.DateTime)			};
			parameters[0].Value = STCD;
			parameters[1].Value = YMDH;
			parameters[2].Value = FYMDH;

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
		public Maticsoft.Model.ST_FORECAST_F GetModel(string STCD,DateTime YMDH,DateTime FYMDH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 STCD,YMDH,FYMDH,CODMn,NH3_N,TP,TN,flow,UNITNAME,PLCD from ST_FORECAST_F ");
			strSql.Append(" where STCD=@STCD and YMDH=@YMDH and FYMDH=@FYMDH ");
			SqlParameter[] parameters = {
					new SqlParameter("@STCD", SqlDbType.Char,8),
					new SqlParameter("@YMDH", SqlDbType.DateTime),
					new SqlParameter("@FYMDH", SqlDbType.DateTime)			};
			parameters[0].Value = STCD;
			parameters[1].Value = YMDH;
			parameters[2].Value = FYMDH;

			Maticsoft.Model.ST_FORECAST_F model=new Maticsoft.Model.ST_FORECAST_F();
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
		public Maticsoft.Model.ST_FORECAST_F DataRowToModel(DataRow row)
		{
			Maticsoft.Model.ST_FORECAST_F model=new Maticsoft.Model.ST_FORECAST_F();
			if (row != null)
			{
				if(row["STCD"]!=null)
				{
					model.STCD=row["STCD"].ToString();
				}
				if(row["YMDH"]!=null && row["YMDH"].ToString()!="")
				{
					model.YMDH=DateTime.Parse(row["YMDH"].ToString());
				}
				if(row["FYMDH"]!=null && row["FYMDH"].ToString()!="")
				{
					model.FYMDH=DateTime.Parse(row["FYMDH"].ToString());
				}
				if(row["CODMn"]!=null && row["CODMn"].ToString()!="")
				{
					model.CODMn=decimal.Parse(row["CODMn"].ToString());
				}
				if(row["NH3_N"]!=null && row["NH3_N"].ToString()!="")
				{
					model.NH3_N=decimal.Parse(row["NH3_N"].ToString());
				}
				if(row["TP"]!=null && row["TP"].ToString()!="")
				{
					model.TP=decimal.Parse(row["TP"].ToString());
				}
				if(row["TN"]!=null && row["TN"].ToString()!="")
				{
					model.TN=decimal.Parse(row["TN"].ToString());
				}
				if(row["flow"]!=null && row["flow"].ToString()!="")
				{
					model.flow=decimal.Parse(row["flow"].ToString());
				}
				if(row["UNITNAME"]!=null)
				{
					model.UNITNAME=row["UNITNAME"].ToString();
				}
				if(row["PLCD"]!=null)
				{
					model.PLCD=row["PLCD"].ToString();
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
			strSql.Append("select STCD,YMDH,FYMDH,CODMn,NH3_N,TP,TN,flow,UNITNAME,PLCD ");
			strSql.Append(" FROM ST_FORECAST_F ");
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
			strSql.Append(" STCD,YMDH,FYMDH,CODMn,NH3_N,TP,TN,flow,UNITNAME,PLCD ");
			strSql.Append(" FROM ST_FORECAST_F ");
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
			strSql.Append("select count(1) FROM ST_FORECAST_F ");
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
				strSql.Append("order by T.FYMDH desc");
			}
			strSql.Append(")AS Row, T.*  from ST_FORECAST_F T ");
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
			parameters[0].Value = "ST_FORECAST_F";
			parameters[1].Value = "FYMDH";
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

