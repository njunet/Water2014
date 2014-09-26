/**  版本信息模板在安装目录下，可自行修改。
* HIS_MEASURAND_DischargeAmount_Day.cs
*
* 功 能： N/A
* 类 名： HIS_MEASURAND_DischargeAmount_Day
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/18 9:44:44   N/A    初版
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
	/// 数据访问类:HIS_MEASURAND_DischargeAmount_Day
	/// </summary>
	public partial class HIS_MEASURAND_DischargeAmount_Day
	{
		public HIS_MEASURAND_DischargeAmount_Day()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.HIS_MEASURAND_DischargeAmount_Day model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HIS_MEASURAND_DischargeAmount_Day(");
			strSql.Append("id,station_name,date,CODMn,NH3_N,TP,TN,flow)");
			strSql.Append(" values (");
			strSql.Append("@id,@station_name,@date,@CODMn,@NH3_N,@TP,@TN,@flow)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@station_name", SqlDbType.VarChar,50),
					new SqlParameter("@date", SqlDbType.Char,10),
					new SqlParameter("@CODMn", SqlDbType.Decimal,17),
					new SqlParameter("@NH3_N", SqlDbType.Decimal,17),
					new SqlParameter("@TP", SqlDbType.Decimal,17),
					new SqlParameter("@TN", SqlDbType.Decimal,17),
					new SqlParameter("@flow", SqlDbType.Decimal,17)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.station_name;
			parameters[2].Value = model.date;
			parameters[3].Value = model.CODMn;
			parameters[4].Value = model.NH3_N;
			parameters[5].Value = model.TP;
			parameters[6].Value = model.TN;
			parameters[7].Value = model.flow;

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
		public bool Update(Maticsoft.Model.HIS_MEASURAND_DischargeAmount_Day model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HIS_MEASURAND_DischargeAmount_Day set ");
			strSql.Append("id=@id,");
			strSql.Append("station_name=@station_name,");
			strSql.Append("date=@date,");
			strSql.Append("CODMn=@CODMn,");
			strSql.Append("NH3_N=@NH3_N,");
			strSql.Append("TP=@TP,");
			strSql.Append("TN=@TN,");
			strSql.Append("flow=@flow");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@station_name", SqlDbType.VarChar,50),
					new SqlParameter("@date", SqlDbType.Char,10),
					new SqlParameter("@CODMn", SqlDbType.Decimal,17),
					new SqlParameter("@NH3_N", SqlDbType.Decimal,17),
					new SqlParameter("@TP", SqlDbType.Decimal,17),
					new SqlParameter("@TN", SqlDbType.Decimal,17),
					new SqlParameter("@flow", SqlDbType.Decimal,17)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.station_name;
			parameters[2].Value = model.date;
			parameters[3].Value = model.CODMn;
			parameters[4].Value = model.NH3_N;
			parameters[5].Value = model.TP;
			parameters[6].Value = model.TN;
			parameters[7].Value = model.flow;

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
			strSql.Append("delete from HIS_MEASURAND_DischargeAmount_Day ");
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
		public Maticsoft.Model.HIS_MEASURAND_DischargeAmount_Day GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,station_name,date,CODMn,NH3_N,TP,TN,flow from HIS_MEASURAND_DischargeAmount_Day ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.HIS_MEASURAND_DischargeAmount_Day model=new Maticsoft.Model.HIS_MEASURAND_DischargeAmount_Day();
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
		public Maticsoft.Model.HIS_MEASURAND_DischargeAmount_Day DataRowToModel(DataRow row)
		{
			Maticsoft.Model.HIS_MEASURAND_DischargeAmount_Day model=new Maticsoft.Model.HIS_MEASURAND_DischargeAmount_Day();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=long.Parse(row["id"].ToString());
				}
				if(row["station_name"]!=null)
				{
					model.station_name=row["station_name"].ToString();
				}
				if(row["date"]!=null)
				{
					model.date=row["date"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,station_name,date,CODMn,NH3_N,TP,TN,flow ");
			strSql.Append(" FROM HIS_MEASURAND_DischargeAmount_Day ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得不重复的数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct id,station_name ");
            strSql.Append(" FROM HIS_MEASURAND_DischargeAmount_Day ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			strSql.Append(" id,station_name,date,CODMn,NH3_N,TP,TN,flow ");
			strSql.Append(" FROM HIS_MEASURAND_DischargeAmount_Day ");
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
			strSql.Append("select count(1) FROM HIS_MEASURAND_DischargeAmount_Day ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from HIS_MEASURAND_DischargeAmount_Day T ");
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
			parameters[0].Value = "HIS_MEASURAND_DischargeAmount_Day";
			parameters[1].Value = "";
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

