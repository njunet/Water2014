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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:MEASURAND_STATION
	/// </summary>
	public partial class MEASURAND_STATION
	{
		public MEASURAND_STATION()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.MEASURAND_STATION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MEASURAND_STATION(");
			strSql.Append("id,station_name,state,posx,posy,dynamic,procince_city,river_id,comments,address,river_name)");
			strSql.Append(" values (");
			strSql.Append("@id,@station_name,@state,@posx,@posy,@dynamic,@procince_city,@river_id,@comments,@address,@river_name)");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@station_name", SqlDbType.VarChar,50),
					new SqlParameter("@state", SqlDbType.TinyInt,1),
					new SqlParameter("@posx", SqlDbType.Decimal,9),
					new SqlParameter("@posy", SqlDbType.Decimal,9),
					new SqlParameter("@dynamic", SqlDbType.TinyInt,1),
					new SqlParameter("@procince_city", SqlDbType.VarChar,50),
					new SqlParameter("@river_id", SqlDbType.BigInt,8),
					new SqlParameter("@comments", SqlDbType.VarChar,255),
					new SqlParameter("@address", SqlDbType.VarChar,50),
					new SqlParameter("@river_name", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.station_name;
			parameters[2].Value = model.state;
			parameters[3].Value = model.posx;
			parameters[4].Value = model.posy;
			parameters[5].Value = model.dynamic;
			parameters[6].Value = model.procince_city;
			parameters[7].Value = model.river_id;
			parameters[8].Value = model.comments;
			parameters[9].Value = model.address;
			parameters[10].Value = model.river_name;

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
		public bool Update(Maticsoft.Model.MEASURAND_STATION model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MEASURAND_STATION set ");
			strSql.Append("id=@id,");
			strSql.Append("station_name=@station_name,");
			strSql.Append("state=@state,");
			strSql.Append("posx=@posx,");
			strSql.Append("posy=@posy,");
			strSql.Append("dynamic=@dynamic,");
			strSql.Append("procince_city=@procince_city,");
			strSql.Append("river_id=@river_id,");
			strSql.Append("comments=@comments,");
			strSql.Append("address=@address,");
			strSql.Append("river_name=@river_name");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@station_name", SqlDbType.VarChar,50),
					new SqlParameter("@state", SqlDbType.TinyInt,1),
					new SqlParameter("@posx", SqlDbType.Decimal,9),
					new SqlParameter("@posy", SqlDbType.Decimal,9),
					new SqlParameter("@dynamic", SqlDbType.TinyInt,1),
					new SqlParameter("@procince_city", SqlDbType.VarChar,50),
					new SqlParameter("@river_id", SqlDbType.BigInt,8),
					new SqlParameter("@comments", SqlDbType.VarChar,255),
					new SqlParameter("@address", SqlDbType.VarChar,50),
					new SqlParameter("@river_name", SqlDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.station_name;
			parameters[2].Value = model.state;
			parameters[3].Value = model.posx;
			parameters[4].Value = model.posy;
			parameters[5].Value = model.dynamic;
			parameters[6].Value = model.procince_city;
			parameters[7].Value = model.river_id;
			parameters[8].Value = model.comments;
			parameters[9].Value = model.address;
			parameters[10].Value = model.river_name;

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
			strSql.Append("delete from MEASURAND_STATION ");
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
		public Maticsoft.Model.MEASURAND_STATION GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,station_name,state,posx,posy,dynamic,procince_city,river_id,comments,address,river_name from MEASURAND_STATION ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.MEASURAND_STATION model=new Maticsoft.Model.MEASURAND_STATION();
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
		public Maticsoft.Model.MEASURAND_STATION DataRowToModel(DataRow row)
		{
			Maticsoft.Model.MEASURAND_STATION model=new Maticsoft.Model.MEASURAND_STATION();
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
				if(row["state"]!=null && row["state"].ToString()!="")
				{
					model.state=int.Parse(row["state"].ToString());
				}
				if(row["posx"]!=null && row["posx"].ToString()!="")
				{
					model.posx=decimal.Parse(row["posx"].ToString());
				}
				if(row["posy"]!=null && row["posy"].ToString()!="")
				{
					model.posy=decimal.Parse(row["posy"].ToString());
				}
				if(row["dynamic"]!=null && row["dynamic"].ToString()!="")
				{
					model.dynamic=int.Parse(row["dynamic"].ToString());
				}
				if(row["procince_city"]!=null)
				{
					model.procince_city=row["procince_city"].ToString();
				}
				if(row["river_id"]!=null && row["river_id"].ToString()!="")
				{
					model.river_id=long.Parse(row["river_id"].ToString());
				}
				if(row["comments"]!=null)
				{
					model.comments=row["comments"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["river_name"]!=null)
				{
					model.river_name=row["river_name"].ToString();
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
			strSql.Append("select id,station_name,state,posx,posy,dynamic,procince_city,river_id,comments,address,river_name ");
			strSql.Append(" FROM MEASURAND_STATION ");
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
			strSql.Append(" id,station_name,state,posx,posy,dynamic,procince_city,river_id,comments,address,river_name ");
			strSql.Append(" FROM MEASURAND_STATION ");
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
			strSql.Append("select count(1) FROM MEASURAND_STATION ");
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
			strSql.Append(")AS Row, T.*  from MEASURAND_STATION T ");
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
			parameters[0].Value = "MEASURAND_STATION";
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

