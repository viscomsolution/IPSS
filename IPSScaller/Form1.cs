using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPSScaller
{
    public partial class Form1 : Form
    {
        Stopwatch watch;

        string url = "http://localhost:8888/";

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
        public Form1()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = "20151006120042_103.jpg";
            SendGETrequest(url + filename);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SendGETrequest(string request)
        {
            watch = Stopwatch.StartNew();

            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(request);

                WebProxy myProxy = new WebProxy("myproxy", 80);
                myProxy.BypassProxyOnLocal = true;

                wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                Stream objStream = wrGETURL.GetResponse().GetResponseStream();
                StreamReader objReader = new StreamReader(objStream);

                string respond = "";
                string line = "";

                while (line != null)
                {
                    line = objReader.ReadLine();
                    if (line != null)
                    {
                        respond = line;
                        break;
                    }                        
                }

                watch.Stop();
                label1.Text =  respond + " (" + DateTime.Now.ToString("hh:mm:ss") + "   " +  watch.ElapsedMilliseconds.ToString() + "ms)";
            }
        }
    }
}
