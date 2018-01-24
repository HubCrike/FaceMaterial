using FaceMaterial.Patter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace FaceMaterial.Subtems {
    [Serializable]
    public class MultiCircleBarItem : ValueManger {
        public event ValueChangeEventHandle<Color> BarColorChanged;

        private Color _BarColor;
        public Color BarColor {
            get => _BarColor;
            set {
                if (BarColor == value)
                    return;
                _BarColor = value;
                BarColorChanged?.Invoke(value);
            }
        }

        public double GetPercent() {
            if (MinValue == null || MaxValue == null)
                return 0;
            double userValue = Value - MinValue.Value;
            double percentVal = (100 * userValue) / (MaxValue.Value - MinValue.Value);
            return percentVal;
        }
    }
}
