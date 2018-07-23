using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniDict
{
    public partial class Result : Form
    {
        const int WM_NCHITTEST = 0x0084;
        const int WM_MOUSEMOVE = 0x0200;
        MainForm mMainForm = null;

        public Result(MainForm mf)
        {
            mMainForm = mf;
            InitializeComponent();
            wbResult.ScriptErrorsSuppressed = true;
            wbResult.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbResult_DocumentCompleted);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        protected override void WndProc(ref Message m)
        {
            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>()
                {
                    {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
                    {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
                };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if (!handled)
                base.WndProc(ref m);
        }

        void wbResult_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Focus();
            HtmlElementCollection hec = wbResult.Document.Body.GetElementsByTagName("div");
            HtmlElement target = null;
            foreach (HtmlElement he in hec)
            {
                string attr = he.GetAttribute("className");
                if (attr == "img_area")
                {
                    he.Style = "display:none;";
                    he.InnerHtml = "";
                }
                else if (attr == "lf_area")
                {
                    target = he;
                }
                else if (attr == "df_div")
                {
                    break;
                }
            }

            if (target != null)
            {
                wbResult.Document.Body.InnerHtml = target.InnerHtml;
            }

            wbResult.Visible = true;
            mMainForm.Focus();
        }

        public void Go(string url)
        {
            wbResult.Visible = false;
            wbResult.Navigate(url);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Red;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = SystemColors.Window;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            tpClose.SetToolTip(lblClose, "关闭窗口");
        }
    }
}
