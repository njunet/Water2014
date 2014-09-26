using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用

namespace LTP.Common
{
   public class DBRecover
   {
       public DBRecover()
       {

       }


       #region  成员方法
       /// <summary>
       /// 判断是否执行了数据库的备份
       /// </summary>
       public int DbRecover(string FileName)
       {
           string strwhere = FileName;
           StringBuilder strSql = new StringBuilder();
           strSql.Append("BACKUP DATABASE [Gonghui] TO  DISK = N'");

           if (FileName.Trim() != "")
           {
               strSql.Append("" + FileName + "");
           }
           strSql.Append("' WITH NOFORMAT, NOINIT,  NAME = N'Maticsoft-完整 数据库 备份', SKIP, NOREWIND, NOUNLOAD,  STATS = 10");


           return DbHelperSQL.ExecuteSql(strSql.ToString());
       }





       ///// <summary>
       ///// 获得数据列表
       ///// </summary>
       //public DataSet GetList(string strWhere)
       //{
       //    StringBuilder strSql = new StringBuilder();
       //    strSql.Append("BACKUP DATABASE [WYXY] TO  DISK = N'");

       //    if (strWhere.Trim() != "")
       //    {
       //        strSql.Append(+strWhere + " ");
       //    }


       //    return DbHelperSQL.Query(strSql.ToString());
       //}



       #endregion  成员方法


   }
}
