using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类W_Material 的摘要说明。
	/// </summary>
	public class W_Material
	{
		private readonly Maticsoft.DAL.W_Material dal=new Maticsoft.DAL.W_Material();
		public W_Material()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Maticsoft.Model.W_Material model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.W_Material model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Id)
		{
			
			dal.Delete(Id);
		}

        ///// <summary>
        ///// 更新一条记录是否过期显示问题
        ///// </summary>
        //public void OutDisplay(int Id)
        //{

        //    dal.OutDisplay(Id);
        //}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.W_Material GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Maticsoft.Model.W_Material GetModelByCache(int Id)
		{
			
			string CacheKey = "W_MaterialModel-" + Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.W_Material)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.W_Material> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.W_Material> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.W_Material> modelList = new List<Maticsoft.Model.W_Material>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.W_Material model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.W_Material();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					model.Name=dt.Rows[n]["Name"].ToString();
					if(dt.Rows[n]["Begindate"].ToString()!="")
					{
						model.Begindate=DateTime.Parse(dt.Rows[n]["Begindate"].ToString());
					}
					if(dt.Rows[n]["Enddate"].ToString()!="")
					{
						model.Enddate=DateTime.Parse(dt.Rows[n]["Enddate"].ToString());
					}
                    model.Number = dt.Rows[n]["Number"].ToString();
                    model.Address = dt.Rows[n]["Address"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// 根据关键字查询材料信息
        /// </summary>
        public DataSet GetMaterialByType( string key)
        {
            return dal.GetMaterialByType(key);
        }


        /// <summary>
        /// 根据材料id列表，是否过期显示
        /// </summary>
        /// <param name="Idlist"></param>
        public void ReleaseList(int id)
        {
            dal.ReleaseList(id );
        }
        public void NoReleaseList(int id)
        {
            dal.NoReleaseList(id);
        }

       

		#endregion  成员方法
	}
}

