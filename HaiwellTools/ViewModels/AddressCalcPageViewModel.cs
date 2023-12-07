using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HaiwellTools.Models;
using HaiwellTools.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Component = HaiwellTools.Models.Component;
using System.Linq;

namespace HaiwellTools.ViewModels
{
    public partial class AddressCalcPageViewModel : ViewModelBase
    {
        public string Greeting => "Modbus PLC address calculator";
        public AddressCalcPageViewModel()
        {
            TypeList = Enum.GetNames<ComponentType>().ToList();
            //TypeList = new List<string> { "X", "Y", "M", "T", "C", "SM", "S" };
        }

        private Component _component1 = new Component(ComponentType.X);

        public Component Component1
        {
            get { return _component1; }
            set { _component1 = value; OnPropertyChanged(nameof(Component1)); }
        }
        private List<string> _typeList = new();

        public List<string> TypeList
        {
            get { return _typeList; }
            set { _typeList = value; OnPropertyChanged(nameof(TypeList)); }
        }


    }
}
