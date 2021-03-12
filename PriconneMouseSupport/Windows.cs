using System.Drawing;
using System.Runtime.InteropServices;
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
            var currentPosition = Cursor.Position;
            SetMousePosition(position);
            PressMouseLeft();
            SetMousePosition(currentPosition);
        }
    }
}
