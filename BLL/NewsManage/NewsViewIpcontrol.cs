using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Maticsoft.BLL.NewsManage
{
   public class NewsViewIpcontrol
    {
        public NewsViewIpcontrol()
        { }
        public bool IpAllow(string thisIp,string XmlPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlPath);

            bool Isallow = false;

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("allowip").ChildNodes;//获取Employees节点的所有子节点     

            foreach (XmlNode xn in nodeList)//遍历所有子节点     
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                // Response.Write(xe.Name);
                string strIp = xe.ChildNodes[0].InnerText;
                string endIp = xe.ChildNodes[1].InnerText;
                //输出IP Pool
                //Response.Write(strIp + "---" + endIp + "<br/>");
                if (BetweenPool(thisIp, strIp, endIp))
                {
                    Isallow = true;
                    break;
                }
            }
            return Isallow;
        }


        private bool BetweenPool(string Ip, string StartIp, string EndIp)
        {
            bool flag = false;
            if (IPCompare(Ip, StartIp) >= 0)
                if (IPCompare(Ip, EndIp) <= 0)
                {
                    flag = true;
                }
            return flag;
            // return StartIp.CompareTo(StartIp);
        }

        /// <summary>
        /// IP地址比较，如果startIp>endIp，返回　1，endIp>startIp  ，返回－1，startIp=endIp，返回0
        /// 确保结束ip大于开始ip
        /// </summary>
        private int IPCompare(string startIP, string endIP)
        {
            // 分离出ip中的四个数字位
            int result = 0;
            string[] startIPArray = startIP.Split('.');
            string[] endIPArray = endIP.Split('.');

            // 取得各个数字
            long[] startIPNum = new long[4];
            long[] endIPNum = new long[4];
            for (int i = 0; i < 4; i++)
            {
                startIPNum[i] = long.Parse(startIPArray[i].Trim());
                endIPNum[i] = long.Parse(endIPArray[i].Trim());
            }

            // 各个数字乘以相应的数量级
            long startIPNumTotal = startIPNum[0] * 256 * 256 * 256 + startIPNum[1] * 256 * 256 + startIPNum[2] * 256 + startIPNum[3];
            long endIPNumTotal = endIPNum[0] * 256 * 256 * 256 + endIPNum[1] * 256 * 256 + endIPNum[2] * 256 + endIPNum[3];

            if (startIPNumTotal > endIPNumTotal)
            {
                result = 1;
            }
            else if (startIPNumTotal < endIPNumTotal)
            {
                result = -1;
            }
            else
                result = 0;
            return result;
        } 

    }
}
