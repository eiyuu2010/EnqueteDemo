using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Collections;
using System.Threading.Tasks;

namespace WPFWebbrowser
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class ObjectForScriptingHelper
    {
        Window1 mExternalWPF;
        public ObjectForScriptingHelper(Window1 w)
        {
            this.mExternalWPF = w;
        }
        public void TestWebRequest()
        {
            Encoding enc = Encoding.GetEncoding("Shift_JIS");
            // "http://www.google.co.jp/";
            string url = "http://localhost:50858/api/enquete/";

            WebRequest req = WebRequest.Create(url);
            req.Method = "GET";
            WebResponse res = req.GetResponse();

            Stream st = res.GetResponseStream();
            StreamReader sr = new StreamReader(st, enc);
            string html = sr.ReadToEnd();
            mExternalWPF.tbMessageFromBrowser.Text = html;
            sr.Close();
            st.Close();

        }
        public async Task TestPOSTWebRequest()
        {
            try
            {
                Encoding enc = Encoding.GetEncoding("Shift_JIS");

                string url = "http://localhost:50858/api/enquete/";

                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "text/json";

                using (var streamWriter = new StreamWriter(await req.GetRequestStreamAsync()))
                {
                    string enquete = "{\"EnqueteId\":1,\"ContentId\":332,\"Param\":\"a=32&b=1212\"}";

                    streamWriter.Write(enquete);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                HttpWebResponse res = (HttpWebResponse) await req.GetResponseAsync();
                Stream st = res.GetResponseStream();

                StreamReader sr = new StreamReader(st, enc);
                string html = sr.ReadToEnd();
                mExternalWPF.tbMessageFromBrowser.Text = html;
                sr.Close();
                st.Close();
            }
            catch (WebException ex)
            {
                this.mExternalWPF.tbMessageFromBrowser.Text = ex.Message.ToString();
            }
        }
        public void TestPostEnquete()
        {
            Encoding enc = Encoding.GetEncoding("Shift_JIS");

            string url = "https://web2.agentec.jp/mc/windows8test/abvapi/enqueteReply/?contentId=0&abObjectId=253&replyDateStr=2016-02-23+00%3A51%3A13%2CGMT&deviceTypeId=5&sid=8ff17b13896f268f97a10d63e4381557";

            string param = "resourceId=1002876&q_1_435=2467";
            byte[] data = Encoding.ASCII.GetBytes(param);
            WebRequest req = WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;

            WebResponse res = req.GetResponse();
            Stream st = res.GetResponseStream();

            StreamReader sr = new StreamReader(st, enc);
            string html = sr.ReadToEnd();
            mExternalWPF.tbMessageFromBrowser.Text = html;
            sr.Close();
            st.Close();
        }
        public void SendEnquete()
        {
            string[] divideParams = System.Text.RegularExpressions.Regex.Split("resourceId=1002876&q_1_435=2467", "&");
            Dictionary<string, string> postParams = new Dictionary<string, string>();

            foreach (string item in divideParams)
            {
                string[] result = System.Text.RegularExpressions.Regex.Split(item, "=");
                if (!postParams.ContainsKey(result[0]))
                    postParams.Add(result[0], result[1]);
            }

            string param = "resourceId=1002876&q_1_435=2467";
            // POSTメソッドのパラメータ作成
            //foreach (string key in postParams.Keys)
            //    param += String.Format("{0}={1}&", key, postParams[key]);

            // paramをASCII文字列にエンコードする
            byte[] data = Encoding.ASCII.GetBytes(param);
            //"https://web2.agentec.jp/mc/windows8test/abvapi/enqueteReply/?contentId=0&abObjectId=253&replyDateStr=2016-02-23+00%3A51%3A13%2CGMT&deviceTypeId=5&sid=8ff17b13896f268f97a10d63e4381557";
            //http://localhost:50858/api/enquete/
            string url = "http://google.com";
            // リクエスト作成
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = data.Length;

            // ポストデータをリクエストに書き込む
            using (Stream reqStream = request.GetRequestStream())
                reqStream.Write(data, 0, data.Length);

            // レスポンスの取得
            WebResponse response = request.GetResponse();

            // 結果の読み込み
            string htmlString = "";
            using (Stream resStream = response.GetResponseStream())
            using (var reader = new StreamReader(resStream, Encoding.GetEncoding("Shift_JIS")))
            {
                htmlString = reader.ReadToEnd();
            }
        }
        public async void InvokeMeFromJavascript(string jsscript)
        {
            this.mExternalWPF.tbMessageFromBrowser.Text = string.Format("Message :{0}", jsscript);
            this.mExternalWPF.wbMain.InvokeScript("showEnd");


            //this.SendEnquete();
            //this.TestWebRequest();
            await TestPOSTWebRequest();
            //this.TestPostEnquete();
            //this.mExternalWPF.tbMessageFromBrowser.Text = this.HttpPost("https://web2.agentec.jp/mc/windows8test/abvapi/enqueteReply/?contentId=0&abObjectId=253&replyDateStr=2016-02-23+00%3A51%3A13%2CGMT&deviceTypeId=5&sid=8ff17b13896f268f97a10d63e4381557", "resourceId=1002876&q_1_435=2467");
            //this.mExternalWPF.tbMessageFromBrowser.Text = this.HttpPostGoogle();
        }

        public string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);

            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;

            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();

            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr =
                  new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public string HttpPostGoogle()
        {

            Encoding enc = Encoding.UTF8;

            string input = "私は普通のC#プログラマです。";

            string url = "http://translate.google.com/translate_t";
            string param = "";

            // ポスト・データの作成
            Hashtable ht = new Hashtable();

            ht["text"] = System.Uri.EscapeUriString(input);
            ht["langpair"] = "ja|en";
            ht["hl"] = "en";
            ht["ie"] = "UTF8";

            foreach (string k in ht.Keys)
            {
                param += String.Format("{0}={1}&", k, ht[k]);
            }
            byte[] data = Encoding.ASCII.GetBytes(param);

            // リクエストの作成
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = data.Length;

            // ポスト・データの書き込み
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            reqStream.Close();

            // レスポンスの取得と読み込み
            WebResponse res = req.GetResponse();
            Stream resStream = res.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, enc);
            string html = sr.ReadToEnd();
            sr.Close();
            resStream.Close();

            // 必要なデータの切り出し
            // 結果は「wrap=PHYSICAL>～</textarea>」にあるという前提
            string startmark = "wrap=PHYSICAL>";
            int start = html.IndexOf(startmark) + startmark.Length;
            int end = html.IndexOf("</textarea>", start);
            string result = html.Substring(start, end - start);
            return result;

            // 出力：I am the normal C# programmer.
        }
    }

}
