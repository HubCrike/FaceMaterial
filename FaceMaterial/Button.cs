using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceMaterial.UI {
    public class Button : System.Windows.Forms.Button {

        protected override void OnPaint(PaintEventArgs pevent) {
            Graphics graphics = pevent.Graphics;

            graphics.Clear(BackColor);
            Size textSize = TextRenderer.MeasureText(Text, Font);
            switch (TextAlign) {
                case ContentAlignment.TopLeft:
                    TextRenderer.DrawText(graphics, Text, Font, Point.Empty, ForeColor);
                    break;
                case ContentAlignment.TopCenter:
                    TextRenderer.DrawText(graphics, Text, Font, new Point((Width - textSize.Width) / 2,0), ForeColor);
                    break;
                case ContentAlignment.TopRight:
                    TextRenderer.DrawText(graphics, Text, Font, new Point(Width - textSize.Width, 0), ForeColor);
                    break;
                case ContentAlignment.MiddleLeft:
                    TextRenderer.DrawText(graphics, Text, Font, new Point(0, (Height - textSize.Height) /2), ForeColor);
                    break;
                case ContentAlignment.MiddleCenter:
                    TextRenderer.DrawText(graphics, Text, Font, new Point((Width - textSize.Width) / 2, (Height - textSize.Height) / 2), ForeColor);
                    break;
                case ContentAlignment.MiddleRight:
                    TextRenderer.DrawText(graphics, Text, Font, new Point(Width - textSize.Width, (Height - textSize.Height) / 2), ForeColor);
                    break;
                case ContentAlignment.BottomLeft:
                    TextRenderer.DrawText(graphics, Text, Font, new Point(0, Height - textSize.Height), ForeColor);
                    break;
                case ContentAlignment.BottomCenter:
                    TextRenderer.DrawText(graphics, Text, Font, new Point((Width - textSize.Width) / 2, Height - textSize.Height), ForeColor);
                    break;
                case ContentAlignment.BottomRight:
                    TextRenderer.DrawText(graphics, Text, Font, new Point(Width - textSize.Width, Height - textSize.Height), ForeColor);
                    break;
            }
        }
    }
}
