using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriconneMouseSupport
{
    internal static class Windows
    {
        [DllImport("USER32.dll", CallingConvention = CallingConvention.StdCall)]
#pragma warning disable IDE1006 // 命名スタイル
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
#pragma warning restore IDE1006 // 命名スタイル

        internal static void SetMousePosition(Point position)
        {
            Cursor.Position = position;
        }

        internal static void PressMouseLeft()
        {
            var leftDown = 0x2;
            var leftUp = 0x4;
            mouse_event(leftDown, 0, 0, 0, 0);
            mouse_event(leftUp, 0, 0, 0, 0);
        }

        internal static void ClickAndBack(Point position)
        {
            Task.Run(async () =>
            {
                var currentPosition = Cursor.Position;
                SetMousePosition(position);
                PressMouseLeft();
                // 60fps 換算で 3 フレーム待つ
                await Task.Delay(50);
                SetMousePosition(currentPosition);
            });
        }

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        internal static Size? GetWindowClientSize(Process process)
        {
            var b = GetClientRect(process.MainWindowHandle, out var rect);

            return b ? new(rect.right, rect.bottom) : null;
        }

        internal static Point? GetScreenPosition(Process process, Point point)
        {
            var b = ClientToScreen(process.MainWindowHandle, ref point);

            return b ? point : null;
        }

        internal static Process GetWindowProcessFromString(string title)
        {
            var p = Process.GetProcesses();
            return p.FirstOrDefault(n => n.MainWindowTitle == title);
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        internal static bool IsActiveWindow(Process process)
        {
            var g = GetForegroundWindow();
            return g == process.MainWindowHandle;
        }
    }
}
