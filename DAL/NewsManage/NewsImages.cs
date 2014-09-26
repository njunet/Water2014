using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Maticsoft.DAL.NewsManage
{
	/// <summary>
	/// 数据访问类NewsImages。
	/// </summary>
	public class NewsImages
	{
		public NewsImages()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from NewsImages");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.NewsManage.NewsImages model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_NewsImages(");
			strSql.Append("NewsId,Descrip,LinkUrl,IssueDate)");
			strSql.Append(" values (");
			strSql.Append("@NewsId,@Descrip,@LinkUrl,@IssueDate)");
		//	strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4),
					new SqlParameter("@Descrip", SqlDbType.Text),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,100),
					new SqlParameter("@IssueDate", SqlDbType.DateTime)};
			parameters[0].Value = model.NewsId;
			parameters[1].Value = model.Descrip;
			parameters[2].Value = model.LinkUrl;
			parameters[3].Value = model.IssueDate;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.NewsManage.NewsImages model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_NewsImages set ");
			strSql.Append("NewsId=@NewsId,");
			strSql.Append("Descrip=@Descrip,");
			strSql.Append("LinkUrl=@LinkUrl,");
			strSql.Append("IssueDate=@IssueDate");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@NewsId", SqlDbType.Int,4),
					new SqlParameter("@Descrip", SqlDbType.Text),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,100),
					new SqlParameter("@IssueDate", SqlDbType.DateTime)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.NewsId;
			parameters[2].Value = model.Descrip;
			parameters[3].Value = model.LinkUrl;
			parameters[4].Value = model.IssueDate;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
        

        public void Update(string updatestr,int newsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_NewsImages set ");
            strSql.Append(updatestr);
            strSql.Append(" where newsid=@NewsId ");
            SqlParameter[] parameters = {				
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
            parameters[0].Value = newsid;       
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_NewsImages ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.NewsManage.NewsImages GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,NewsId,Descrip,LinkUrl,IssueDate from T_NewsImages ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			Maticsoft.Model.NewsManage.NewsImages model=new Maticsoft.Model.NewsManage.NewsImages();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewsId"].ToString()!="")
				{
					model.NewsId=int.Parse(ds.Tables[0].Rows[0]["NewsId"].ToString());
				}
				model.Descrip=ds.Tables[0].Rows[0]["Descrip"].ToString();
				model.LinkUrl=ds.Tables[0].Rows[0]["LinkUrl"].ToString();
				if(ds.Tables[0].Rows[0]["IssueDate"].ToString()!="")
				{
					model.IssueDate=DateTime.Parse(ds.Tables[0].Rows[0]["IssueDate"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,NewsId,Descrip,LinkUrl,IssueDate ");
			strSql.Append(" FROM T_NewsImages ");
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
			strSql.Append(" Id,NewsId,Descrip,LinkUrl,IssueDate ");
			strSql.Append(" FROM T_NewsImages ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "NewsImages";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 根据NewsId删除数据
        /// </summary>
        public void DeletebyNewsId(int NewsId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_NewsImages ");
            strSql.Append(" where NewsId=@NewsId ");
            SqlParameter[] parameters = {
					new SqlParameter("@NewsId", SqlDbType.Int,4)};
            parameters[0].Value = NewsId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

		#endregion  成员方法
	}
}

