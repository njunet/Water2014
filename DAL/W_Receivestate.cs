using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类W_Receivestate。
	/// </summary>
	public class W_Receivestate
	{
		public W_Receivestate()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MaterialId", "W_Receivestate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MaterialId,string ReceiverId,int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from W_Receivestate");
			strSql.Append(" where MaterialId=@MaterialId and ReceiverId=@ReceiverId and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialId", SqlDbType.Int,4),
					new SqlParameter("@ReceiverId", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = MaterialId;
			parameters[1].Value = ReceiverId;
			parameters[2].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.W_Receivestate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into W_Receivestate(");
			strSql.Append("MaterialId,ReceiverId,Dormacy,IssureTime)");
			strSql.Append(" values (");
			strSql.Append("@MaterialId,@ReceiverId,@Dormacy,@IssureTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialId", SqlDbType.Int,4),
					new SqlParameter("@ReceiverId", SqlDbType.NVarChar,50),
					new SqlParameter("@Dormacy", SqlDbType.NVarChar,50),
					new SqlParameter("@IssureTime", SqlDbType.DateTime)};
			parameters[0].Value = model.MaterialId;
			parameters[1].Value = model.ReceiverId;
			parameters[2].Value = model.Dormacy;
			parameters[3].Value = model.IssureTime;

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
		public void Update(Maticsoft.Model.W_Receivestate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update W_Receivestate set ");
			strSql.Append("Dormacy=@Dormacy,");
			strSql.Append("IssureTime=@IssureTime");
			strSql.Append(" where MaterialId=@MaterialId and ReceiverId=@ReceiverId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@MaterialId", SqlDbType.Int,4),
					new SqlParameter("@ReceiverId", SqlDbType.NVarChar,50),
					new SqlParameter("@Dormacy", SqlDbType.NVarChar,50),
					new SqlParameter("@IssureTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.MaterialId;
			parameters[2].Value = model.ReceiverId;
			parameters[3].Value = model.Dormacy;
			parameters[4].Value = model.IssureTime;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int MaterialId,string ReceiverId,int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from W_Receivestate ");
			strSql.Append(" where MaterialId=@MaterialId and ReceiverId=@ReceiverId and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialId", SqlDbType.Int,4),
					new SqlParameter("@ReceiverId", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = MaterialId;
			parameters[1].Value = ReceiverId;
			parameters[2].Value = Id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

        public void Delete(int MaterialId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from W_Receivestate ");
            strSql.Append(" where MaterialId=@MaterialId");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialId", SqlDbType.Int,4),
					};
            parameters[0].Value = MaterialId;
           

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.W_Receivestate GetModel(int MaterialId,string ReceiverId,int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,MaterialId,ReceiverId,Dormacy,IssureTime from W_Receivestate ");
			strSql.Append(" where MaterialId=@MaterialId and ReceiverId=@ReceiverId and Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialId", SqlDbType.Int,4),
					new SqlParameter("@ReceiverId", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = MaterialId;
			parameters[1].Value = ReceiverId;
			parameters[2].Value = Id;

			Maticsoft.Model.W_Receivestate model=new Maticsoft.Model.W_Receivestate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MaterialId"].ToString()!="")
				{
					model.MaterialId=int.Parse(ds.Tables[0].Rows[0]["MaterialId"].ToString());
				}
				model.ReceiverId=ds.Tables[0].Rows[0]["ReceiverId"].ToString();
				model.Dormacy=ds.Tables[0].Rows[0]["Dormacy"].ToString();
				if(ds.Tables[0].Rows[0]["IssureTime"].ToString()!="")
				{
					model.IssureTime=DateTime.Parse(ds.Tables[0].Rows[0]["IssureTime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}
        public Maticsoft.Model.W_Receivestate GetModel(int MaterialId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,MaterialId,ReceiverId,Dormacy,IssureTime from W_Receivestate ");
            strSql.Append(" where MaterialId=@MaterialId  ");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialId", SqlDbType.Int,4),
					};
            parameters[0].Value = MaterialId;
            

            Maticsoft.Model.W_Receivestate model = new Maticsoft.Model.W_Receivestate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaterialId"].ToString() != "")
                {
                    model.MaterialId = int.Parse(ds.Tables[0].Rows[0]["MaterialId"].ToString());
                }
                model.ReceiverId = ds.Tables[0].Rows[0]["ReceiverId"].ToString();
                model.Dormacy = ds.Tables[0].Rows[0]["Dormacy"].ToString();
                if (ds.Tables[0].Rows[0]["IssureTime"].ToString() != "")
                {
                    model.IssureTime = DateTime.Parse(ds.Tables[0].Rows[0]["IssureTime"].ToString());
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
			strSql.Append("select Id,MaterialId,ReceiverId,Dormacy,IssureTime ");
			strSql.Append(" FROM W_Receivestate ");
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
			strSql.Append(" Id,MaterialId,ReceiverId,Dormacy,IssureTime ");
			strSql.Append(" FROM W_Receivestate ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public DataSet GetAllList()
        {


            return GetList("");
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
			parameters[0].Value = "W_Receivestate";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 根据关键字查询材料信息
        /// </summary>
        public DataSet GetMaterialByType(string key)
        {
            SqlParameter[]
                parameters = {
								 new SqlParameter("@key", SqlDbType.NVarChar , 100)
							 };

            parameters[0].Value = key;
            return DbHelperSQL.RunProcedure("W_SearchAllList_state", parameters, "W_Receivestate");
        }

        /// <summary>
        /// 获得材料
        /// </summary>
        public DataSet GetMaterial()
        {

            return DbHelperSQL.RunProcedure("W_Material_Id", "W_Receivestate");
        }
        public DataSet GetMaterial(string ReceiverId)
        {
            SqlParameter[]
                parameters = {
								 new SqlParameter("@key", SqlDbType.NVarChar , 100)
							 };

            parameters[0].Value = ReceiverId;
            return DbHelperSQL.RunProcedure("W_Material_list", parameters, "W_Receivestate");
        }

        public DataSet GetMaterial_MaterialName(string MaterialName)
        {
            SqlParameter[]
                parameters = {
								 new SqlParameter("@Name", SqlDbType.NVarChar , 100)
							 };

            parameters[0].Value = MaterialName;
            return DbHelperSQL.RunProcedure("W_GetMaterial_MaterialName", parameters, "W_Receivestate");
        }


        public DataSet W_Material_ShowIndex(int id)
        {
            SqlParameter[]
                parameters = {
								 new SqlParameter("@id",SqlDbType.Int,4)
							 };

            parameters[0].Value = id;
            return DbHelperSQL.RunProcedure("W_Material_ShowIndex", parameters, "W_Receivestate");
        }
		#endregion  成员方法
	}
}

