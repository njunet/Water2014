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
            string section = context.Request.Params["section"];
            //context.Response.Write("Hello World");
            Maticsoft.BLL.MEASURAND_PREDICT_SECTION_2013 bll = new Maticsoft.BLL.MEASURAND_PREDICT_SECTION_2013();
            DataSet ds = bll.GetList(1,"II="+section,"TT desc");

            string msg = "";
            int rowCount = ds.Tables[0].Columns.Count;
            for (int i = 0; i < rowCount; i++)
            {
                msg += ds.Tables[0].Rows[0][i];
                if (i < (rowCount - 1))
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