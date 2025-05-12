namespace wCapture
{
    partial class cap
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.displayControl = new PvGUIDotNet.PvDisplayControl();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.btnStartstream = new System.Windows.Forms.Button();
            this.btnStopstream = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.displayControl1 = new PvGUIDotNet.PvDisplayControl();
            this.btnConnect1 = new System.Windows.Forms.Button();
            this.btnStartstream1 = new System.Windows.Forms.Button();
            this.btnStopstream1 = new System.Windows.Forms.Button();
            this.btnConfigure1 = new System.Windows.Forms.Button();
            this.btnDisconnect1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // displayControl
            // 
            this.displayControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayControl.BackColor = System.Drawing.Color.Transparent;
            this.displayControl.BackgroundColor = System.Drawing.Color.DarkGray;
            this.displayControl.Location = new System.Drawing.Point(96, 12);
            this.displayControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.displayControl.Name = "displayControl";
            this.displayControl.ROI = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.displayControl.Size = new System.Drawing.Size(331, 307);
            this.displayControl.TabIndex = 8;
            this.displayControl.TextOverlay = "";
            this.displayControl.TextOverlayColor = System.Drawing.Color.Lime;
            this.displayControl.TextOverlayOffsetX = 10;
            this.displayControl.TextOverlayOffsetY = 10;
            this.displayControl.TextOverlaySize = 18;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(30, 11);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(60, 33);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Enabled = false;
            this.btnConfigure.Location = new System.Drawing.Point(30, 70);
            this.btnConfigure.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(60, 38);
            this.btnConfigure.TabIndex = 10;
            this.btnConfigure.Text = "configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // btnStartstream
            // 
            this.btnStartstream.Enabled = false;
            this.btnStartstream.Location = new System.Drawing.Point(30, 131);
            this.btnStartstream.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStartstream.Name = "btnStartstream";
            this.btnStartstream.Size = new System.Drawing.Size(60, 34);
            this.btnStartstream.TabIndex = 12;
            this.btnStartstream.Text = "startstream";
            this.btnStartstream.UseVisualStyleBackColor = true;
            this.btnStartstream.Click += new System.EventHandler(this.btnStartstream_Click);
            // 
            // btnStopstream
            // 
            this.btnStopstream.Enabled = false;
            this.btnStopstream.Location = new System.Drawing.Point(30, 197);
            this.btnStopstream.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStopstream.Name = "btnStopstream";
            this.btnStopstream.Size = new System.Drawing.Size(60, 37);
            this.btnStopstream.TabIndex = 13;
            this.btnStopstream.Text = "stopstream";
            this.btnStopstream.UseVisualStyleBackColor = true;
            this.btnStopstream.Click += new System.EventHandler(this.btnStopstream_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(30, 262);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(60, 32);
            this.btnDisconnect.TabIndex = 14;
            this.btnDisconnect.Text = "disconnetct";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refresh_timer_Tick);
            // 
            // displayControl1
            // 
            this.displayControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayControl1.BackColor = System.Drawing.Color.Transparent;
            this.displayControl1.BackgroundColor = System.Drawing.Color.DarkGray;
            this.displayControl1.Location = new System.Drawing.Point(513, 12);
            this.displayControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.displayControl1.Name = "displayControl1";
            this.displayControl1.ROI = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.displayControl1.Size = new System.Drawing.Size(331, 307);
            this.displayControl1.TabIndex = 15;
            this.displayControl1.TextOverlay = "";
            this.displayControl1.TextOverlayColor = System.Drawing.Color.Lime;
            this.displayControl1.TextOverlayOffsetX = 10;
            this.displayControl1.TextOverlayOffsetY = 10;
            this.displayControl1.TextOverlaySize = 18;
            // 
            // btnConnect1
            // 
            this.btnConnect1.Location = new System.Drawing.Point(448, 11);
            this.btnConnect1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConnect1.Name = "btnConnect1";
            this.btnConnect1.Size = new System.Drawing.Size(59, 33);
            this.btnConnect1.TabIndex = 16;
            this.btnConnect1.Text = "connect";
            this.btnConnect1.Click += new System.EventHandler(this.btnConnect1_Click);
            // 
            // btnStartstream1
            // 
            this.btnStartstream1.Enabled = false;
            this.btnStartstream1.Location = new System.Drawing.Point(448, 131);
            this.btnStartstream1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStartstream1.Name = "btnStartstream1";
            this.btnStartstream1.Size = new System.Drawing.Size(59, 34);
            this.btnStartstream1.TabIndex = 18;
            this.btnStartstream1.Text = "startstream";
            this.btnStartstream1.UseVisualStyleBackColor = true;
            this.btnStartstream1.Click += new System.EventHandler(this.btnStartstream1_Click);
            // 
            // btnStopstream1
            // 
            this.btnStopstream1.Enabled = false;
            this.btnStopstream1.Location = new System.Drawing.Point(448, 197);
            this.btnStopstream1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStopstream1.Name = "btnStopstream1";
            this.btnStopstream1.Size = new System.Drawing.Size(59, 37);
            this.btnStopstream1.TabIndex = 19;
            this.btnStopstream1.Text = "stopstream";
            this.btnStopstream1.UseVisualStyleBackColor = true;
            this.btnStopstream1.Click += new System.EventHandler(this.btnStopstream1_Click);
            // 
            // btnConfigure1
            // 
            this.btnConfigure1.Enabled = false;
            this.btnConfigure1.Location = new System.Drawing.Point(448, 70);
            this.btnConfigure1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnConfigure1.Name = "btnConfigure1";
            this.btnConfigure1.Size = new System.Drawing.Size(59, 38);
            this.btnConfigure1.TabIndex = 20;
            this.btnConfigure1.Text = "configure";
            this.btnConfigure1.UseVisualStyleBackColor = true;
            this.btnConfigure1.Click += new System.EventHandler(this.btnConfigure1_Click);
            // 
            // btnDisconnect1
            // 
            this.btnDisconnect1.Enabled = false;
            this.btnDisconnect1.Location = new System.Drawing.Point(448, 262);
            this.btnDisconnect1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDisconnect1.Name = "btnDisconnect1";
            this.btnDisconnect1.Size = new System.Drawing.Size(59, 32);
            this.btnDisconnect1.TabIndex = 21;
            this.btnDisconnect1.Text = "disconnetct";
            this.btnDisconnect1.UseVisualStyleBackColor = true;
            this.btnDisconnect1.Click += new System.EventHandler(this.btnDisconnect1_Click);
            // 
            // cap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 366);
            this.Controls.Add(this.btnDisconnect1);
            this.Controls.Add(this.btnConfigure1);
            this.Controls.Add(this.btnStopstream1);
            this.Controls.Add(this.btnStartstream1);
            this.Controls.Add(this.btnConnect1);
            this.Controls.Add(this.displayControl1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnStopstream);
            this.Controls.Add(this.btnStartstream);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.displayControl);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "cap";
            this.Text = "Cap";
            this.ResumeLayout(false);

        }

        #endregion

        private PvGUIDotNet.PvDisplayControl displayControl;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.Button btnStartstream;
        private System.Windows.Forms.Button btnStopstream;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Timer refreshTimer;
        private PvGUIDotNet.PvDisplayControl displayControl1;
        private System.Windows.Forms.Button btnConnect1;
        private System.Windows.Forms.Button btnStartstream1;
        private System.Windows.Forms.Button btnStopstream1;
        private System.Windows.Forms.Button btnConfigure1;
        private System.Windows.Forms.Button btnDisconnect1;
    }
}

