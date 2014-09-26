using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//�����������
namespace Maticsoft.DAL
{
	/// <summary>
	/// ���ݷ�����W_Material��
	/// </summary>
	public class W_Material
	{
		public W_Material()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "W_Material"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from W_Material");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Maticsoft.Model.W_Material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into W_Material(");
            strSql.Append("Name,Begindate,Enddate,Number,Address)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Begindate,@Enddate,@Number,@Address)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Begindate", SqlDbType.DateTime),
					new SqlParameter("@Enddate", SqlDbType.DateTime),
					new SqlParameter("@Number", SqlDbType.VarChar,150),
					new SqlParameter("@Address", SqlDbType.VarChar,150)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Begindate;
            parameters[2].Value = model.Enddate;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.Address;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// ����һ������
        /// </summary>
        public void Update(Maticsoft.Model.W_Material model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update W_Material set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Begindate=@Begindate,");
            strSql.Append("Enddate=@Enddate,");
            strSql.Append("Number=@Number,");
            strSql.Append("Address=@Address");
           
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Begindate", SqlDbType.DateTime),
					new SqlParameter("@Enddate", SqlDbType.DateTime),
					new SqlParameter("@Number", SqlDbType.VarChar,150),
					new SqlParameter("@Address", SqlDbType.VarChar,150),
                   };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Begindate;
            parameters[3].Value = model.Enddate;
            parameters[4].Value = model.Number;
            parameters[5].Value = model.Address;
           

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from W_Material ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
            };
			parameters[0].Value = Id;
			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


        ///// <summary>
        ///// ����һ����¼�Ƿ������ʾ����
        ///// </summary>
        //public void Delete(int Id)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update W_Material set ");
        //    strSql.Append("OutDisplay=@OutDisplay");
        //    strSql.Append(" where Id=@Id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@Id", SqlDbType.Int,4),
        //      new SqlParameter("@OutDisplay", SqlDbType.Char,10)};
        //    parameters[0].Value = Id;

        //    DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //}


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Maticsoft.Model.W_Material GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,Begindate,Enddate,Number,Address,Outdisplay from W_Material ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Maticsoft.Model.W_Material model = new Maticsoft.Model.W_Material();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["Begindate"].ToString() != "")
                {
                    model.Begindate = DateTime.Parse(ds.Tables[0].Rows[0]["Begindate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Enddate"].ToString() != "")
                {
                    model.Enddate = DateTime.Parse(ds.Tables[0].Rows[0]["Enddate"].ToString());
                }
                model.Number = ds.Tables[0].Rows[0]["Number"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                if (ds.Tables[0].Rows[0]["Outdisplay"].ToString() != "")
                {
                    model.Outdisplay = ds.Tables[0].Rows[0]["Outdisplay"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,Begindate,Enddate,Number,Address,Outdisplay");
            strSql.Append(" FROM W_Material ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" Id,Name,Begindate,Enddate,Number,Address,Outdisplay ");
			strSql.Append(" FROM W_Material ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "W_Material";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// ���ݹؼ��ֲ�ѯ������Ϣ
        /// </summary>
        public DataSet GetMaterialByType(string key)
        {
            SqlParameter[]
                parameters = {
								 new SqlParameter("@key", SqlDbType.NVarChar , 100)
							 };

            parameters[0].Value = key;
            return DbHelperSQL.RunProcedure("W_Material_GetMaterial", parameters, "W_Material");
        }


        /// <summary>
        /// ������ʾ
        /// </summary>
        /// <param name="strWhere"></param>
        public void ReleaseList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update W_Material set Outdisplay='��'");
           
          
                strSql.Append(" where  Id ="+id );
         
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// ���ڲ���ʾ
        /// </summary>
        /// <param name="strWhere"></param>
        public void NoReleaseList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update W_Material set Outdisplay='��'");
          
                strSql.Append(" where  Id =" + id);
            
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }


		#endregion  ��Ա����
	}
}

