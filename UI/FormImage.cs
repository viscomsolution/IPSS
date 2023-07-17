using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace UI
{
    public partial class FormImage : Form
    {
        static FormImage m_instance;
        Stopwatch watch;

        public FormImage()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormImage GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormImage();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormImage_Load(object sender, EventArgs e)
        {
            chk_draw.Checked = Program.reader.DrawRectangle;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_select_Click(object sender, EventArgs e)
        {
            txt_fileName.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image file |*.jpg;*.png*.bmp;*.PNG;";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                txt_fileName.Text = ofd.FileName;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_fileName_TextChanged(object sender, EventArgs e)
        {
            if (txt_fileName.Text == "")
                return;

            btn_select.Enabled = false;

            string fileName = txt_fileName.Text.Replace("\"", "");
            lbl_result.Text = "";
            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(fileName);
            if(bmp != null)
            {
                picInput.Image = bmp;
                FormMain.GetInstance().PrintMessage("");
                FormMain.GetInstance().StartProgressbar();

                watch = Stopwatch.StartNew();
                Thread t = new Thread(() => Read(fileName));
                t.Start();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_draw_CheckedChanged(object sender, EventArgs e)
        {
            Program.reader.DrawRectangle = chk_draw.Checked;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Read(string imagePath)
        {            
            PlateInfo result = Program.reader.Read(imagePath);
            this.Invoke(new Action(() =>
            {
                watch.Stop();
                FormMain.GetInstance().StopProgressbar();
                lbl_result.Text = result.text;

                if (result.bitmap == null)
                {
                    FormMain.GetInstance().PrintMessage(result.error);
                }
                else
                {                    
                    picResult.Image = result.bitmap;
                    FormMain.GetInstance().PrintMessage("Elapsed: " + watch.ElapsedMilliseconds.ToString() + "ms");

                    string outputName = "output\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".jpg";
                    result.bitmap.Save(outputName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                btn_select.Enabled = true;                
                
            }));
        }
    }
}
