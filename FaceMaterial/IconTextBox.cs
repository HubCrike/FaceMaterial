using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FaceMaterial.Patter;
using FaceMaterial.Subtems;

namespace FaceMaterial {

    partial class IconTextBox : UserControl, ICodeDesigner {

        IconDirection _IconDirection = IconDirection.Left;
        public IconDirection IconDirection {
            get => _IconDirection;
            set {
                if (_IconDirection == value)
                    return;

                IconBox.Dock = (DockStyle) value;
                _IconDirection = value;
            }
        }

        private Image _Icon;
        public Image Icon {
            get => _Icon;
            set {
                if (_Icon == value)
                    return;
                _Icon = value;
                IconBox.Image = value;
            }
        }

        private PictureBoxSizeMode _SizeMode;
        public PictureBoxSizeMode SizeMode {
            get => _SizeMode;
            set {
                if (_SizeMode == value)
                    return;
                _SizeMode = value;
                IconBox.SizeMode = value;
            }
        }

        public IconTextBox() {
            InitializeComponent();
            InitializeEvents();
            InitializeStyle();
            InitializeValues();
        }

        public void InitializeEvents() { }
        public void InitializeStyle() { }
        public void InitializeValues() {
            IconBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
