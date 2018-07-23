using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MiniDict
{
    class ComboBoxEx : ComboBox
    {
        public event EventHandler OnPasted;

        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        public ComboBoxEx()
        {
            IntPtr ehWnd = FindWindowEx(base.Handle, IntPtr.Zero, "Edit", "");
            SubClassHwnd sub = new SubClassHwnd();
            sub.AssignHandle(ehWnd);
            sub.SetComboBoxEx(this);
        }

        public class SubClassHwnd : System.Windows.Forms.NativeWindow
        {
            ComboBoxEx cbex = null;
            int WM_PASTE = 0x0302;

            public void SetComboBoxEx(ComboBoxEx cb)
            {
                cbex = cb;
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == WM_PASTE && cbex != null && cbex.OnPasted != null)
                {
                    cbex.OnPasted(this, null);
                }
            }
        }
    }
}
