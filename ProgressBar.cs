using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Judoplaner2
{
    public partial class ProgressBar : UserControl
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set {
                _value = value;
                panel.Width = (int)(this.Width * _value / 100.0);
            }
        }
    }
}
