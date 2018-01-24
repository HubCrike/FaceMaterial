using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FaceMaterial.Patter {

    namespace FormManager {
        public class DragAndDropControl {

            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

            [DllImport("user32.dll")]
            public static extern bool ReleaseCapture();

            public const int WM_NCLBUTTONDOWN = 0xA1;
            public const int HTCAPTION = 0x2;

            private Control Control;
            private Form Ctx;
            public DragAndDropControl(Form content, Control control) {
                Control = control;
                Ctx = content;
                Control.MouseMove += C_MouseDown;
            }

            private void C_MouseDown(object sender, MouseEventArgs e) {
                if (e.Button == MouseButtons.Left) {
                    ReleaseCapture();
                    SendMessage(Ctx.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
                string[] bla = new string[4];
            }
        }
    }
}
