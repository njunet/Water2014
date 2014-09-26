using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// 业务逻辑类W_Receivestate 的摘要说明。
	/// </summary>
	public class W_Receivestate
	{
		private readonly Maticsoft.DAL.W_Receivestate dal=new Maticsoft.DAL.W_Receivestate();
		public W_Receivestate()
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
		public bool Exists(int MaterialId,string ReceiverId,int Id)
		{
			return dal.Exists(MaterialId,ReceiverId,Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Maticsoft.Model.W_Receivestate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Maticsoft.Model.W_Receivestate model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int MaterialId,string ReceiverId,int Id)
		{
			
			dal.Delete(MaterialId,ReceiverId,Id);
		}
        public void Delete(int MaterialId)
        {

            dal.Delete(MaterialId);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.W_Receivestate GetModel(int MaterialId,string ReceiverId,int Id)
		{
			
			return dal.GetModel(MaterialId,ReceiverId,Id);
		}
        public Maticsoft.Model.W_Receivestate GetModel(int MaterialId)
        {

            return dal.GetModel(MaterialId);
        }


		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Maticsoft.Model.W_Receivestate GetModelByCache(int MaterialId,string ReceiverId,int Id)
		{
			
			string CacheKey = "W_ReceivestateModel-" + MaterialId+ReceiverId+Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MaterialId,ReceiverId,Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.W_Receivestate)objModel;
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
		public List<Maticsoft.Model.W_Receivestate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.W_Receivestate> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.W_Receivestate> modelList = new List<Maticsoft.Model.W_Receivestate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.W_Receivestate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.W_Receivestate();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					if(dt.Rows[n]["MaterialId"].ToString()!="")
					{
						model.MaterialId=int.Parse(dt.Rows[n]["MaterialId"].ToString());
					}
					model.ReceiverId=dt.Rows[n]["ReceiverId"].ToString();
					model.Dormacy=dt.Rows[n]["Dormacy"].ToString();
					if(dt.Rows[n]["IssureTime"].ToString()!="")
					{
						model.IssureTime=DateTime.Parse(dt.Rows[n]["IssureTime"].ToString());
					}
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
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// 根据关键字查询材料信息
        /// </summary>
        public DataSet GetMaterialByType(string key)
        {
            return dal.GetMaterialByType(key);
        }


        /// <summary>
        /// 获得材料
        /// </summary>
        public DataSet GetMaterial()
        {

            return dal.GetMaterial();
        }

        public DataSet GetMaterial(string ReceiverId)
        {

            return dal.GetMaterial(ReceiverId);
        }

        public DataSet GetMaterial_MaterialName(string MaterialName)
        {

            return dal.GetMaterial_MaterialName(MaterialName);
        }

        public DataSet W_Material_ShowIndex(int id)
        {

            return dal.W_Material_ShowIndex(id);
        }



		#endregion  成员方法
	}
}

