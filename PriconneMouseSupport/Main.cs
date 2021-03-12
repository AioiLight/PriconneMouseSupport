using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WindowsHook;

namespace PriconneMouseSupport
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            GlobalHook = Hook.GlobalEvents();

            GlobalHook.MouseDownExt += GlobalHook_MouseClick;

            PrincessConnectReDive = Priconne.GetPriconne();
        }

        private void GlobalHook_MouseClick(object sender, MouseEventExtArgs e)
        {
            var p = PrincessConnectReDive;
            if (e.Button == WindowsHook.MouseButtons.Middle)
            {
                ClickConnect(p, Priconne.GetPointFromFunctions(Middle.Functions));
            }
            else if (e.Button == WindowsHook.MouseButtons.XButton1)
            {
                ClickConnect(p, Priconne.GetPointFromFunctions(Back.Functions));
            }
            else if (e.Button == WindowsHook.MouseButtons.XButton2)
            {
                ClickConnect(p, Priconne.GetPointFromFunctions(Forward.Functions));
            }
        }

        private void ClickConnect(Process process, Point point)
        {
            var p = Priconne.CalcPosition(process, point);
            Debug.WriteLine(p);
            if (p.HasValue)
            {
                Windows.ClickAndBack(new Point(p.Value.X, p.Value.Y));
            }
        }

        ~Main()
        {
            GlobalHook.MouseDownExt -= GlobalHook_MouseClick;
            GlobalHook?.Dispose();
        }

        private readonly IKeyboardMouseEvents GlobalHook;
        private readonly Process PrincessConnectReDive;
    }
}
