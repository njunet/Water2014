using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LTP.Common;
using System.Collections;
namespace Maticsoft.BLL.NewsManage
{
    
    public class NewsClass
    {

        private readonly Maticsoft.DAL.NewsManage.NewsClass dal = new Maticsoft.DAL.NewsManage.NewsClass();

        #region  ��Ա����
        
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(String ClassDesc)
        {
            return dal.Exists(ClassDesc);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.NewsClass model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Maticsoft.Model.NewsManage.NewsClass model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ClassId)
        {
            dal.Delete(ClassId);
        }
        public void DeleteByClassId(int ClassId)
        {
            dal.DeleteByClassId(ClassId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsClass GetModel(int ClassId)
        {
            return dal.GetModel(ClassId);                       
        }
        /// <summary>
        /// �õ�һ������ʵ��,�ӻ�����
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsClass GetModelByCache(int ClassId)
        {
            string CacheKey = "NewsClassModel-" + ClassId;
            object objModel = DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ClassId);
                    if (objModel != null)
                    {
                        int AdContentCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(AdContentCache), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return (Maticsoft.Model.NewsManage.NewsClass)objModel;
            
            #region ������ҵ��Ļ��淽ʽ

            ////����һ�����������
            //CacheManager caching = CacheFactory.GetCacheManager();
            ////ȡ�����������
            //object objModel = caching.GetData(ClassId.ToString());
            //if (objModel == null)
            //{
            //    try
            //    {
            //        objModel = dal.GetModel(ClassId);
            //        if (objModel != null)
            //        {
            //            //���Ҫ���л��������,
            //            //caching.Add(ClassId.ToString(), objModel);
            //            //���Ҫ���л��������,����ʱ��Ϊ10����                   
            //            caching.Add(ClassId.ToString(), objModel, CacheItemPriority.Normal, null, new SlidingTime(TimeSpan.FromMinutes(10)));
            //        }
            //        //��ջ���
            //        //caching.Flush();
            //        //caching.Count;
            //        //�ӻ������Ƴ�key=1����
            //        //caching.Remove(ClassId.ToString());
            //    }
            //    catch//(System.Exception ex)
            //    {
            //        //string str=ex.Message;// ��¼������־
            //    }
            //}
            //return (Maticsoft.Model.NewsManage.NewsClass)objModel; 

            #endregion

        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ����ClassId�õ������ClassDesc
        /// </summary>
        public string GetClassDescByClassId(int ClassId)
        {
            return dal.GetClassDescByClassId(ClassId);
        }
        /// <summary>
        /// ����ParentID�õ�ClassDesc
        /// </summary>
        public string GetClassDescByParentID(int parentID)
        {
            return dal.GetClassDescByParentID(parentID);
        }
        
        #endregion  ��Ա����

        #region
        public string GenNavigate(int ClassId)
        {
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            string strWhere = "";
            DataSet ds = new DataSet();
            ds = bll.GetList(strWhere);
            DataTable dt = ds.Tables[0];

            StringBuilder strNav = new StringBuilder();
            strNav.Append("��ǰλ�ã�<a href='index_12_5.html'>��ҳ</a>");
            ArrayList MyArray = new ArrayList();

            //ȡ������Ŀ
            string strparentNave = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == ClassId.ToString())
                {

                    string strParentId = dt.Rows[i][0].ToString();
                    while (strParentId != "0")
                    {
                        strParentId = GenNavigateGetParent(dt, ref strparentNave, strParentId);
                        MyArray.Add(strparentNave);
                    }
                }
            };
            //���ɵ�����
            for (int i = MyArray.Count - 1; i >= 0; i--)
            {
                strNav.Append(MyArray[i].ToString());
            }

            return strNav.ToString();
        }

        public string GenNavigateGetParent(DataTable dt, ref string strNave, string ParentId)
        {
            string strarray = "";
            string strreturn = "0";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == ParentId)
                {
                    strarray += "&gt;<a href='Info_show.aspx?classid=" + dt.Rows[i][0].ToString() + "'>";
                    strarray += dt.Rows[i][1].ToString() + "</a>";
                    strNave = strarray;

                    strreturn = dt.Rows[i][3].ToString();
                    break;
                }
            }
            return strreturn;

        }
        #endregion  ��Ա����

    }
}
