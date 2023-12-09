using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using HaiwellTools.ViewModels;

namespace HaiwellTools.Views
{
    public partial class AddressCalcPage : UserControl
    {
        public AddressCalcPage()
        {
            InitializeComponent();
        }
        private async void DecCopy_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var clipboard = TopLevel.GetTopLevel(this)?.Clipboard;
            var dataObject = new DataObject();
            dataObject.Set(DataFormats.Text, ((AddressCalcPageViewModel)DataContext).Component1.DecModbusAdress.ToString());
            await clipboard?.SetDataObjectAsync(dataObject);
        }
        private async void HexCopy_Tapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var clipboard = TopLevel.GetTopLevel(this)?.Clipboard;
            var dataObject = new DataObject();
            dataObject.Set(DataFormats.Text, ((AddressCalcPageViewModel)DataContext).Component1.HexModbusAddress);
            await clipboard?.SetDataObjectAsync(dataObject);
        }
        private async void DecCopy_Tapped2(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var clipboard = TopLevel.GetTopLevel(this)?.Clipboard;
            var dataObject = new DataObject();
            dataObject.Set(DataFormats.Text, ((AddressCalcPageViewModel)DataContext).Component2.DecModbusAdress.ToString());
            await clipboard?.SetDataObjectAsync(dataObject);
        }
        private async void HexCopy_Tapped2(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var clipboard = TopLevel.GetTopLevel(this)?.Clipboard;
            var dataObject = new DataObject();
            dataObject.Set(DataFormats.Text, ((AddressCalcPageViewModel)DataContext).Component2.HexModbusAddress);
            await clipboard?.SetDataObjectAsync(dataObject);
        }
    }
}
