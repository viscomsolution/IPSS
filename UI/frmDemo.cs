using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Drawing.Drawing2D;
using System.Net;
using System.Resources;
using TGMTcs;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Microsoft.VisualBasic.FileIO;

namespace IPSS
{
    public partial class frmDemo : Form
    {
        #region global_variable
        

        Point[] m_points;
        int OFFSET;
        float g_scaleX = 1;
        float g_scaleY = 1;
        

        IPSSbike bikeDetector;

        enum Colision
        {
            TopLeft,
            TopRight,
            BotLeft,
            BotRight,
            None,
        }
        Colision g_colisionState = Colision.None;
        bool g_isMouseDown = false;
        Bitmap g_bmp;

        int selectPointIdx = -1;


        bool m_isFirstLoading = true;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region common_function

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void SetScaleRatio()
        {
            g_scaleX = (float)g_bmp.Width / picCamera.Width;
            g_scaleY = (float)g_bmp.Height / picCamera.Height;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintPoint()
        {
            string output = "";
            for (int i = 0; i < m_points.Length; i++)
            {
                output += "(" + m_points[i].X + " ; " + m_points[i].Y + ") ";
            }
            PrintMessage(output);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Point[] GetScaledPoint()
        {
            Point[] scaledPoints = new Point[4];
            scaledPoints[0] = new Point((int)(m_points[0].X * g_scaleX), (int)(m_points[0].Y * g_scaleY));
            scaledPoints[1] = new Point((int)(m_points[1].X * g_scaleX), (int)(m_points[1].Y * g_scaleY));
            scaledPoints[2] = new Point((int)(m_points[2].X * g_scaleX), (int)(m_points[2].Y * g_scaleY));
            scaledPoints[3] = new Point((int)(m_points[3].X * g_scaleX), (int)(m_points[3].Y * g_scaleY));
            return scaledPoints;
        }
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            lblMessage.Text = message;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitDetector()
        {
            lblMessage.Text = "Loading data, please wait...";
            btnDetect.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ReadPlate()
        {
            if (!rdCamera.Checked && !rdImage.Checked && !rdFolder.Checked)
            {
                PrintError("Source image not selected");
                return;
            }

            if (bikeDetector == null)
            {
                MessageBox.Show("Please contact to author to fix problem");
                return;
            }

            bikeDetector.OutputFoler = txtFolderOutput.Text;

            if (rdCamera.Checked) //camera
            {
                if (rdNetworkCamera.Checked)
                {
                    if (streamPlayer.IsPlaying)
                        g_bmp = streamPlayer.GetCurrentFrame();
                }
                if (g_bmp == null)
                {
                    PrintError("Image is null");
                    return;
                }

                Bitmap bmp = (Bitmap)g_bmp.Clone();
                if (bmp == null)
                    return;


                BikePlate result = bikeDetector.ReadPlate(bmp);
                if (result.bitmap != null)
                    picResult.Image = result.bitmap;

                txtResult.Text = result.text;
                PrintMessage(result.error + " (" + result.elapsedMilisecond.ToString() + " ms)");
            }
            else if (rdImage.Checked) //static image
            {
                if (g_bmp == null)
                {
                    PrintError("Image is null");
                    return;
                }
                BikePlate result = bikeDetector.ReadPlate((Bitmap)g_bmp.Clone());
                txtResult.Text = result.text;

                if (result.bitmap != null)
                    picResult.Image = result.bitmap;
                PrintMessage(result.error + " (" + result.elapsedMilisecond + " ms)");
            }
            else if (rdFolder.Checked) //folder
            {
                
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StopAllCamera()
        {
            if (streamPlayer != null && streamPlayer.IsPlaying)
                streamPlayer.Stop();

            //if (m_videoSource != null)
            //    m_videoSource.Stop();

            picCamera.Image = null;
            btnSnapshot.Visible = false;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region form

        public frmDemo()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_Shown(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().Init("IPSS");
            bikeDetector = new IPSSbike();
            if (bikeDetector == null)
            {
                return;
            }

            CheckForIllegalCrossThreadCalls = false;
            this.KeyPreview = true;
            
            this.Text += " " + bikeDetector.Version;
            this.Text += bikeDetector.IsLicense ? " (Licensed)" : " (Vui lòng liên hệ: 0939.825.125)";            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopAllCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control)
                return;
            if ((int)e.KeyCode >= 97 && (int)e.KeyCode <= 101)
            {
                selectPointIdx = (int)e.KeyCode - 97;
                picCamera.Refresh();
            }
            else if ((int)e.KeyCode >= 49 && (int)e.KeyCode <= 52)
            {
                selectPointIdx = (int)e.KeyCode - 49;
                picCamera.Refresh();
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        m_points[selectPointIdx].Y -= 10;
                        break;
                    case Keys.Down:
                        m_points[selectPointIdx].Y += 10;
                        break;
                    case Keys.Left:
                        m_points[selectPointIdx].X -= 10;
                        break;
                    case Keys.Right:
                        m_points[selectPointIdx].X += 10;
                        break;
                }

                PrintPoint();
                picCamera.Refresh();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ReadPlate();
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerAutoDetect_Tick(object sender, EventArgs e)
        {
            ReadPlate();
        }

        #endregion //form

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region select_source


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdImage.Checked)
            {
                StopAllCamera();
                grCamera.Visible = false;
                grImage.Visible = true;

                txtFilePath.Text = TGMTregistry.GetInstance().ReadString("txtFilePath");
            }
            else
            {
                if (picCamera.Image != null)
                {
                    picCamera.Image.Dispose();
                    picCamera.Image = null;
                }

                if (picResult.Image != null)
                {
                    picResult.Image.Dispose();
                    picResult.Image = null;
                }

                if (g_bmp != null)
                {
                    g_bmp.Dispose();
                    g_bmp = null;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdFolder_CheckedChanged(object sender, EventArgs e)
        {
            txtResult.Text = "";
            if (picCamera.Image != null)
                picCamera.Image.Dispose();
            if (picResult.Image != null)
                picResult.Image = null;

            if (rdFolder.Checked)
            {
                if (m_isFirstLoading)
                {
                    //txtFolderInput.Text = TGMTregistry.GetInstance().ReadString("folderInput");

                    m_isFirstLoading = false;
                }


                StopAllCamera();
                grCamera.Visible = false;
                grImage.Visible = false;

                g_scaleX = 1;
                g_scaleY = 1;

                picCamera.Visible = false;

            }
            else
            {
                picCamera.Visible = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDetect_Click(object sender, EventArgs e)
        {
            ReadPlate();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnDetect_EnabledChanged(object sender, EventArgs e)
        {
            if (btnDetect.Enabled)
            {
                //StopLoading();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void frmDemo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        #endregion //select_source

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region group_image_source

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(txtFilePath.Text))
                return;

            TGMTregistry.GetInstance().SaveValue("txtFilePath", txtFilePath.Text);

            if (g_bmp != null)
                g_bmp.Dispose();
            try
            {
                g_bmp = new Bitmap(txtFilePath.Text);
                picCamera.Image = g_bmp;

                SetScaleRatio();

                ReadPlate();
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files |*.bmp;*.jpg;*.png;*.BMP;*.JPG;*.PNG";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                txtFilePath.Text = ofd.FileName;
            }

        }

        #endregion //group_image_source

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region group_camera_source


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdLocalCamera_CheckedChanged(object sender, EventArgs e)
        {
            //PrintMessage("");
            //picCamera.Image = null;
            //btnSnapshot.Visible = false;
            //cbCamera.Enabled = rdLocalCamera.Checked;

            //if (rdLocalCamera.Checked)
            //{
            //    if (streamPlayer != null && streamPlayer.IsPlaying)
            //        streamPlayer.Stop();

            //    timerStream.Stop();
            //    ConnectLocalCamera();
            //}
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rdNetworkCamera_CheckedChanged(object sender, EventArgs e)
        {
            //txtIpAddress.Enabled = btnConnectCameraIP.Enabled = rdNetworkCamera.Checked;

            //if (rdNetworkCamera.Checked)
            //{
            //    if (m_videoSource != null)
            //        m_videoSource.Stop();
            //}
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnConnectCameraIP_Click(object sender, EventArgs e)
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void HandleStreamFailedEvent(object sender, WebEye.StreamFailedEventArgs e)
        {
            PrintError("Can not connect to camera IP");
        }

        private void streamPlayer_StreamStarted(object sender, EventArgs e)
        {
            timerStream.Start();
            //btnConnectCameraIP.Text = "Stop";
            btnSnapshot.Visible = true;
            PrintMessage("Playing");
        }

        private void streamPlayer_StreamStopped(object sender, EventArgs e)
        {
            timerStream.Stop();
            //btnConnectCameraIP.Text = "Start";
            btnSnapshot.Visible = false;
            PrintMessage("Stopped");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerStream_Tick(object sender, EventArgs e)
        {
            g_bmp = streamPlayer.GetCurrentFrame();
            g_scaleX = (float)g_bmp.Width / picCamera.Width;
            g_scaleY = (float)g_bmp.Height / picCamera.Height;

            picCamera.Image = g_bmp;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkAutodetect_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAutodetect.Checked)
            //    timerAutoDetect.Start();
            //else
            //    timerAutoDetect.Stop();
        }

        #endregion //group_camera_source

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region group_folder_source

        private void btnSelectFolderInput_Click(object sender, EventArgs e)
        {

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnSelectFolderOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "")
            {
                string dirPath = fbd.SelectedPath;
                txtFolderOutput.Text = dirPath;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtFailedDir_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtValidDir_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }


        #endregion //group_folder_source
                


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            timerClear.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerClear_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            timerClear.Stop();
        }        
    }
}
