using Avalonia;
using Avalonia.Platform;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MouseLocker.ViewModels;

public class MainViewModel : INotifyPropertyChanged
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
    

    private string? _cursorPos = "0";
    public static int CursorX { get; set; }
    public static int CursorY { get; set; }

    public struct POINT
    {
        public int x;
        public int y;
    }

    public string CursorPos
    {
        get { return _cursorPos; }
        set
        {
            _cursorPos = $"Cursor position {CursorX}, {CursorY}";
            OnPropertyChanged(nameof(CursorPos));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged; 

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public static string GetCoordinates()
    {
        string coordinates = $"{CursorX}, {CursorY}";
        return coordinates;
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
