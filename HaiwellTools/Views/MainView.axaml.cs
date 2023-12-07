using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Platform;
using HaiwellTools.ViewModels;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace HaiwellTools.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        (menuitems?.Items?.Where(x=>((ListBoxItem)x)?.Name== "address").FirstOrDefault() as ListBoxItem).IsSelected=true;
    }

    private void ListBoxItem_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
    {
        if (System.Environment.OSVersion.Platform != System.PlatformID.Win32NT) (this.DataContext as MainViewModel)?.HidePaneCommand.Execute(null);
    }
}
