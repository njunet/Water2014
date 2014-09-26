using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL.NewsManage
{
	/// <summary>
	/// 业务逻辑类NewsManage.NewsImages 的摘要说明。
	/// </summary>
	public class NewsImages
	{
		private readonly Maticsoft.DAL.NewsManage.NewsImages dal=new Maticsoft.DAL.NewsManage.NewsImages();
		public NewsImages()
		{}
		#region  成员方法
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
		public int  Add(Maticsoft.Model.NewsManage.NewsImages model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public void Update(string updatestr, int newsid)
		{
            dal.Update(updatestr,newsid);
		}

        public void Update(Maticsoft.Model.NewsManage.NewsImages model)
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





        /// <summary>
        /// 得到新闻图片
        /// </summary>
        /// <param name="top">返回行数</param>
        /// <param name="ClassId">类别</param>
        /// <param name="Dormancy">发布状态</param>       
        /// <returns></returns>
        public DataSet GetNewsImagesList(int top, int newsId, bool Dormancy)
        {
            string strwhere = "newsid=" + newsId.ToString();
            return dal.GetList(strwhere);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.NewsManage.NewsImages GetModel(int Id)
		{			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Maticsoft.Model.NewsManage.NewsImages GetModelByCache(int Id)
		{
			
			string CacheKey = "NewsManage.NewsImagesModel-" + Id;
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
			return (Maticsoft.Model.NewsManage.NewsImages)objModel;
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
		public List<Maticsoft.Model.NewsManage.NewsImages> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.NewsManage.NewsImages> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.NewsManage.NewsImages> modelList = new List<Maticsoft.Model.NewsManage.NewsImages>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.NewsManage.NewsImages model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.NewsManage.NewsImages();
					if(dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					if(dt.Rows[n]["NewsId"].ToString()!="")
					{
						model.NewsId=int.Parse(dt.Rows[n]["NewsId"].ToString());
					}
					model.Descrip=dt.Rows[n]["Descrip"].ToString();
					model.LinkUrl=dt.Rows[n]["LinkUrl"].ToString();
					if(dt.Rows[n]["IssueDate"].ToString()!="")
					{
						model.IssueDate=DateTime.Parse(dt.Rows[n]["IssueDate"].ToString());
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
        /// 根据NewsId删除数据
        /// </summary>
        public void DeletebyNewsId(int NewsId)
        {

            dal.DeletebyNewsId(NewsId);
        }

		#endregion  成员方法
	}
}

