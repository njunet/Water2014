using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Water125
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string DischargeAmount_Day(String station_name, int year, int month)
        {
            string timestr = "'" + year + "/" + month + "/1'";
            string wherestr = "station_name ='" + station_name + "' and datediff(month,date," + timestr + ")=0";
            Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Day Bll = new Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Day();
            DataSet dataset = Bll.GetList(1000, wherestr, "date");
            DataTable dtl = dataset.Tables[0];
            int rowcount = dtl.Rows.Count;
            if (rowcount == 0)
            {
                return "null";
            }
            DataRow col = dtl.Rows[0];
            String DischargeAmountstr = col["station_name"].ToString();
            DischargeAmountstr += "#CODMn";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["date"].ToString() + "," + col["CODMn"].ToString();
            }
            DischargeAmountstr += "#NH3_N";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["date"].ToString() + "," + col["NH3_N"].ToString();
            }
            DischargeAmountstr += "#TP";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["date"].ToString() + "," + col["TP"].ToString();
            }
            DischargeAmountstr += "#TN";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["date"].ToString() + "," + col["TN"].ToString();
            }
            return DischargeAmountstr;
        }


        [WebMethod]
        public string DischargeAmount_Month(String station_name, int year)
        {
            string yearstr = "'%" + year + "%'";
            string wherestr = "station_name ='" + station_name + "' and YYYY_MM like " + yearstr;
            Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Month Bll = new Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Month();
            DataSet dataset = Bll.GetList(1000, wherestr, "YYYY_MM");
            DataTable dtl = dataset.Tables[0];
            int rowcount = dtl.Rows.Count;
            if (rowcount == 0)
            {
                return "null";
            }
            DataRow col = dtl.Rows[0];
            String DischargeAmountstr = col["station_name"].ToString();
            DischargeAmountstr += "#CODMn";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["YYYY_MM"].ToString() + "," + col["CODMn"].ToString();
            }
            DischargeAmountstr += "#NH3_N";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["YYYY_MM"].ToString() + "," + col["NH3_N"].ToString();
            }
            DischargeAmountstr += "#TP";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["YYYY_MM"].ToString() + "," + col["TP"].ToString();
            }
            DischargeAmountstr += "#TN";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["YYYY_MM"].ToString() + "," + col["TN"].ToString();
            }
            return DischargeAmountstr;
        }

        [WebMethod]
        public string AverageFlow_Month(String station_name, int year)
        {
            string yearstr = "'%" + year + "%'";
            string wherestr = "station_name ='" + station_name + "' and YYYY_MM like " + yearstr;
            Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Month Bll = new Maticsoft.BLL.HIS_MEASURAND_DischargeAmount_Month();
            DataSet dataset = Bll.GetList(1000, wherestr, "YYYY_MM");
            DataTable dtl = dataset.Tables[0];
            int rowcount = dtl.Rows.Count;
            if (rowcount == 0)
            {
                return "null";
            }
            DataRow col = dtl.Rows[0];
            String DischargeAmountstr = col["station_name"].ToString();
            DischargeAmountstr += "#flow";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["YYYY_MM"].ToString() + "," + col["flow"].ToString();
            }

            return DischargeAmountstr;
        }

        [WebMethod]
        public string Predict2011(int TT_start, int TT_end, int II)
        {
            string wherestr = "II = " + II + " and TT >= " + TT_start + " and TT <= " + TT_end;
            Maticsoft.BLL.MEASURAND_PREDICT_SECTION_2011 Bll = new Maticsoft.BLL.MEASURAND_PREDICT_SECTION_2011();
            DataSet dataset = Bll.GetList(1000, wherestr, "TT");
            DataTable dtl = dataset.Tables[0];
            int rowcount = dtl.Rows.Count;
            if (rowcount == 0)
            {
                return "null";
            }
            DataRow col = dtl.Rows[0];
            String DischargeAmountstr = col["II"].ToString();
            DischargeAmountstr += "#COD";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["COD"].ToString();
            }
            DischargeAmountstr += "#NH4";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["NH4"].ToString();
            }
            DischargeAmountstr += "#TP";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["TP"].ToString();
            }
            DischargeAmountstr += "#TN";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["TN"].ToString();
            }
            return DischargeAmountstr;
        }

        [WebMethod]
        public string Predict2012(int TT_start, int TT_end, int II)
        {
            string wherestr = "II = " + II + " and TT >= " + TT_start + " and TT <= " + TT_end;
            Maticsoft.BLL.MEASURAND_PREDICT_SECTION_2012 Bll = new Maticsoft.BLL.MEASURAND_PREDICT_SECTION_2012();
            DataSet dataset = Bll.GetList(1000, wherestr, "TT");
            DataTable dtl = dataset.Tables[0];
            int rowcount = dtl.Rows.Count;
            if (rowcount == 0)
            {
                return "null";
            }
            DataRow col = dtl.Rows[0];
            String DischargeAmountstr = col["II"].ToString();
            DischargeAmountstr += "#COD";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["COD"].ToString();
            }
            DischargeAmountstr += "#NH4";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["NH4"].ToString();
            }
            DischargeAmountstr += "#TP";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["TP"].ToString();
            }
            DischargeAmountstr += "#TN";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["TN"].ToString();
            }
            return DischargeAmountstr;
        }

        [WebMethod]
        public string Predict2013(int TT_start, int TT_end, int II)
        {
            string wherestr = "II = " + II + " and TT >= " + TT_start + " and TT <= " + TT_end;
            Maticsoft.BLL.MEASURAND_PREDICT_SECTION_2013 Bll = new Maticsoft.BLL.MEASURAND_PREDICT_SECTION_2013();
            DataSet dataset = Bll.GetList(1000, wherestr, "TT");
            DataTable dtl = dataset.Tables[0];
            int rowcount = dtl.Rows.Count;
            if (rowcount == 0)
            {
                return "null";
            }
            DataRow col = dtl.Rows[0];
            String DischargeAmountstr = col["II"].ToString();
            DischargeAmountstr += "#COD";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["COD"].ToString();
            }
            DischargeAmountstr += "#NH4";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["NH4"].ToString();
            }
            DischargeAmountstr += "#TP";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["TP"].ToString();
            }
            DischargeAmountstr += "#TN";
            for (int i = 0; i < rowcount; i++)
            {
                col = dtl.Rows[i];
                DischargeAmountstr += ";" + col["TT"].ToString() + "," + col["TN"].ToString();
            }
            return DischargeAmountstr;
        }
    }
}
