namespace IPSS
{
    partial class frmDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemo));
            this.grCamera = new System.Windows.Forms.GroupBox();
            this.rdNetworkCamera = new System.Windows.Forms.RadioButton();
            this.rdLocalCamera = new System.Windows.Forms.RadioButton();
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.groupSrc = new System.Windows.Forms.GroupBox();
            this.btnSelectFolderOutput = new System.Windows.Forms.Button();
            this.btnDetect = new System.Windows.Forms.Button();
            this.rdFolder = new System.Windows.Forms.RadioButton();
            this.txtFolderOutput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.Label();
            this.rdImage = new System.Windows.Forms.RadioButton();
            this.rdCamera = new System.Windows.Forms.RadioButton();
            this.grImage = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSnapshot = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerStream = new System.Windows.Forms.Timer(this.components);
            this.timerAutoDetect = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.grCamera.SuspendLayout();
            this.groupSrc.SuspendLayout();
            this.grImage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSnapshot)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grCamera
            // 
            this.grCamera.Controls.Add(this.rdNetworkCamera);
            this.grCamera.Controls.Add(this.rdLocalCamera);
            this.grCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.grCamera.Location = new System.Drawing.Point(0, 195);
            this.grCamera.Name = "grCamera";
            this.grCamera.Size = new System.Drawing.Size(999, 85);
            this.grCamera.TabIndex = 0;
            this.grCamera.TabStop = false;
            this.grCamera.Text = "Camera";
            this.grCamera.Visible = false;
            // 
            // rdNetworkCamera
            // 
            this.rdNetworkCamera.AutoSize = true;
            this.rdNetworkCamera.Location = new System.Drawing.Point(21, 48);
            this.rdNetworkCamera.Name = "rdNetworkCamera";
            this.rdNetworkCamera.Size = new System.Drawing.Size(103, 17);
            this.rdNetworkCamera.TabIndex = 6;
            this.rdNetworkCamera.Text = "Network camera";
            this.toolTip1.SetToolTip(this.rdNetworkCamera, "Using IP camera");
            this.rdNetworkCamera.UseVisualStyleBackColor = true;
            this.rdNetworkCamera.CheckedChanged += new System.EventHandler(this.rdNetworkCamera_CheckedChanged);
            // 
            // rdLocalCamera
            // 
            this.rdLocalCamera.Location = new System.Drawing.Point(21, 22);
            this.rdLocalCamera.Name = "rdLocalCamera";
            this.rdLocalCamera.Size = new System.Drawing.Size(90, 17);
            this.rdLocalCamera.TabIndex = 5;
            this.rdLocalCamera.Text = "Local camera";
            this.toolTip1.SetToolTip(this.rdLocalCamera, "Using webcam");
            this.rdLocalCamera.UseVisualStyleBackColor = true;
            this.rdLocalCamera.CheckedChanged += new System.EventHandler(this.rdLocalCamera_CheckedChanged);
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Interval = 10;
            // 
            // groupSrc
            // 
            this.groupSrc.Controls.Add(this.btnSelectFolderOutput);
            this.groupSrc.Controls.Add(this.btnDetect);
            this.groupSrc.Controls.Add(this.rdFolder);
            this.groupSrc.Controls.Add(this.txtFolderOutput);
            this.groupSrc.Controls.Add(this.label6);
            this.groupSrc.Controls.Add(this.txtResult);
            this.groupSrc.Controls.Add(this.rdImage);
            this.groupSrc.Controls.Add(this.rdCamera);
            this.groupSrc.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSrc.Location = new System.Drawing.Point(0, 24);
            this.groupSrc.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.groupSrc.Name = "groupSrc";
            this.groupSrc.Size = new System.Drawing.Size(999, 86);
            this.groupSrc.TabIndex = 4;
            this.groupSrc.TabStop = false;
            this.groupSrc.Text = "Image source";
            // 
            // btnSelectFolderOutput
            // 
            this.btnSelectFolderOutput.Location = new System.Drawing.Point(394, 49);
            this.btnSelectFolderOutput.Name = "btnSelectFolderOutput";
            this.btnSelectFolderOutput.Size = new System.Drawing.Size(24, 23);
            this.btnSelectFolderOutput.TabIndex = 9;
            this.btnSelectFolderOutput.Text = "...";
            this.btnSelectFolderOutput.UseVisualStyleBackColor = true;
            this.btnSelectFolderOutput.Click += new System.EventHandler(this.btnSelectFolderOutput_Click);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(268, 12);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(100, 33);
            this.btnDetect.TabIndex = 4;
            this.btnDetect.Text = "Start detect (F5)";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.EnabledChanged += new System.EventHandler(this.btnDetect_EnabledChanged);
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // rdFolder
            // 
            this.rdFolder.AutoSize = true;
            this.rdFolder.Location = new System.Drawing.Point(180, 20);
            this.rdFolder.Name = "rdFolder";
            this.rdFolder.Size = new System.Drawing.Size(54, 17);
            this.rdFolder.TabIndex = 3;
            this.rdFolder.Text = "Folder";
            this.toolTip1.SetToolTip(this.rdFolder, "Detect batch image in folder");
            this.rdFolder.UseVisualStyleBackColor = true;
            this.rdFolder.CheckedChanged += new System.EventHandler(this.rdFolder_CheckedChanged);
            // 
            // txtFolderOutput
            // 
            this.txtFolderOutput.Location = new System.Drawing.Point(117, 50);
            this.txtFolderOutput.Name = "txtFolderOutput";
            this.txtFolderOutput.Size = new System.Drawing.Size(273, 20);
            this.txtFolderOutput.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Output folder";
            // 
            // txtResult
            // 
            this.txtResult.AutoSize = true;
            this.txtResult.BackColor = System.Drawing.SystemColors.Control;
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.ForeColor = System.Drawing.Color.Red;
            this.txtResult.Location = new System.Drawing.Point(386, 14);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(0, 26);
            this.txtResult.TabIndex = 2;
            // 
            // rdImage
            // 
            this.rdImage.AutoSize = true;
            this.rdImage.Location = new System.Drawing.Point(102, 20);
            this.rdImage.Name = "rdImage";
            this.rdImage.Size = new System.Drawing.Size(54, 17);
            this.rdImage.TabIndex = 1;
            this.rdImage.Text = "Image";
            this.toolTip1.SetToolTip(this.rdImage, "Detect license plate from 1 static image");
            this.rdImage.UseVisualStyleBackColor = true;
            this.rdImage.CheckedChanged += new System.EventHandler(this.rdImage_CheckedChanged);
            // 
            // rdCamera
            // 
            this.rdCamera.Location = new System.Drawing.Point(21, 20);
            this.rdCamera.Name = "rdCamera";
            this.rdCamera.Size = new System.Drawing.Size(61, 17);
            this.rdCamera.TabIndex = 0;
            this.rdCamera.Text = "Camera";
            this.toolTip1.SetToolTip(this.rdCamera, "Detect license plate realtime");
            this.rdCamera.UseVisualStyleBackColor = true;
            // 
            // grImage
            // 
            this.grImage.Controls.Add(this.btnBrowse);
            this.grImage.Controls.Add(this.txtFilePath);
            this.grImage.Controls.Add(this.label5);
            this.grImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grImage.Location = new System.Drawing.Point(0, 110);
            this.grImage.Name = "grImage";
            this.grImage.Size = new System.Drawing.Size(999, 85);
            this.grImage.TabIndex = 5;
            this.grImage.TabStop = false;
            this.grImage.Text = "Static image";
            this.grImage.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(396, 37);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(117, 39);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(273, 20);
            this.txtFilePath.TabIndex = 3;
            this.txtFilePath.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "File path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSnapshot);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.picCamera);
            this.groupBox1.Controls.Add(this.picResult);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 316);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Image = global::IPSS.Properties.Resources.save;
            this.btnSnapshot.Location = new System.Drawing.Point(483, 25);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(20, 18);
            this.btnSnapshot.TabIndex = 12;
            this.btnSnapshot.TabStop = false;
            this.btnSnapshot.Visible = false;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.lblMessage});
            this.statusStrip1.Location = new System.Drawing.Point(3, 291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TextChanged += new System.EventHandler(this.lblMessage_TextChanged);
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(23, 17);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(480, 360);
            this.picCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCamera.TabIndex = 4;
            this.picCamera.TabStop = false;
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(509, 17);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(480, 360);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picResult.TabIndex = 9;
            this.picResult.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyPath,
            this.btnCopyImage,
            this.btnOpenImage,
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 92);
            this.contextMenuStrip1.Text = "Copy path";
            // 
            // btnCopyPath
            // 
            this.btnCopyPath.Name = "btnCopyPath";
            this.btnCopyPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.btnCopyPath.Size = new System.Drawing.Size(171, 22);
            this.btnCopyPath.Text = "Copy path";
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(171, 22);
            this.btnCopyImage.Text = "Copy image";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(171, 22);
            this.btnOpenImage.Text = "Open image";
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 22);
            this.btnDelete.Text = "Delete image";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timerStream
            // 
            this.timerStream.Interval = 50;
            this.timerStream.Tick += new System.EventHandler(this.timerStream_Tick);
            // 
            // timerAutoDetect
            // 
            this.timerAutoDetect.Interval = 500;
            this.timerAutoDetect.Tick += new System.EventHandler(this.timerAutoDetect_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(999, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // timerDraw
            // 
            this.timerDraw.Interval = 30;
            // 
            // timerClear
            // 
            this.timerClear.Interval = 3000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // frmDemo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(999, 596);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grCamera);
            this.Controls.Add(this.grImage);
            this.Controls.Add(this.groupSrc);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmDemo";
            this.Text = "Phần mềm đọc biển số xe máy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDemo_FormClosed);
            this.Shown += new System.EventHandler(this.frmDemo_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmDemo_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmDemo_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDemo_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmDemo_KeyUp);
            this.grCamera.ResumeLayout(false);
            this.grCamera.PerformLayout();
            this.groupSrc.ResumeLayout(false);
            this.groupSrc.PerformLayout();
            this.grImage.ResumeLayout(false);
            this.grImage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSnapshot)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grCamera;
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.GroupBox groupSrc;
        private System.Windows.Forms.GroupBox grImage;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton rdImage;
        private System.Windows.Forms.RadioButton rdCamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label txtResult;
        private System.Windows.Forms.RadioButton rdFolder;
        private System.Windows.Forms.TextBox txtFolderOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSelectFolderOutput;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.RadioButton rdNetworkCamera;
        private System.Windows.Forms.RadioButton rdLocalCamera;
        private WebEye.StreamPlayerControl streamPlayer;
        private System.Windows.Forms.PictureBox btnSnapshot;
        private System.Windows.Forms.Timer timerStream;
        private System.Windows.Forms.Timer timerAutoDetect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyPath;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.ToolStripMenuItem btnCopyImage;
        private System.Windows.Forms.ToolStripMenuItem btnOpenImage;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
    }
}