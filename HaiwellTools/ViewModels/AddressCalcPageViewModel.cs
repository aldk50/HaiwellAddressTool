using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HaiwellTools.Models;
using HaiwellTools.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Component = HaiwellTools.Models.Component;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using System.Threading.Tasks;

namespace HaiwellTools.ViewModels
{
    public partial class AddressCalcPageViewModel : ViewModelBase
    {
        public string Greeting => "Modbus PLC address calculator";
        public AddressCalcPageViewModel()
        {
            TypeList = Enum.GetNames<ComponentType>().ToList();
        }

        private Component _component1 = new Component(ComponentType.X);

        public Component Component1
        {
            get { return _component1; }
            set { _component1 = value; OnPropertyChanged(nameof(Component1)); }
        }
        private Component _component2 = new Component(ComponentType.X);

        public Component Component2
        {
            get { return _component2; }
            set { _component2 = value; OnPropertyChanged(nameof(Component2)); }
        }
        private List<string> _typeList = new();

        public List<string> TypeList
        {
            get { return _typeList; }
            set { _typeList = value; OnPropertyChanged(nameof(TypeList)); }
        }
        [RelayCommand]
        private void SetHMIStartAddressTo0()
        {
            if (Component1 != null) Component1.HmiStartAddress = 0;
        }
        [RelayCommand]
        private void SetHMIStartAddressTo1()
        {
            if (Component1 != null) Component1.HmiStartAddress = 1;
        }
        [RelayCommand]
        private void SetHMIStartAddressTo0_2()
        {
            if (Component1 != null) Component2.HmiStartAddress = 0;
        }
        [RelayCommand]
        private void SetHMIStartAddressTo1_2()
        {
            if (Component1 != null) Component2.HmiStartAddress = 1;
        }


    }
}
