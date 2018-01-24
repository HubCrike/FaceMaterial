using FaceMaterial.Patter;
using FaceMaterial.Subtems;

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace FaceMaterial.UI {
    class MultiCircleBar : Control, ICodeDesigner, IPropertyUpdater {
        public delegate void ValueChangeEventHandle(double value);
        public delegate void PropertyChangedEventHandler();
        #region events

        #region public
        public event ValueChangeEventHandle ValueChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region private

        #endregion

        #endregion

        #region Properties

        #region Settings
        private double _MinValue = 0;
        private double _MaxValue = 100;
        private int _OpenPiValue = 0;
        private Direction _OpenPiDirection = Direction.Top;
        private int _BarWidth = 10;
        private Color _BarValueColor = Color.DodgerBlue;
        private Color _BarBackColor = Color.FromArgb(36, 36, 36);
        private Color _ForeColor = Color.White;
        private Color _BackColor = Color.FromArgb(64, 64, 64);
        private List<MultiCircleBarItem> _Items = new List<MultiCircleBarItem>();

        #endregion

        public double MinValue {
            get => _MinValue;
            set {
                if (MinValue == value)
                    return;
                PropertyUpdate(ref _MinValue, value, () => {
                    if (MinValue > MaxValue)
                        MinValue = MaxValue - 1;
                });
            }
        }
        public double MaxValue {
            get => _MaxValue;
            set {
                if (MinValue == value)
                    return;
                PropertyUpdate(ref _MaxValue, value, () => {
                    _MaxValue = value;
                    if (MaxValue < MinValue)
                        MaxValue = MinValue + 1;
                });
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<MultiCircleBarItem> Items {
            get => _Items;
            set {
                if (_Items == value)
                    return;
                _Items = value;
                //_Items.ForEach(x =>     
            }
        }

        public int OpenPiValue {
            get => _OpenPiValue;
            set {
                if (OpenPiValue == value)
                    return;
                PropertyUpdate(action, ref _OpenPiValue, value);

                void action() {
                    if (value > 360)
                        throw new Exception("Value must be smaler then 360");
                    if (value < 0)
                        throw new Exception("Value must be bigger then 0");
                }
            }
        }
        public Direction OpenPiDirection {
            get => _OpenPiDirection;
            set {
                if (OpenPiDirection == value)
                    return;
                PropertyUpdate(ref _OpenPiDirection, value);
            }
        }
        public int BarWidth {
            get => _BarWidth;
            set {
                if (BarWidth == value)
                    return;
                PropertyUpdate(ref _BarWidth, value);
            }
        }
        public Color BarBackColor {
            get => _BarBackColor;
            set {
                if (BarBackColor == value)
                    return;
                PropertyUpdate(ref _BarBackColor, value, () => BrushOuterPi = new SolidBrush(BarBackColor));
            }
        }
        public new Color BackColor {
            get => _BackColor;
            set {
                if (_BackColor == value)
                    return;
                PropertyUpdate(ref _BackColor, value, () => BrushInnaPi = new SolidBrush(value));
            }
        }

        #region HiddenProperties
        #endregion
        #endregion

        #region Settings
        private GraphicsPath PathInnaPi;
        private GraphicsPath PathOuterPi;

        private SolidBrush BrushInnaPi = new SolidBrush(Color.FromArgb(36, 36, 36));
        private SolidBrush BrushOuterPi = new SolidBrush(Color.FromArgb(64, 64, 64));
        private SolidBrush BrushValuePi = new SolidBrush(Color.DodgerBlue);

        private Point TextLocation;
        private String PercentText;

        private List<MultCircleBarItemPath> PathOfPis = new List<MultCircleBarItemPath>();
        #endregion


        public MultiCircleBar() {
            InitializeStyle();
            InitializeEvents();
            InitializeValues();
        }

        public void InitializeStyle() {
            ControlStyles styles = ControlStyles.OptimizedDoubleBuffer
                               | ControlStyles.SupportsTransparentBackColor
                               | ControlStyles.UserPaint
                               | ControlStyles.ResizeRedraw;
            SetStyle(styles, true);
        }

        public void InitializeEvents() {
            Resize += CircleBar_Resize;
            Paint += CircleBar_Paint;
            PropertyChanged += CircleBar_PropertyChanged;

            void CircleBar_Resize(object sender, EventArgs e) {
                if (Height != Width)
                    Height = Width; 
                ReCalcPis();
            }

            void CircleBar_Paint(object sender, PaintEventArgs e) {
                Graphics graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;


                if (PathOuterPi != null)
                    graphics.FillPath(BrushOuterPi, PathOuterPi);


                foreach (MultCircleBarItemPath item in PathOfPis)
                    graphics.FillPath(item.BarColor, item.Path);

                if (PathInnaPi != null)
                    graphics.FillPath(BrushInnaPi, PathInnaPi);

            }

            void CircleBar_ValueChanged(double value) {
                Invalidate();
            }

            void CircleBar_PropertyChanged() {
                ReCalcPis();
                Invalidate();
            }

            void ReCalcPis() {
                Rectangle rect = new Rectangle(Point.Empty, Size);
                if (rect.IsEmpty)
                    return;

                #region Settings
                int directValue = (int) OpenPiDirection;
                int halfOpenPiValue = (OpenPiValue / 2);

                int startValue = directValue - halfOpenPiValue;
                double movedValue = 0;

                double realDegValue = 360 - OpenPiValue;

               IEnumerable<MultCircleBarItemSpetz> items = Items.Select(item => {
                    int value = 0;
                   bool k = item.Value == 0;
                   bool l = item.MaxValue == null && item.MinValue == null;

                   Plugin.SwitchCase.Cased<MultiCircleBarItem>(
                       k, l, true,
                       x => value = 0,
                       x => value = (int) (realDegValue / x.Value),
                       x => {
                           double readItemDegValue = x.MaxValue.Value - x.MinValue.Value;
                           value = (int) (realDegValue / x.Value);
                       })(item);
                    return new MultCircleBarItemSpetz(value, item.BarColor);
                });

                items = (from item in items
                         orderby item.Value
                         select item);

                #endregion

                int endValue = -(360 - OpenPiValue) + (int) movedValue;

                #region OuterPi
                GraphicsPath outerPiPath = new GraphicsPath();
                outerPiPath.AddPie(rect, startValue, endValue);
                outerPiPath.CloseFigure();
                PathOuterPi = outerPiPath;
                #endregion

                #region InnaPi
                int rectInnaPiW = rect.Width - (2 * BarWidth);
                int rectInnaPiH = rect.Height - (2 * BarWidth);

                int rectInnaPiLocVal = rect.Height - rectInnaPiH;
                int rectInnaPiX = rect.Location.X + (rectInnaPiLocVal / 2);
                int rectInnaPiY = rect.Location.Y + (rectInnaPiLocVal / 2);

                Point pointInnaPiLoc = new Point(rectInnaPiX, rectInnaPiY);
                Size sizeInnaPi = new Size(rectInnaPiW, rectInnaPiH);
                Rectangle rectInnaPi = new Rectangle(pointInnaPiLoc, sizeInnaPi);

                GraphicsPath innaPiPath = new GraphicsPath();
                innaPiPath.AddPie(rectInnaPi, 0, 360);
                innaPiPath.CloseFigure();
                PathInnaPi = innaPiPath;
                #endregion
            }
        }

        public void InitializeValues() {

        }

        [Browsable(false)]
        public void PropertyUpdate<T>(ref T field, T value) {
            field = value;
            PropertyChanged();
        }

        [Browsable(false)]
        public void PropertyUpdate<T>(ref T field, T value, Action action) {
            field = value;
            action();
            PropertyChanged();
        }

        public void PropertyUpdate<T>(Action action, ref T field, T value) {
            action();
            field = value;
            PropertyChanged();
        }

        private struct MultCircleBarItemSpetz {
            public int Value { get; }
            public SolidBrush BarColor { get; }

            public MultCircleBarItemSpetz(int value, Color barColor) {
                Value = value;
                BarColor = new SolidBrush(barColor);
            }
        }

        private struct MultCircleBarItemPath {
            public GraphicsPath Path { get; }
            public SolidBrush BarColor { get; }

            public MultCircleBarItemPath(GraphicsPath path, SolidBrush barColor) {
                Path = path;
                BarColor = barColor;
            }
        }
    }
}
