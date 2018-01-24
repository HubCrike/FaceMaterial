using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FaceMaterial.UI {
    public class ImageButton : PictureBox {
        [Category("Hover")]
        public Color HoverColor { get; set; }
        private Color tmpColor;
        [Category("Hover")]
        public bool IsHover {
            get => BackColor == HoverColor;
            set {
                if (value) {
                    OnEnter(EventArgs.Empty);
                } else {
                    OnLeave(EventArgs.Empty);
                }
            }
        }

        public ImageButton() {
            MouseEnter += CButton_MouseEnter;
            MouseLeave += CButton_MouseLeave;
        }

        private void CButton_MouseLeave(object sender, EventArgs e) => BackColor = tmpColor;
        private void CButton_MouseEnter(object sender, EventArgs e) {
            if (tmpColor == null) {
                tmpColor = BackColor;
            }
            BackColor = HoverColor;
        }
    }
}
