using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Microsoft.Win32;


namespace MiniDict
{
    public partial class MainForm : Form
    {
        private Result resultForm = null;
        List<string> dict = new List<string>();

        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("User32.DLL")]
        public static extern bool ReleaseCapture();

        public const uint WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 61456;
        public const int HTCAPTION = 2;
        public const uint WM_MOVING = 0x0216;

        public MainForm()
        {
            InitializeComponent();
            this.Move += new EventHandler(MainForm_Move);
            this.MouseDown += new MouseEventHandler(MainForm_MouseDown);

            cmbWord.MouseEnter += new EventHandler(cmbWord_MouseEnter);
            cmbWord.SelectedIndexChanged += new EventHandler(cmbWord_SelectedIndexChanged);
            cmbWord.OnPasted += new EventHandler(cmbWord_OnPasted);

            Screen s = Screen.FromControl(this);
            this.Left = s.WorkingArea.Width + s.WorkingArea.X - this.Width;
            this.Top = s.WorkingArea.Y + 25;

            resultForm = new Result(this);
        }

        void cmbWord_OnPasted(object sender, EventArgs e)
        {
            btnGo_Click(sender, e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOVING)
            {
                Rectangle rect = Screen.FromControl(this).WorkingArea;
                int left = Marshal.ReadInt32(m.LParam, 0);
                int top = Marshal.ReadInt32(m.LParam, 4);
                int right = Marshal.ReadInt32(m.LParam, 8);
                int bottom = Marshal.ReadInt32(m.LParam, 12);

                if (bottom + resultForm.Height > rect.Height + rect.Y)
                {
                    resultForm.Top = top - resultForm.Height;
                }
                else
                {
                    resultForm.Top = bottom;
                }

                resultForm.Left = left;

                if (bottom > rect.Height + rect.Y)
                {
                    top = rect.Height + rect.Y - this.Height;
                }

                if (top < rect.Y)
                {
                    top = rect.Y;
                }

                if (left < rect.X)
                {
                    left = rect.X;
                }

                if (left > rect.Width + rect.X - 10)
                {
                    left = rect.Width + rect.X - 10;
                }

                Marshal.WriteInt32(m.LParam, 0, left);
                Marshal.WriteInt32(m.LParam, 4, top);
                Marshal.WriteInt32(m.LParam, 8, left + this.Width);
                Marshal.WriteInt32(m.LParam, 12, top + this.Height);
            }

            base.WndProc(ref m);
        }

        void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            resultForm.Activate();
            cmbWord.Focus();

            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
        }

        void MainForm_Move(object sender, EventArgs e)
        {
            Rectangle rect = Screen.FromControl(this).WorkingArea;

            //粘贴在边上
            if (Math.Abs((this.Left + this.Width) - (rect.X + rect.Width)) < 10)
            {
                this.Left = rect.X + rect.Width - this.Width;
            }
        }

        void cmbWord_MouseEnter(object sender, EventArgs e)
        {
            cmbWord.SelectAll();
            cmbWord.Focus();
        }

        void cmbWord_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGo_Click(null, null);
        }

        private void cmbWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                btnGo_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                resultForm.Hide();
                e.SuppressKeyPress = true;
            }
        }

        void toolColor_Click(object sender, System.EventArgs e)
        {
            colorDialog1.Color = this.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                this.btnGo.ForeColor = colorDialog1.Color;

                RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\MiniDict");
                if (null != regKey)
                {
                    regKey.SetValue("Color", colorDialog1.Color.ToArgb());

                    regKey.Close();
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string txt = cmbWord.Text.Trim();

            if (txt.Length > 0)
            {
                if (!dict.Contains(txt))
                {
                    dict.Add(txt);

                    cmbWord.Items.Clear();

                    foreach (var s in dict)
                    {
                        cmbWord.Items.Add(s);
                    }
                }

                String queryUrl = String.Format("https://www.bing.com/dict/search?q={0}&FORM=BDVSP6&cc=cn", HttpUtility.UrlEncode(txt, Encoding.UTF8));
                resultForm.Go(queryUrl);

                resultForm.Left = this.Left;
                resultForm.Top = this.Top + this.Height;
                resultForm.Width = this.Width;
                resultForm.Height = 400;
                resultForm.Show();
                cmbWord.Select(cmbWord.Text.Length, 0);
            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolOpacity_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem i in toolOpacity.DropDownItems)
            {
                i.Checked = false;
            }

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                int opct = int.Parse(item.Text);
                double opacity = opct / 100.0;

                this.Opacity = opacity;
                resultForm.Opacity = opacity;

                item.Checked = true;

                RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\MiniDict");
                if (null != regKey)
                {
                    regKey.SetValue("Opacity", opct);

                    regKey.Close();
                }
            }
        }

        void toolAutoStart_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                if (item.Checked)
                {
                    item.Checked = false;
                    RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                    if (null != regKey)
                    {
                        if (null != regKey.GetValue("MiniDict"))
                        {
                            regKey.DeleteValue("MiniDict");
                        }

                        regKey.Close();
                    }
                }
                else
                {
                    item.Checked = true;
                    RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                    if (null != regKey)
                    {
                        string path = Application.ExecutablePath;
                        regKey.SetValue("MiniDict", "\"" + path + "\"");

                        regKey.Close();
                    }
                }
            }
        }

        private void toolAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright © 2018年 zxjay@github. All rights reserved. MiniDict微型英文查单词工具，词典来自dict.bing.com。", 
                "关于 MiniDict 1.1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int opct = 100;
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\MiniDict");
            if (null != regKey)
            {
                object color = regKey.GetValue("Color");
                if (null != color)
                {
                    int clr = (int)color;
                    this.BackColor = Color.FromArgb(clr);
                    this.btnGo.ForeColor = this.BackColor;
                }

                object opcity = regKey.GetValue("Opacity");
                if (null != opcity)
                {
                    opct = (int)opcity;
                }

                regKey.Close();
            }

            foreach (ToolStripMenuItem i in toolOpacity.DropDownItems)
            {
                string strOpct = opct.ToString();
                if (i.Text == strOpct)
                {
                    i.Checked = true;

                    double opacity = opct / 100.0;
                    this.Opacity = opacity;
                    resultForm.Opacity = opacity;
                }
                else
                {
                    i.Checked = false;
                }
            }

            RegistryKey regKeyRun = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
            if (null != regKeyRun)
            {
                string path = Application.ExecutablePath;
                string orig = ((string)regKeyRun.GetValue("MiniDict", "")).Trim('\"');
                toolAutoStart.Checked = string.Compare(path, orig, true) == 0;

                regKeyRun.Close();
            }

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
