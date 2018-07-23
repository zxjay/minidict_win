namespace MiniDict
{
    partial class MainForm
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
            this.btnGo = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpacity100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpacity80 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpacity60 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpacity40 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOpacity20 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAutoStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbWord = new MiniDict.ComboBoxEx();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGo.Location = new System.Drawing.Point(289, 0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(11, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAbout,
            this.toolColor,
            this.toolOpacity,
            this.toolAutoStart,
            this.toolStripSeparator1,
            this.toolExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 120);
            // 
            // toolAbout
            // 
            this.toolAbout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAbout.Name = "toolAbout";
            this.toolAbout.Size = new System.Drawing.Size(133, 22);
            this.toolAbout.Text = "关于...";
            this.toolAbout.Click += new System.EventHandler(this.toolAbout_Click);
            // 
            // toolColor
            // 
            this.toolColor.Name = "toolColor";
            this.toolColor.Size = new System.Drawing.Size(133, 22);
            this.toolColor.Text = "皮肤颜色...";
            this.toolColor.Click += new System.EventHandler(this.toolColor_Click);
            // 
            // toolOpacity
            // 
            this.toolOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpacity100,
            this.toolOpacity80,
            this.toolOpacity60,
            this.toolOpacity40,
            this.toolOpacity20});
            this.toolOpacity.Name = "toolOpacity";
            this.toolOpacity.Size = new System.Drawing.Size(133, 22);
            this.toolOpacity.Text = "透明度(%)";
            // 
            // toolOpacity100
            // 
            this.toolOpacity100.Checked = true;
            this.toolOpacity100.CheckOnClick = true;
            this.toolOpacity100.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolOpacity100.Name = "toolOpacity100";
            this.toolOpacity100.Size = new System.Drawing.Size(97, 22);
            this.toolOpacity100.Text = "100";
            this.toolOpacity100.Click += new System.EventHandler(this.toolOpacity_Click);
            // 
            // toolOpacity80
            // 
            this.toolOpacity80.CheckOnClick = true;
            this.toolOpacity80.Name = "toolOpacity80";
            this.toolOpacity80.Size = new System.Drawing.Size(97, 22);
            this.toolOpacity80.Text = "80";
            this.toolOpacity80.Click += new System.EventHandler(this.toolOpacity_Click);
            // 
            // toolOpacity60
            // 
            this.toolOpacity60.CheckOnClick = true;
            this.toolOpacity60.Name = "toolOpacity60";
            this.toolOpacity60.Size = new System.Drawing.Size(97, 22);
            this.toolOpacity60.Text = "60";
            this.toolOpacity60.Click += new System.EventHandler(this.toolOpacity_Click);
            // 
            // toolOpacity40
            // 
            this.toolOpacity40.CheckOnClick = true;
            this.toolOpacity40.Name = "toolOpacity40";
            this.toolOpacity40.Size = new System.Drawing.Size(97, 22);
            this.toolOpacity40.Text = "40";
            this.toolOpacity40.Click += new System.EventHandler(this.toolOpacity_Click);
            // 
            // toolOpacity20
            // 
            this.toolOpacity20.CheckOnClick = true;
            this.toolOpacity20.Name = "toolOpacity20";
            this.toolOpacity20.Size = new System.Drawing.Size(97, 22);
            this.toolOpacity20.Text = "20";
            this.toolOpacity20.Click += new System.EventHandler(this.toolOpacity_Click);
            // 
            // toolAutoStart
            // 
            this.toolAutoStart.Name = "toolAutoStart";
            this.toolAutoStart.Size = new System.Drawing.Size(133, 22);
            this.toolAutoStart.Text = "开机启动";
            this.toolAutoStart.Click += new System.EventHandler(this.toolAutoStart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(133, 22);
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.Color = System.Drawing.SystemColors.Control;
            this.colorDialog1.FullOpen = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbWord
            // 
            this.cmbWord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWord.FormattingEnabled = true;
            this.cmbWord.Location = new System.Drawing.Point(12, 0);
            this.cmbWord.Name = "cmbWord";
            this.cmbWord.Size = new System.Drawing.Size(277, 23);
            this.cmbWord.TabIndex = 0;
            this.cmbWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbWord_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 23);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.cmbWord);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 23);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxEx cmbWord;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolExit;
        private System.Windows.Forms.ToolStripMenuItem toolColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolOpacity;
        private System.Windows.Forms.ToolStripMenuItem toolOpacity100;
        private System.Windows.Forms.ToolStripMenuItem toolOpacity80;
        private System.Windows.Forms.ToolStripMenuItem toolOpacity60;
        private System.Windows.Forms.ToolStripMenuItem toolOpacity40;
        private System.Windows.Forms.ToolStripMenuItem toolOpacity20;
        private System.Windows.Forms.ToolStripMenuItem toolAbout;
        private System.Windows.Forms.ToolStripMenuItem toolAutoStart;
        private System.Windows.Forms.Timer timer1;

    }
}