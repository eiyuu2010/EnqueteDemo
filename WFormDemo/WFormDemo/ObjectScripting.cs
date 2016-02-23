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

namespace WFormDemo
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class ObjectScripting
    {
        Form1 mainForm;
        public ObjectScripting(Form1 w)
        {
            this.mainForm = w;
        }
        public async Task TestGetMaji()
        {
            try
            {
                Encoding enc = Encoding.UTF8;// Encoding.GetEncoding("Shift_JIS");
                string url = "http://mazii.net/api/mazii/%E6%A4%9C%E7%B4%A2/10";
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);

                HttpWebResponse res = (HttpWebResponse)await req.GetResponseAsync();
                Stream st = res.GetResponseStream();

                StreamReader sr = new StreamReader(st, enc);
                string html = sr.ReadToEnd();

                this.mainForm.lbMessage.Text = html;
                sr.Close();
                st.Close();
            }
            catch (WebException ex)
            {

            }
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

                HttpWebResponse res = (HttpWebResponse)await req.GetResponseAsync();
                Stream st = res.GetResponseStream();

                StreamReader sr = new StreamReader(st, enc);
                string html = sr.ReadToEnd();

                this.mainForm.lbMessage.Text = html;
                sr.Close();
                st.Close();
            }
            catch (WebException ex)
            {
                this.mainForm.lbMessage.Text = ex.Message.ToString();
            }
        }

        public async void InvokeMeFromJavascript(string jsscript)
        {
            this.mainForm.lbMessage.Text = string.Format("Message :{0}", jsscript);
            this.mainForm.webBrowser1.Document.InvokeScript("showEnd");
            await TestPOSTWebRequest();
            //await TestGetMaji();
        }
    }
}
