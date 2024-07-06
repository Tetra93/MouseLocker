using Avalonia;
using Avalonia.Platform;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MouseLocker.ViewModels;

public class MainViewModel
{

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT lpPoint);
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int x, int y);

    public static void GetCursorPosition()
    {

        POINT lpPoint;
        GetCursorPos(out lpPoint);
        CursorX = lpPoint.x;
        CursorY = lpPoint.y;
    }
    

    public static int CursorX { get; set; }
    public static int CursorY { get; set; }

    public struct POINT
    {
        public int x;
        public int y;
    }

    public static string CursorPos => $"{CursorX}, {CursorY}";

    public static string GetCoordinates()
    {
        string CursorPos = $"{CursorX}, {CursorY}";
        return CursorPos;
    }

    public static void FindCursor()
    {
        if (GetCursorPos(out POINT lpPoint))
        {
            CursorX = lpPoint.x;
            CursorY = lpPoint.y;
        }
    }

    public static void MoveCursor()
    {
        CursorX += 10;
        CursorY += 10;
        SetCursorPos(CursorX, CursorY);
    }
}
