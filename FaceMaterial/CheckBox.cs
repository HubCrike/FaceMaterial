using FaceMaterial.Patter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceMaterial.UI {

    class CheckBox : Control, INotifyPropertyChanged {

        public event Action<CheckBox, bool> CheckstateSwitch;
        public event Action<CheckBox> Checked;
        public event Action<CheckBox> UnChecked;
        
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        private CheckBoxStyle _CheckBoxStyle;
        public CheckBoxStyle CheckBoxStyle {
            get => _CheckBoxStyle; set {
                value.PropertyChanged += (sender, e) => PropertyChanged.Invoke(this, e);
                SetPropertyField(ref _CheckBoxStyle, value);
            }
        }

        private HorizontalAlignment _TextAlignment;
        public HorizontalAlignment TextAlignment { get => _TextAlignment; set => SetPropertyField(ref _TextAlignment, value); }

        private CheckBoxDirection _CheckBoxDirection;
        public CheckBoxDirection CheckBoxDirection { get => _CheckBoxDirection; set => SetPropertyField(ref _CheckBoxDirection, value); }

        private int _BTPadding;
        public int BTPadding { get => _BTPadding; set => SetPropertyField(ref _BTPadding, value); }

        #endregion

        private void InitializeStyle() {
            ControlStyles styles = ControlStyles.ResizeRedraw
                                 | ControlStyles.SupportsTransparentBackColor;
            SetStyle(styles, true);
        }

        private void InitializeEvents() {

        }

        private void InitializeValues() {

        }

        protected override void OnPaint(PaintEventArgs e) {
            ////base.OnPaint(e);
            //Graphics graphics = e.Graphics;
            ////graphics.SmoothingMode = SmoothingMode.AntiAlias;
            ////graphics.CompositingQuality = CompositingQuality.HighQuality;
            ////graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            ////graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            //Pen borderPen = new Pen(CheckBoxStyle.BoarderColor);
            //Pen innaPen = new Pen(CheckBoxStyle.BackgroudColor);

            //graphics.DrawPath(borderPen, CheckBoxStyle.BorderRecangel);
            //graphics.DrawPath(innaPen, CheckBoxStyle.CheckRecangel);

            ////int textY = CheckBoxStyle.Size.Width +
            //switch (TextAlignment) {
            //    case HorizontalAlignment.Left:

            //        break;
            //    case HorizontalAlignment.Center:

            //        break;
            //    case HorizontalAlignment.Right:

            //        break;
            //}
        }

        protected void SetPropertyField<T>(ref T field, T newValue, [CallerMemberName] string member = "") {
            if (!EqualityComparer<T>.Default.Equals(field, newValue)) {
                field = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(member));
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) => Invalidate();
    }


    [Serializable]
    public class CheckBoxStyle : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public Color _BackgroudColor;
        public Color BackgroudColor { get => _BackgroudColor; set => SetPropertyField(ref _BackgroudColor, value); }

        public Color _BoarderColor;
        public Color BoarderColor { get => _BoarderColor; set => SetPropertyField(ref _BoarderColor, value); }

        public Size _Size;
        public Size Size { get => _Size; set  {

                int dBoarder = (2 * BoarderWidth);

                Size boarder = value;
                Size inna = new Size(value.Width - dBoarder, value.Height - dBoarder);

                GraphicsPath graphicsBorder = new GraphicsPath();
                graphicsBorder.StartFigure();
                graphicsBorder.AddRectangle(new Rectangle(Point.Empty, boarder));
                graphicsBorder.CloseFigure();

                GraphicsPath graphicsInna = new GraphicsPath();
                graphicsBorder.StartFigure();
                graphicsBorder.AddRectangle(new Rectangle(new Point(BoarderWidth), inna));
                graphicsBorder.CloseFigure();

                BorderRecangel = graphicsBorder;
                CheckRecangel = graphicsInna;

                SetPropertyField(ref _Size, value);
            }
        }
        public int _BoarderWidth;
        public int BoarderWidth { get => _BoarderWidth; set => SetPropertyField(ref _BoarderWidth, value); }

        public GraphicsPath BorderRecangel { get; private set; }
        public GraphicsPath CheckRecangel { get; private set; }

        protected void SetPropertyField<T>(ref T field, T newValue, [CallerMemberName] string member = "") {
            if (!EqualityComparer<T>.Default.Equals(field, newValue)) {
                field = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(member));
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);
    }
}
