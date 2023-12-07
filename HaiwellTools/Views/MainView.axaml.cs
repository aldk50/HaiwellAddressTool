using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Platform;
using HaiwellTools.ViewModels;
using Microsoft.CodeAnalysis;

namespace HaiwellTools.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void ListBoxItem_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (System.Environment.OSVersion.Platform != System.PlatformID.Win32NT) (this.DataContext as MainViewModel)?.HidePaneCommand.Execute(null);
    }
}
