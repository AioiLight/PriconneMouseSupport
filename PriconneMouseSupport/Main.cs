using Gma.System.MouseKeyHook;
using System.Windows.Forms;

namespace PriconneMouseSupport
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            GlobalHook = Hook.GlobalEvents();

            GlobalHook.MouseClick += GlobalHook_MouseClick;
        }

        private void GlobalHook_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                MessageBox.Show("中");
            }
            else if (e.Button == MouseButtons.XButton1)
            {
                MessageBox.Show("後");
            }
            else if (e.Button == MouseButtons.XButton2)
            {
                MessageBox.Show("前");
            }
        }

        ~Main()
        {
            GlobalHook.MouseClick -= GlobalHook_MouseClick;
            GlobalHook?.Dispose();
        }

        private readonly IKeyboardMouseEvents GlobalHook;
    }
}
