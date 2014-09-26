using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ҵ���߼���W_Receivestate ��ժҪ˵����
	/// </summary>
	public class W_Receivestate
	{
		private readonly Maticsoft.DAL.W_Receivestate dal=new Maticsoft.DAL.W_Receivestate();
		public W_Receivestate()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int MaterialId,string ReceiverId,int Id)
		{
			return dal.Exists(MaterialId,ReceiverId,Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Maticsoft.Model.W_Receivestate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Maticsoft.Model.W_Receivestate model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
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
		/// �õ�һ������ʵ��
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
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		public List<Maticsoft.Model.W_Receivestate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
        /// ���ݹؼ��ֲ�ѯ������Ϣ
        /// </summary>
        public DataSet GetMaterialByType(string key)
        {
            return dal.GetMaterialByType(key);
        }


        /// <summary>
        /// ��ò���
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



		#endregion  ��Ա����
	}
}

