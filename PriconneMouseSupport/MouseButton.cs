using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriconneMouseSupport
{
    public partial class MouseButton : UserControl
    {
        public MouseButton()
        {
            InitializeComponent();
            var l = Util.GetFunctionsStrings();
            foreach (var item in l)
            {
                ComboBox.Items.Add(item);
            }
        }

        [Browsable(true)]
        public string LabelTitle
        {
            get
            {
                return _LabelTitle;
            }
            set
            {
                _LabelTitle = value;
                Label.Text = value;
            }
        }

        [Browsable(true)]
        public Functions Functions
        {
            get
            {
                return _Functions;
            }
            set
            {
                _Functions = value;
                ComboBox.SelectedIndex = (int)value;
            }
        }

        private string _LabelTitle;
        private Functions _Functions;
    }
}
