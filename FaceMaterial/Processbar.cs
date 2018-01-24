using System;
using System.Drawing;
using System.Windows.Forms;

namespace FaceMaterial.UI {
    public class Processbar : Control {

        #region Properties

        private double _MaxValue = 100;
        public double MaxValue {
            get => _MaxValue;
            set {
                if (MaxValue < Value)
                    _MaxValue = Value;
                else
                    _MaxValue = value;
                Invalidate();
            }
        }

        private double _MinValue = 0;
        public double MinValue {
            get => _MinValue;
            set  {
                if (MinValue > Value)
                    _MinValue = Value;
                else
                    _MinValue = value;
                Invalidate();
            }
        }

        private double _Value;
        public double Value {
            get => _Value;
            set {
                if (Value < MinValue)
                    throw new IndexOutOfRangeException();
                if (Value > MaxValue)
                    throw new IndexOutOfRangeException();
                _Value = value;
                Invalidate();
            }
        }

        private Color _ProcessColor;
        public Color ProcessColor {
            get => _ProcessColor;
            set {
                _ProcessColor = value;
                BrushProcess = new SolidBrush(value);
                Invalidate();
            }
        }

        private bool _ValueVisible;
        public bool ValueVisible {
            get => _ValueVisible;
            set {
                _ValueVisible = value;
                Invalidate();
            }
        }
        #endregion

        #region Settings
        private SolidBrush BrushProcess;
        #endregion

        public Processbar() {
            InitializeValues();
            InitializeStyle();
            InitializeEvents();
        }

        private void InitializeValues() {
            MaxValue = 100;
            MinValue = 0;
            Value = 20;
            ValueVisible = false;
        }

        private void InitializeStyle() {
            ControlStyles styles = ControlStyles.ResizeRedraw
                                 | ControlStyles.SupportsTransparentBackColor
                                 | ControlStyles.UserPaint;
            SetStyle(styles, true);
        }

        private void InitializeEvents() {
            Paint += Processbar_Paint;

            #region EventHelper
            void Processbar_Paint(object sender, PaintEventArgs e) {
                Graphics graphics = e.Graphics;
                Rectangle rect = Bounds;

                double val = MaxValue - MinValue;
                double step = rect.Width / val;

                double width = (Value - MinValue) * step;

                Point pointProcess = Point.Empty;
                Size sizeProcess = new Size((int) width, rect.Height);
                Rectangle rectProcess = new Rectangle(pointProcess, sizeProcess);

                if (BrushProcess == null)
                    return;

                graphics.FillRectangle(BrushProcess, rectProcess);
                if (ValueVisible) {
                    double textValue = 100 * Value / val;
                    string text = $"{Math.Round(textValue, 1)}%";

                    Size sizeText = TextRenderer.MeasureText(text, Font);
                    int textX = (Width - sizeText.Width) / 2;
                    int textY = (Height - sizeText.Height) / 2;
                    Point textLoc = new Point(textX, textY);

                    TextRenderer.DrawText(graphics, text, Font, textLoc, ForeColor);
                }
            }
            #endregion
        }
    }
}
