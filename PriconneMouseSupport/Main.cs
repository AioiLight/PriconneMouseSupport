using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
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

            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            SettingsPath = Path.Combine(baseDir, @"Settings.json");
            if (File.Exists(SettingsPath))
            {
                // 設定反映
                var s = JsonSerializer.Deserialize<Settings>(File.ReadAllText(SettingsPath, Encoding.UTF8));
                Middle.Functions = s.Middle;
                Forward.Functions = s.Forward;
                Back.Functions = s.Back;
                CheckBox_Active.Checked = s.Active;
            }
        }

        ~Main()
        {
            GlobalHook.MouseDownExt -= GlobalHook_MouseClick;
            GlobalHook?.Dispose();
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

        private void Button_Save_Click(object sender, EventArgs e)
        {
            var s = new Settings()
            {
                Middle = Middle.Functions,
                Forward = Forward.Functions,
                Back = Back.Functions,
                Active= CheckBox_Active.Checked
            };

            var json = JsonSerializer.Serialize(s);
            File.WriteAllText(SettingsPath, json);

            TaskDialog.ShowDialog(this,
                new TaskDialogPage()
                {
                    Text = Properties.Resources.Saved,
                }, TaskDialogStartupLocation.CenterOwner);
        }

        private void ClickConnect(Process process, Point point)
        {
            if (process == null)
            {
                TaskDialog.ShowDialog(this,
                new TaskDialogPage()
                {
                    Text = Properties.Resources._404,
                    Icon = TaskDialogIcon.Error,
                }, TaskDialogStartupLocation.CenterOwner);
                return;
            }

            if (CheckBox_Active.Checked)
            {
                if (!Windows.IsActiveWindow(process))
                {
                    return;
                }
            }

            var p = Priconne.CalcPosition(process, point);
            Debug.WriteLine(p);
            if (p.HasValue)
            {
                Windows.ClickAndBack(new Point(p.Value.X, p.Value.Y));
            }
        }

        private readonly IKeyboardMouseEvents GlobalHook;
        private readonly Process PrincessConnectReDive;
        private readonly string SettingsPath;
    }
}
