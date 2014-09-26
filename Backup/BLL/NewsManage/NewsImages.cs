using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL.NewsManage
{
	/// <summary>
	/// ҵ���߼���NewsManage.NewsImages ��ժҪ˵����
	/// </summary>
	public class NewsImages
	{
		private readonly Maticsoft.DAL.NewsManage.NewsImages dal=new Maticsoft.DAL.NewsManage.NewsImages();
		public NewsImages()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Maticsoft.Model.NewsManage.NewsImages model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
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
		/// ɾ��һ������
		/// </summary>
		public void Delete(int Id)
		{
			
			dal.Delete(Id);
		}





        /// <summary>
        /// �õ�����ͼƬ
        /// </summary>
        /// <param name="top">��������</param>
        /// <param name="ClassId">���</param>
        /// <param name="Dormancy">����״̬</param>       
        /// <returns></returns>
        public DataSet GetNewsImagesList(int top, int newsId, bool Dormancy)
        {
            string strwhere = "newsid=" + newsId.ToString();
            return dal.GetList(strwhere);
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.NewsManage.NewsImages GetModel(int Id)
		{			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.NewsManage.NewsImages> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

        /// <summary>
        /// ����NewsIdɾ������
        /// </summary>
        public void DeletebyNewsId(int NewsId)
        {

            dal.DeletebyNewsId(NewsId);
        }

		#endregion  ��Ա����
	}
}

