using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HaiwellTools.Views;
using System.Collections.Generic;

namespace HaiwellTools.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isPaneOpen = false;

    [ObservableProperty]
    private bool _isPaneClosed;

    [ObservableProperty]
    private UserControl _currentPage;

    private UserControl addressCalcPage = new AddressCalcPage();
    private UserControl infoPage = new InfoPage();

    private ListBoxItem _selectedItem;

    public ListBoxItem SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            if (_selectedItem?.Name == "info") { CurrentPage=null; CurrentPage = infoPage; }
            if (_selectedItem?.Name == "address") { CurrentPage = null; CurrentPage = addressCalcPage; }
            OnPropertyChanged(nameof(SelectedItem));           
        }    }



    [RelayCommand]
    private void TrigerPane()
    {
        IsPaneOpen = !IsPaneOpen;
        IsPaneClosed = !IsPaneOpen;
    }
    [RelayCommand]
    private void HidePane()
    {
        if (IsPaneOpen) TrigerPane();
    }
    public MainViewModel()
    {
        //CurrentPage = addressCalcPage;
        _isPaneClosed = !_isPaneOpen;
        addressCalcPage.DataContext = new AddressCalcPageViewModel();
        infoPage.DataContext = new InfoPageViewModel();
    }
}
