/**  版本信息模板在安装目录下，可自行修改。
* Accounts_Users.cs
*
* 功 能： N/A
* 类 名： Accounts_Users
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/3 11:05:07   N/A    初版
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
	/// 数据访问类:Accounts_Users
	/// </summary>
	public partial class Accounts_Users
	{
		public Accounts_Users()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Accounts_Users");
			strSql.Append(" where UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)			};
			parameters[0].Value = UserName;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.Accounts_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Accounts_Users(");
			strSql.Append("UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Password,@TrueName,@Sex,@Phone,@Email,@EmployeeID,@DepartmentID,@Activity,@UserType,@Style)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.Binary,20),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Char,2),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,15),
					new SqlParameter("@Activity", SqlDbType.Bit,1),
					new SqlParameter("@UserType", SqlDbType.Char,2),
					new SqlParameter("@Style", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.TrueName;
			parameters[3].Value = model.Sex;
			parameters[4].Value = model.Phone;
			parameters[5].Value = model.Email;
			parameters[6].Value = model.EmployeeID;
			parameters[7].Value = model.DepartmentID;
			parameters[8].Value = model.Activity;
			parameters[9].Value = model.UserType;
			parameters[10].Value = model.Style;

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
		public bool Update(Maticsoft.Model.Accounts_Users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Accounts_Users set ");
			strSql.Append("Password=@Password,");
			strSql.Append("TrueName=@TrueName,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Email=@Email,");
			strSql.Append("EmployeeID=@EmployeeID,");
			strSql.Append("DepartmentID=@DepartmentID,");
			strSql.Append("Activity=@Activity,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("Style=@Style");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@Password", SqlDbType.Binary,20),
					new SqlParameter("@TrueName", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Char,2),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@DepartmentID", SqlDbType.VarChar,15),
					new SqlParameter("@Activity", SqlDbType.Bit,1),
					new SqlParameter("@UserType", SqlDbType.Char,2),
					new SqlParameter("@Style", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Password;
			parameters[1].Value = model.TrueName;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.Phone;
			parameters[4].Value = model.Email;
			parameters[5].Value = model.EmployeeID;
			parameters[6].Value = model.DepartmentID;
			parameters[7].Value = model.Activity;
			parameters[8].Value = model.UserType;
			parameters[9].Value = model.Style;
			parameters[10].Value = model.UserID;
			parameters[11].Value = model.UserName;

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
		public bool Delete(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Accounts_Users ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

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
		public bool Delete(string UserName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Accounts_Users ");
			strSql.Append(" where UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)			};
			parameters[0].Value = UserName;

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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Accounts_Users ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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
		public Maticsoft.Model.Accounts_Users GetModel(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserID,UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style from Accounts_Users ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
			parameters[0].Value = UserID;

			Maticsoft.Model.Accounts_Users model=new Maticsoft.Model.Accounts_Users();
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
		public Maticsoft.Model.Accounts_Users DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Accounts_Users model=new Maticsoft.Model.Accounts_Users();
			if (row != null)
			{
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Password"]!=null && row["Password"].ToString()!="")
				{
					model.Password=(byte[])row["Password"];
				}
				if(row["TrueName"]!=null)
				{
					model.TrueName=row["TrueName"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["DepartmentID"]!=null)
				{
					model.DepartmentID=row["DepartmentID"].ToString();
				}
				if(row["Activity"]!=null && row["Activity"].ToString()!="")
				{
					if((row["Activity"].ToString()=="1")||(row["Activity"].ToString().ToLower()=="true"))
					{
						model.Activity=true;
					}
					else
					{
						model.Activity=false;
					}
				}
				if(row["UserType"]!=null)
				{
					model.UserType=row["UserType"].ToString();
				}
				if(row["Style"]!=null && row["Style"].ToString()!="")
				{
					model.Style=int.Parse(row["Style"].ToString());
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
			strSql.Append("select UserID,UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style ");
			strSql.Append(" FROM Accounts_Users ");
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
			strSql.Append(" UserID,UserName,Password,TrueName,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style ");
			strSql.Append(" FROM Accounts_Users ");
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
			strSql.Append("select count(1) FROM Accounts_Users ");
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from Accounts_Users T ");
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
			parameters[0].Value = "Accounts_Users";
			parameters[1].Value = "UserID";
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

