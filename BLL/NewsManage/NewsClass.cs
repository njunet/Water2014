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

        #region  成员方法
        
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(String ClassDesc)
        {
            return dal.Exists(ClassDesc);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.NewsManage.NewsClass model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Maticsoft.Model.NewsManage.NewsClass model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
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
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.NewsManage.NewsClass GetModel(int ClassId)
        {
            return dal.GetModel(ClassId);                       
        }
        /// <summary>
        /// 得到一个对象实体,从缓存中
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
            
            #region 利用企业库的缓存方式

            ////创建一个缓存管理器
            //CacheManager caching = CacheFactory.GetCacheManager();
            ////取出缓存的数据
            //object objModel = caching.GetData(ClassId.ToString());
            //if (objModel == null)
            //{
            //    try
            //    {
            //        objModel = dal.GetModel(ClassId);
            //        if (objModel != null)
            //        {
            //            //添加要进行缓存的数据,
            //            //caching.Add(ClassId.ToString(), objModel);
            //            //添加要进行缓存的数据,缓存时间为10分钟                   
            //            caching.Add(ClassId.ToString(), objModel, CacheItemPriority.Normal, null, new SlidingTime(TimeSpan.FromMinutes(10)));
            //        }
            //        //清空缓存
            //        //caching.Flush();
            //        //caching.Count;
            //        //从缓存中移出key=1的项
            //        //caching.Remove(ClassId.ToString());
            //    }
            //    catch//(System.Exception ex)
            //    {
            //        //string str=ex.Message;// 记录错误日志
            //    }
            //}
            //return (Maticsoft.Model.NewsManage.NewsClass)objModel; 

            #endregion

        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 根据ClassId得到父类的ClassDesc
        /// </summary>
        public string GetClassDescByClassId(int ClassId)
        {
            return dal.GetClassDescByClassId(ClassId);
        }
        /// <summary>
        /// 根据ParentID得到ClassDesc
        /// </summary>
        public string GetClassDescByParentID(int parentID)
        {
            return dal.GetClassDescByParentID(parentID);
        }
        
        #endregion  成员方法

        #region
        public string GenNavigate(int ClassId)
        {
            Maticsoft.BLL.NewsManage.NewsClass bll = new Maticsoft.BLL.NewsManage.NewsClass();
            string strWhere = "";
            DataSet ds = new DataSet();
            ds = bll.GetList(strWhere);
            DataTable dt = ds.Tables[0];

            StringBuilder strNav = new StringBuilder();
            strNav.Append("当前位置：<a href='index_12_5.html'>首页</a>");
            ArrayList MyArray = new ArrayList();

            //取父级栏目
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
            //生成导航条
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
        #endregion  成员方法

    }
}
