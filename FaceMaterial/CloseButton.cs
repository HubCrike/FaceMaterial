using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FaceMaterial {
    public class CloseButton : Control {

        private bool IsMouseEnter = false;

        private GraphicsPath LeftBlank;
        private GraphicsPath RightBlank;

        private Color? _HoverEffect;
        public Color? HoverEffect { get => _HoverEffect; set => _HoverEffect = value; }
        
        private int _CrossWidth;
        public int CrossWidth {
            get => _CrossWidth; set {
                if (_CrossWidth != value) {
                    _CrossWidth = value;
                    CalcSizes();
                    Invalidate();
                }
            }
        }

        public int HoverScaleOutWidth { get; set; }

        public CloseButton() {
            InitializeStyle();
            Size = new Size(24, 24);
            Padding = new Padding(4);
            CrossWidth = 3;
            HoverScaleOutWidth = 1;
            HoverEffect = Color.Transparent;
        }

        protected override void OnSizeChanged(EventArgs e) {
            CalcSizes();
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            if (IsMouseEnter && HoverEffect.HasValue &&  HoverEffect.Value != Color.Transparent)
                graphics.Clear(HoverEffect.Value);

            graphics.FillPath(new SolidBrush(ForeColor), LeftBlank);
            graphics.FillPath(new SolidBrush(ForeColor), RightBlank);

        }

        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            IsMouseEnter = true;
            CalcSizes();
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
            IsMouseEnter = false;
            CalcSizes();
            Invalidate();
        }


        protected override void OnPaddingChanged(EventArgs e) {
            base.OnPaddingChanged(e);
            CalcSizes();
            Invalidate();
        }
        private void InitializeStyle() {
            ControlStyles styles = ControlStyles.OptimizedDoubleBuffer
                               | ControlStyles.SupportsTransparentBackColor
                               | ControlStyles.UserPaint
                               | ControlStyles.ResizeRedraw;
            SetStyle(styles, true);
        }

        private void CalcSizes() {
            int cw = CrossWidth / 2;

            Padding padding = Padding;
            if (IsMouseEnter) {
                padding.All = Padding.All - HoverScaleOutWidth;
            }
            GraphicsPath leftBlank = new GraphicsPath();
            leftBlank.StartFigure();
            leftBlank.AddLine(padding.Left + cw, padding.Top, padding.Left, padding.Top + cw);
            leftBlank.AddLine(padding.Left, padding.Top + cw, Width - cw - padding.Right, Height - padding.Bottom);
            leftBlank.AddLine(Width - cw - padding.Right, Height - padding.Bottom, Width - padding.Right, Height - padding.Bottom - cw);
            leftBlank.CloseFigure();

            GraphicsPath rightBlank = new GraphicsPath();
            rightBlank.AddLine(padding.Left, Height - padding.Bottom - cw, padding.Left + cw, Height - padding.Bottom);
            rightBlank.AddLine(padding.Left + cw, Height - padding.Bottom, Width - padding.Right, padding.Top + cw);
            rightBlank.AddLine(Width - padding.Right, padding.Top + cw, Width - (padding.Right + cw), padding.Top);
            rightBlank.CloseFigure();

            LeftBlank = leftBlank;
            RightBlank = rightBlank;
        }
    }
}
