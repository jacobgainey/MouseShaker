using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseShaker
{
    public class Win32Cursor
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point point);

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int x;
            public int y;
        }

        public static bool GetCursorPosition(ref Point p)
        {
            return Win32Cursor.GetCursorPos(ref p);
        }

        public static void MoveCursor(int x, Int32 y, IntPtr hWnd)
        {
            Win32Cursor.Point p = new Win32Cursor.Point
            {
                x = Convert.ToInt16(x),
                y = Convert.ToInt16(y)
            };

            Win32Cursor.ClientToScreen(hWnd, ref p);
            Win32Cursor.SetCursorPos(p.x, p.y);
        }
    }
}

