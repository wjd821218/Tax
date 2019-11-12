using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace InvoiceBill.Basic
{
    class Global
    {
        static string VFile = "rfclient.ini";
        static string VUrl = "http://192.168.0.5/EIIP/" + VFile;
        //static string VUrl = "http://218.93.6.222/" + VFile;

        public static bool needUpgrade()
        {
            string localVsn = getlocalVersion();
            string remoteVsn = getRemoteVersion();

            return !localVsn.Equals(remoteVsn);
        }

        public static string getlocalVersion()
        {
            try
            {
                string localVfile = (getExecutingPath() + VFile);

                //if (!new FileInfo(localVfile).Exists)
                //throw new Exception("找不到本地" + VFile + "文件！");

                FileStream fs = new FileStream(localVfile, FileMode.Open);
                string version = getVersion("本地" + VFile, fs);
                fs.Close();
                return version;
            }
            catch (Exception ex)
            {
                return "1.0";
            }
        }

        private static string getRemoteVersion()
        {
            HttpWebRequest oReq = (HttpWebRequest)HttpWebRequest.Create(VUrl);
            oReq.Timeout = 30000;
            Stream srRet = oReq.GetResponse().GetResponseStream();
            string version = getVersion("远程" + VFile, srRet);
            srRet.Close();
            return version;
        }

        private static string getVersion(string type, Stream stm)
        {
            string line = null;
            try
            {
                StreamReader sreader = new StreamReader(stm);

                while ((line = sreader.ReadLine()) != null)
                {
                    if (line.StartsWith("[Version]"))
                    {
                        line = sreader.ReadLine();
                        break;
                    }
                }
                sreader.Close();
            }
            catch
            {
                return "1.0.0.0";
            }
            string[] values = line.Split('_');
            if (values.Length > 1)
                return values[0];
            else
            {
                return "1.0.0.0";
            }
        }
        /// <summary>
        /// 执行文件所在目录
        /// </summary>
        private static string getExecutingPath()
        {
            string fullAppName = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string fullAppPath = Path.GetDirectoryName(fullAppName);

            if (fullAppPath.StartsWith("file:"))
                fullAppPath = fullAppPath.Substring(6);

            if (fullAppPath.Substring(fullAppPath.Length - 1, 1) != "\\")
                fullAppPath += "\\";

            return fullAppPath;
        }

   

    }
}
