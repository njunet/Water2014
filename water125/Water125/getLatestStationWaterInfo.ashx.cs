using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Water125
{
    /// <summary>
    /// getLatestStationWaterInfo 的摘要说明
    /// </summary>
    public class getLatestStationWaterInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string stationId = context.Request.Params["stationId"];
            //context.Response.Write("Hello World");
            Maticsoft.BLL.MEASURAND_STATION stationBll = new Maticsoft.BLL.MEASURAND_STATION();
            DataSet stationDs = stationBll.GetList(1, "id=" + stationId, "id desc");

            Maticsoft.BLL.HIS_MEASURAND_POINT pointBll = new Maticsoft.BLL.HIS_MEASURAND_POINT();
            DataSet pointDs = pointBll.GetList(1, "id=" + stationId, "systime desc");
            
            string msg = "";
            msg += stationDs.Tables[0].Rows[0][1] + "&";//提供站点名称

            int columnCount = pointDs.Tables[0].Columns.Count;
            //从第一列开始返回采样点数据，依次为采样时间，CODMn，NH3_N,TP,TN,flow
            for (int i = 1; i < columnCount; i++)
            {
                msg += pointDs.Tables[0].Rows[0][i];
                if (i < (columnCount - 1))
                {
                    msg += "&";
                }
            }
            context.Response.Write(msg);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}