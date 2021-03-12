using System;
using System.Diagnostics;
using System.Drawing;

namespace PriconneMouseSupport
{
    internal static class Priconne
    {
        internal static Point Menu = new(1200, 36);
        internal static Point Back = new(45, 45);
        internal static Point Auto = new(1218, 568);
        internal static Point Speed = new(1218, 664);

        internal static Size WindowSize = new(1280, 720);

        internal static string Title = "PrincessConnectReDive";

        internal static Point GetPointFromFunctions(Functions functions)
        {
            return functions switch
            {
                Functions.Menu => Menu,
                Functions.Back => Back,
                Functions.Auto => Auto,
                Functions.Speed => Speed,
                _ => Back
            };
        }

        internal static Process GetPriconne()
        {
            return Windows.GetWindowProcessFromString(Title);
        }

        internal static Point? CalcPosition(Process priconne, Point point)
        {
            var priconneWindow = Windows.GetWindowClientSize(priconne);

            Debug.WriteLine(priconneWindow);

            if (priconneWindow.HasValue)
            {
                var widthRate = 1.0 * priconneWindow.Value.Width / WindowSize.Width;
                var heightRate = 1.0 * priconneWindow.Value.Height / WindowSize.Height;

                var x = point.X * widthRate;
                var y = point.Y * heightRate;

                return Windows.GetScreenPosition(priconne, new Point((int)x, (int)y));
            }
            else
            {
                return null;
            }
        }
    }
}
