using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ҵ���߼���W_Material ��ժҪ˵����
	/// </summary>
	public class W_Material
	{
		private readonly Maticsoft.DAL.W_Material dal=new Maticsoft.DAL.W_Material();
		public W_Material()
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
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Maticsoft.Model.W_Material model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Maticsoft.Model.W_Material model)
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

        ///// <summary>
        ///// ����һ����¼�Ƿ������ʾ����
        ///// </summary>
        //public void OutDisplay(int Id)
        //{

        //    dal.OutDisplay(Id);
        //}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.W_Material GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		public List<Maticsoft.Model.W_Material> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// ���ݹؼ��ֲ�ѯ������Ϣ
        /// </summary>
        public DataSet GetMaterialByType( string key)
        {
            return dal.GetMaterialByType(key);
        }


        /// <summary>
        /// ���ݲ���id�б��Ƿ������ʾ
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

       

		#endregion  ��Ա����
	}
}

