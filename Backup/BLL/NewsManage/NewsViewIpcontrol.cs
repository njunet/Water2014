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

            XmlNodeList nodeList = xmlDoc.SelectSingleNode("allowip").ChildNodes;//��ȡEmployees�ڵ�������ӽڵ�     

            foreach (XmlNode xn in nodeList)//���������ӽڵ�     
            {
                XmlElement xe = (XmlElement)xn;//���ӽڵ�����ת��ΪXmlElement���� 
                XmlNodeList nls = xe.ChildNodes;//������ȡxe�ӽڵ�������ӽڵ� 
                // Response.Write(xe.Name);
                string strIp = xe.ChildNodes[0].InnerText;
                string endIp = xe.ChildNodes[1].InnerText;
                //���IP Pool
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
        /// IP��ַ�Ƚϣ����startIp>endIp�����ء�1��endIp>startIp  �����أ�1��startIp=endIp������0
        /// ȷ������ip���ڿ�ʼip
        /// </summary>
        private int IPCompare(string startIP, string endIP)
        {
            // �����ip�е��ĸ�����λ
            int result = 0;
            string[] startIPArray = startIP.Split('.');
            string[] endIPArray = endIP.Split('.');

            // ȡ�ø�������
            long[] startIPNum = new long[4];
            long[] endIPNum = new long[4];
            for (int i = 0; i < 4; i++)
            {
                startIPNum[i] = long.Parse(startIPArray[i].Trim());
                endIPNum[i] = long.Parse(endIPArray[i].Trim());
            }

            // �������ֳ�����Ӧ��������
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
