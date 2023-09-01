using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace IPSSlistener
{
    public partial class Form1 : Form
    {
        PlateReader reader;
        HttpServer server;
        static Form1 m_instance;
        Thread t;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();

            reader = new PlateReader();
            server = new HttpServer(8888);
            server.SetGEThandler(HandleGETRequest);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Form1 GetInstance()
        {
            if (m_instance == null)
                m_instance = new Form1();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Thread(new ThreadStart(server.Listen));
            t.IsBackground = true;
            t.Start();        
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string HandleGETRequest(string GETdata)
        {
            string filename = GETdata.Replace("/", "");
            PlateInfo plate = Form1.GetInstance().reader.Read(filename);
            return plate.text;
        }
    }
}
