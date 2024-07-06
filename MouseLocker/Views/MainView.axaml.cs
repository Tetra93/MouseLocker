using Avalonia.Controls;
using Avalonia.Input;
using MouseLocker.ViewModels;
using System;

namespace MouseLocker.Views;

public partial class MainView : UserControl
{


    public MainView()
    {
        InitializeComponent();
        TextBlock1.PointerPressed += PointerPressedHandler;
        Button1.Click += OnClick;
    }


    private void OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var sourceButton = e.Source as Button;

        if (sourceButton != null)
        {
            MainViewModel.FindCursor();
            TextBlock1.Text = MainViewModel.GetCoordinates();
            MainViewModel.MoveCursor();
        }
    }

    public void PointerPressedHandler (object? sender, PointerPressedEventArgs args)
    {
        MainViewModel.FindCursor();
        TextBlock1.Text = MainViewModel.GetCoordinates();
        MainViewModel.MoveCursor();
    }
}
