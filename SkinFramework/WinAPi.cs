// This file is part of CoderLine SkinFramework.
//
// CoderLine SkinFramework is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// CoderLine SkinFramework is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with CoderLine SkinFramework.  If not, see <http://www.gnu.org/licenses/>.
//
// (C) 2010 Daniel Kuschny, (http://www.coderline.net)
/*
 * The Enumerations in this File are stripped down to the values needed in this lib
 */

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SkinFramework
{
    /// <summary>
    ///     This class contains some win32 functions needed for nc drawing
    /// </summary>
    internal static class Win32Api
    {
        #region Shell32.dll

        [DllImport("Shell32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SHAppBarMessage(int dwMessage, IntPtr pData);

        #endregion

        #region User32.dll

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate,
            IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, GWLIndex nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, GWLIndex nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy,
            uint uFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, DCXFlags flags);

        #endregion

        #region Gdi32.dll

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("gdi32.dll")]
        public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2,
            int cx, int cy);

        #endregion
    }

    #region Enums

    public enum ABMsg
    {
        ABM_NEW = 0,
        ABM_REMOVE = 1,
        ABM_QUERYPOS = 2,
        ABM_SETPOS = 3,
        ABM_GETSTATE = 4,
        ABM_GETTASKBARPOS = 5,
        ABM_ACTIVATE = 6,
        ABM_GETAUTOHIDEBAR = 7,
        ABM_SETAUTOHIDEBAR = 8,
        ABM_WINDOWPOSCHANGED = 9,
        ABM_SETSTATE = 10
    }

    public enum ABEdge
    {
        ABE_LEFT = 0,
        ABE_TOP = 1,
        ABE_RIGHT = 2,
        ABE_BOTTOM = 3
    }


    public enum WindowStyles : uint
    {
        WS_CAPTION = 0x00C00000,
        WS_BORDER = 0x00800000
    }
    //[Flags]
    //public enum DCXFlags : long
    //{
    //    DCXWindow = 0x00000001L,
    //    DCXCache = 0x00000002L,
    //    DCXClipsiblings = 0x00000010L,
    //}

    /// <summary>Values to pass to the GetDCEx method.</summary>
    [Flags]
    public enum DCXFlags : uint
    {
        /// <summary>
        ///     DCX_WINDOW: Returns a DC that corresponds to the window rectangle rather
        ///     than the client rectangle.
        /// </summary>
        Window = 0x00000001,

        /// <summary>
        ///     DCX_CACHE: Returns a DC from the cache, rather than the OWNDC or CLASSDC
        ///     window. Essentially overrides CS_OWNDC and CS_CLASSDC.
        /// </summary>
        Cache = 0x00000002,

        /// <summary>
        ///     DCX_NORESETATTRS: Does not reset the attributes of this DC to the
        ///     default attributes when this DC is released.
        /// </summary>
        NoResetAttrs = 0x00000004,

        /// <summary>
        ///     DCX_CLIPCHILDREN: Excludes the visible regions of all child windows
        ///     below the window identified by hWnd.
        /// </summary>
        ClipChildren = 0x00000008,

        /// <summary>
        ///     DCX_CLIPSIBLINGS: Excludes the visible regions of all sibling windows
        ///     above the window identified by hWnd.
        /// </summary>
        ClipSiblings = 0x00000010,

        /// <summary>
        ///     DCX_PARENTCLIP: Uses the visible region of the parent window. The
        ///     parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored. The origin is
        ///     set to the upper-left corner of the window identified by hWnd.
        /// </summary>
        ParentClip = 0x00000020,

        /// <summary>
        ///     DCX_EXCLUDERGN: The clipping region identified by hrgnClip is excluded
        ///     from the visible region of the returned DC.
        /// </summary>
        ExcludeRgn = 0x00000040,

        /// <summary>
        ///     DCX_INTERSECTRGN: The clipping region identified by hrgnClip is
        ///     intersected with the visible region of the returned DC.
        /// </summary>
        IntersectRgn = 0x00000080,

        /// <summary>DCX_EXCLUDEUPDATE: Unknown...Undocumented</summary>
        ExcludeUpdate = 0x00000100,

        /// <summary>DCX_INTERSECTUPDATE: Unknown...Undocumented</summary>
        IntersectUpdate = 0x00000200,

        /// <summary>
        ///     DCX_LOCKWINDOWUPDATE: Allows drawing even if there is a LockWindowUpdate
        ///     call in effect that would otherwise exclude this window. Used for drawing during
        ///     tracking.
        /// </summary>
        LockWindowUpdate = 0x00000400,

        /// <summary>DCX_USESTYLE: Undocumented, something related to WM_NCPAINT message.</summary>
        UseStyle = 0x00010000,

        /// <summary>
        ///     DCX_VALIDATE When specified with DCX_INTERSECTUPDATE, causes the DC to
        ///     be completely validated. Using this function with both DCX_INTERSECTUPDATE and
        ///     DCX_VALIDATE is identical to using the BeginPaint function.
        /// </summary>
        Validate = 0x00200000
    }


    public enum HitTest
    {
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTSYSMENU = 3,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTCLOSE = 20,
        HTHELP = 21
    }

    public enum RedrawWindowFlags
    {
        RDW_INVALIDATE = 0x0001,
        RDW_ALLCHILDREN = 0x0080,
        RDW_UPDATENOW = 0x0100,
        RDW_ERASENOW = 0x0200,
        RDW_FRAME = 0x0400
    }

    public enum WAFlags
    {
        WA_ACTIVE = 1,
        WA_CLICKACTIVE = 2
    }

    public enum GWLIndex
    {
        GWL_STYLE = -16
    }

    [Flags]
    public enum SWPFlags
    {
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOREDRAW = 0x0008,
        SWP_NOACTIVATE = 0x0010,
        SWP_FRAMECHANGED = 0x0020
    }

    /// <summary>
    ///     The SysCommands which can be executed by a form button.
    /// </summary>
    public enum SysCommand
    {
        /// <summary>
        ///     If no SysCommands should be executed
        /// </summary>
        SC_NONE = 0x0,

        /// <summary>
        ///     If the Form should be closed.
        /// </summary>
        SC_CLOSE = 0xf060,

        /// <summary>
        ///     If the Form should be maximized
        /// </summary>
        SC_MAXIMIZE = 0xf030,

        /// <summary>
        ///     If the Form should be minimized
        /// </summary>
        SC_MINIMIZE = 0xf020,

        /// <summary>
        ///     If the form should be restored from the maximize mode.
        /// </summary>
        SC_RESTORE = 0xf120
    }

    /// <summary>
    ///     Windows Messages
    ///     Defined in winuser.h from Windows SDK v6.1
    ///     Documentation pulled from MSDN.
    /// </summary>
    public enum Win32Messages : uint
    {
        /// <summary>
        ///     The WM_SIZE message is sent to a window after its size has changed.
        /// </summary>
        SIZE = 0x0005,

        /// <summary>
        ///     The WM_ACTIVATE message is sent to both the window being activated and the window being deactivated. If the windows
        ///     use the same input queue, the message is sent synchronously, first to the window procedure of the top-level window
        ///     being deactivated, then to the window procedure of the top-level window being activated. If the windows use
        ///     different input queues, the message is sent asynchronously, so the window is activated immediately.
        /// </summary>
        ACTIVATE = 0x0006,

        /// <summary>
        ///     The WM_SHOWWINDOW message is sent to a window when the window is about to be hidden or shown.
        /// </summary>
        SHOWWINDOW = 0x0018,

        /// <summary>
        ///     The WM_ACTIVATEAPP message is sent when a window belonging to a different application than the active window is
        ///     about to be activated. The message is sent to the application whose window is being activated and to the
        ///     application whose window is being deactivated.
        /// </summary>
        ACTIVATEAPP = 0x001C,
        GETMINMAXINFO = 0x0024,

        /// <summary>
        ///     The WM_WINDOWPOSCHANGING message is sent to a window whose size, position, or place in the Z order is about to
        ///     change as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        WINDOWPOSCHANGING = 0x0046,

        /// <summary>
        ///     The WM_WINDOWPOSCHANGED message is sent to a window whose size, position, or place in the Z order has changed as a
        ///     result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        WINDOWPOSCHANGED = 0x0047,

        /// <summary>
        ///     The WM_STYLECHANGED message is sent to a window after the SetWindowLong function has changed one or more of the
        ///     window's styles
        /// </summary>
        STYLECHANGED = 0x007D,

        /// <summary>
        ///     The WM_NCCALCSIZE message is sent when the size and position of a window's client area must be calculated. By
        ///     processing this message, an application can control the content of the window's client area when the size or
        ///     position of the window changes.
        /// </summary>
        NCCALCSIZE = 0x0083,

        /// <summary>
        ///     The WM_NCHITTEST message is sent to a window when the cursor moves, or when a mouse button is pressed or released.
        ///     If the mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent
        ///     to the window that has captured the mouse.
        /// </summary>
        NCHITTEST = 0x0084,

        /// <summary>
        ///     The WM_NCPAINT message is sent to a window when its frame must be painted.
        /// </summary>
        NCPAINT = 0x0085,

        /// <summary>
        ///     The WM_NCACTIVATE message is sent to a window when its nonclient area needs to be changed to indicate an active or
        ///     inactive state.
        /// </summary>
        NCACTIVATE = 0x0086,

        /// <summary>
        ///     The WM_NCMOUSEMOVE message is posted to a window when the cursor is moved within the nonclient area of the window.
        ///     This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is
        ///     not posted.
        /// </summary>
        NCMOUSEMOVE = 0x00A0,

        /// <summary>
        ///     The WM_NCLBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is within the
        ///     nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured
        ///     the mouse, this message is not posted.
        /// </summary>
        NCLBUTTONDOWN = 0x00A1,

        /// <summary>
        ///     The WM_NCLBUTTONUP message is posted when the user releases the left mouse button while the cursor is within the
        ///     nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured
        ///     the mouse, this message is not posted.
        /// </summary>
        NCLBUTTONUP = 0x00A2,

        /// <summary>
        ///     A window receives this message when the user chooses a command from the Window menu, clicks the maximize button,
        ///     minimize button, restore button, close button, or moves the form. You can stop the form from moving by filtering
        ///     this out.
        /// </summary>
        SYSCOMMAND = 0x0112,

        /// <summary>
        ///     The WM_LBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is in the client
        ///     area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise,
        ///     the message is posted to the window that has captured the mouse.
        /// </summary>
        LBUTTONDOWN = 0x0201,

        /// <summary>
        ///     An application sends the WM_MDIACTIVATE message to a multiple-document interface (MDI) client window to instruct
        ///     the client window to activate a different MDI child window.
        /// </summary>
        MDIACTIVATE = 0x0222,

        /// <summary>
        ///     The WM_MOUSELEAVE message is posted to a window when the cursor leaves the client area of the window specified in a
        ///     prior call to TrackMouseEvent.
        /// </summary>
        MOUSELEAVE = 0x02A3,

        /// <summary>
        ///     The WM_NCMOUSELEAVE message is posted to a window when the cursor leaves the nonclient area of the window specified
        ///     in a prior call to TrackMouseEvent.
        /// </summary>
        NCMOUSELEAVE = 0x02A2,

        MOUSEHOVER = 0x2A1
    }

    #endregion

    #region Structs

    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct APPBARDATA
    {
        public int cbSize;
        public IntPtr hWnd;
        public int uCallbackMessage;
        public int uEdge;
        public RECT rc;
        public IntPtr lParam;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        public RECT rect0;
        public RECT rect1;
        public RECT rect2;
        public WINDOWPOS IntPtr;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public int flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public RECT(Rectangle Rectangle)
            : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
        {
        }

        public RECT(int Left, int Top, int Right, int Bottom)
        {
            X = Left;
            Y = Top;
            this.Right = Right;
            this.Bottom = Bottom;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Left
        {
            get => X;
            set => X = value;
        }

        public int Top
        {
            get => Y;
            set => Y = value;
        }

        public int Right { get; set; }

        public int Bottom { get; set; }

        public int Height
        {
            get => Bottom - Y;
            set => Bottom = value - Y;
        }

        public int Width
        {
            get => Right - X;
            set => Right = value + X;
        }

        public Point Location
        {
            get => new Point(Left, Top);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Size Size
        {
            get => new Size(Width, Height);
            set
            {
                Right = value.Height + X;
                Bottom = value.Height + Y;
            }
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(Left, Top, Width, Height);
        }

        public static Rectangle ToRectangle(RECT Rectangle)
        {
            return Rectangle.ToRectangle();
        }

        public static RECT FromRectangle(Rectangle Rectangle)
        {
            return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
        }

        public static implicit operator Rectangle(RECT Rectangle)
        {
            return Rectangle.ToRectangle();
        }

        public static implicit operator RECT(Rectangle Rectangle)
        {
            return new RECT(Rectangle);
        }

        public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
        {
            return Rectangle1.Equals(Rectangle2);
        }

        public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
        {
            return !Rectangle1.Equals(Rectangle2);
        }

        public override string ToString()
        {
            return "{Left: " + X + "; " + "Top: " + Y + "; Right: " + Right + "; Bottom: " + Bottom + "}";
        }

        public bool Equals(RECT Rectangle)
        {
            return Rectangle.Left == X && Rectangle.Top == Y && Rectangle.Right == Right && Rectangle.Bottom == Bottom;
        }

        public override bool Equals(object Object)
        {
            if (Object is RECT)
                return Equals((RECT) Object);
            if (Object is Rectangle)
                return Equals(new RECT((Rectangle) Object));

            return false;
        }
    }

    #endregion
}