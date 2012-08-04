using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using KH.Utilities;
using KH.Config;
using System.Web.Script.Serialization;
using Website_Extractor.DataContainer;

namespace Website_Extractor
{
    public static class HtmlExtractor
    {
        private static JavaScriptSerializer jss = new JavaScriptSerializer();

        public static string getDataFromWebpage(string url)
        {
            string urlAddress = url;
            string data = "";
            bool done = false;
            int waited = 0;
            while (!done && waited < 3000)
            {
                try
                {
                    data = getData(urlAddress);
                    done = true;
                }
                catch
                {
                    Thread.Sleep(300);
                    waited += 300;
                }
            }
            if (waited >= 3000)
                return getData(url);
            return data;
        }

        public static void CreatePatternForTop50(string path)
        {
            string url = GlobalData.BaseURLPath + GlobalData.SelectedWorldURLPart + "/players/";
            string page = HtmlExtractor.getDataFromWebpage(url);
            string[] players = page.Split(new string[] { "<td>" }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder build = new StringBuilder();
            for (int i = 2, j = players.Length; i < j; i += 5)
            {
                string playerName = players[i].Split(new string[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries)[0];
                build.Append(playerName + ";");
                build.Append(players[i + 3].Split(new string[] { "/player/" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "\"" }, StringSplitOptions.RemoveEmptyEntries)[0] + "\r\n");
            }
            TextDatei.WriteFile(path, build.ToString());
        }

        public static string getAllianceNameForID(string id)
        {
            string name;
            int allyID;
            allyID = Convert.ToInt32(id);
            string page = HtmlExtractor.getDataFromWebpage(GlobalData.BaseURLPath + GlobalData.SelectedWorldURLPart + "/alliance/" + id);
            name = page.Split(new string[] { "<h3>" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { " [" }, StringSplitOptions.RemoveEmptyEntries)[0].Replace(' ', '_');
            return name;
        }

        private static string getData(string url)
        {
            string data = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            return data;
        }

        public static string getMethod(string path, string proxy)
        {
            path = "http://api.cnc-alliances.com/" + path;
            string param = "{\"api_key\":\"dummy\"}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] baASCIIPostData = encoding.GetBytes(param);

            HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(path);
            if (proxy == "")
                HttpWReq.Proxy = new WebProxy();
            else
                HttpWReq.Proxy = new WebProxy(proxy);
            HttpWReq.Method = "POST";
            HttpWReq.Accept = "text/plain";
            HttpWReq.ContentType = "application/x-www-form-urlencoded";
            HttpWReq.ContentLength = baASCIIPostData.Length;
            // Prepare web request and send the data.

            Stream streamReq = HttpWReq.GetRequestStream();
            streamReq.Write(baASCIIPostData, 0, baASCIIPostData.Length);

            HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            Stream streamResponse = HttpWResp.GetResponseStream();

            // And read it out
            StreamReader reader = new StreamReader(streamResponse);
            return reader.ReadToEnd();
        }

        public static string getMethod(object pars, string proxy)//string path, string moreParam)
        {
            object[] par = pars as object[];
            string path = par[0].ToString();
            string moreParam = par[1].ToString();
            path = "http://api.cnc-alliances.com/" + path;
            string param = "{\"api_key\":\"dummy\"" + moreParam + "}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] baASCIIPostData = encoding.GetBytes(param);

            HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(path);
            if (proxy == "")
                HttpWReq.Proxy = new WebProxy();
            else
                HttpWReq.Proxy = new WebProxy(proxy);
            HttpWReq.Method = "POST";
            HttpWReq.Accept = "text/plain";
            HttpWReq.ContentType = "application/x-www-form-urlencoded";
            HttpWReq.ContentLength = baASCIIPostData.Length;
            // Prepare web request and send the data.
            Stream streamReq = HttpWReq.GetRequestStream();
            streamReq.Write(baASCIIPostData, 0, baASCIIPostData.Length);

            //HttpWReq.BeginGetResponse(new AsyncCallback(Stats.FinishWebRequest), HttpWReq);
            HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            Stream streamResponse = HttpWResp.GetResponseStream();

            // And read it out
            StreamReader reader = new StreamReader(streamResponse);
            return reader.ReadToEnd(); 
        }
    }
}
