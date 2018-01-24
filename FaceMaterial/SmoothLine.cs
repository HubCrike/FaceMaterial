using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceMaterial {
    public class SmoothLine : Control {

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            int hHeight = Height / 2;

            Point p1 = new Point(0, hHeight);
            Point p2 = new Point(Width, hHeight);

            LinearGradientBrush linearGradient = new LinearGradientBrush(p1, p2, Parent.BackColor, ForeColor);

            ColorBlend cblend = new ColorBlend(3);
            cblend.Colors = new Color[3] { Parent.BackColor, ForeColor,  Parent.BackColor };
            cblend.Positions = new float[3] { 0f,   0.5f,  1f };

            linearGradient.InterpolationColors = cblend;

            graphics.FillRectangle(linearGradient, ClientRectangle);
        }
    }
}
