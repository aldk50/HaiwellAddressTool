using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HaiwellTools.ViewModels;

namespace HaiwellTools.Models
{
    public class Component : ViewModelBase
    {
        public Component()
        {

        }
        public Component(ComponentType component)
        {
            ComponentType = component;
        }
        private string _name = "";

        public string Name
        {
            get { return _name; }
        }


        private int _hmiStartAddress;

        public int HmiStartAddress
        {
            get { return _hmiStartAddress; }
            set
            {
                if (value <= 0) _hmiStartAddress = 0;
                if(value>0) _hmiStartAddress = 1;
                OnPropertyChanged(nameof(HmiStartAddress));
                DecModbusAdress = _minDecModbusAddress + _range + _hmiStartAddress;
            }
        }


        private int _maxRange;

        public int MaxRange
        {
            get { return _maxRange; }
        }

        private int _range = 0;

        public int Range
        {
            get { return _range; }
            set
            {
                _range = value;
                if (value > _maxRange) _range = _maxRange;
                OnPropertyChanged(nameof(Range));
                DecModbusAdress = _minDecModbusAddress + _range + _hmiStartAddress;
            }
        }
        private int _decModbusAddress;

        public int DecModbusAdress
        {
            get { return _decModbusAddress; }
            set { _decModbusAddress = value; OnPropertyChanged(nameof(DecModbusAdress)); HexModbusAddress = "0x"+_decModbusAddress.ToString("X"); }
        }
        private string _hexModbusAddress = "";

        public string HexModbusAddress
        {
            get { return _hexModbusAddress; }
            set { _hexModbusAddress = value; OnPropertyChanged(nameof(HexModbusAddress)); }
        }
        private int _minDecModbusAddress;

        public int MinDecModbusAddress
        {
            get { return _minDecModbusAddress; }
        }

        private int _maxDecModbusAddress;

        public int MaxDecModbusAddress
        {
            get { return _maxDecModbusAddress; }
        }

        private SizeType _sizeType;

        public SizeType SizeType
        {
            get { return _sizeType; }
        }

        private ComponentType _componentType;

        public ComponentType ComponentType
        {
            get { return _componentType; }
            set
            {
                _componentType = value;
                switch (ComponentType)
                {
                    case ComponentType.X:
                        _maxRange = 1023; _minDecModbusAddress = 0; _name = "External input"; _sizeType = SizeType.Bit;
                        break;
                    case ComponentType.Y:
                        _maxRange = 1023; _minDecModbusAddress = 1536; _name = "External output"; _sizeType = SizeType.Bit;
                        break;
                    case ComponentType.M:
                        _maxRange = 12287; _minDecModbusAddress = 3072; _name = "Auxiliary relay"; _sizeType = SizeType.Bit;
                        break;
                    case ComponentType.T:
                        _maxRange = 1023; _minDecModbusAddress = 15360; _name = "Timer(output coil)"; _sizeType = SizeType.Bit;
                        break;
                    case ComponentType.C:
                        _maxRange = 255; _minDecModbusAddress = 16384; _name = "Counter(output coil)"; _sizeType = SizeType.Bit;
                        break;
                    case ComponentType.SM:
                        _maxRange = 215; _minDecModbusAddress = 16896; _name = "System status bit"; _sizeType = SizeType.Bit;
                        break;
                    case ComponentType.S:
                        _maxRange = 2047; _minDecModbusAddress = 28672; _name = "Step relay"; _sizeType = SizeType.Bit;
                        break;
                    case ComponentType.CR:
                        _maxRange = 255; _minDecModbusAddress = 0; _name = "Expantion module parameter"; _sizeType = SizeType.Register;
                        break;
                    case ComponentType.AI:
                        _maxRange = 255; _minDecModbusAddress = 0; _name = "Analog input register"; _sizeType = SizeType.Register;
                        break;
                    case ComponentType.AQ:
                        _maxRange = 255; _minDecModbusAddress = 256; _name = "Analog output register"; _sizeType = SizeType.Register;
                        break;
                    case ComponentType.V:
                        _maxRange = 14847; _minDecModbusAddress = 512; _name = "Internal data register"; _sizeType = SizeType.Register;
                        break;
                    case ComponentType.TV:
                        _maxRange = 1023; _minDecModbusAddress = 15360; _name = "Timer(current value)"; _sizeType = SizeType.Register;
                        break;
                    case ComponentType.CV:
                        _maxRange = 255; _minDecModbusAddress = 16384; _name = "Counter(current value)"; _sizeType = SizeType.Register;
                        break;
                    case ComponentType.SV:
                        _maxRange = 900; _minDecModbusAddress = 17408; _name = "System special register"; _sizeType = SizeType.Register;
                        break;
                    default:
                        _maxRange = 0; _minDecModbusAddress = 0; _name = ""; _sizeType = SizeType.Non;
                        break;
                }
                _maxDecModbusAddress = _minDecModbusAddress + _maxRange;
                Range = Range;
                DecModbusAdress = _minDecModbusAddress + _range + _hmiStartAddress;
                OnPropertyChanged(nameof(ComponentType));
                OnPropertyChanged(nameof(SizeType));
                OnPropertyChanged(nameof(MaxRange));
                OnPropertyChanged(nameof(MinDecModbusAddress));
                OnPropertyChanged(nameof(MaxDecModbusAddress));
                OnPropertyChanged(nameof(Name));
            }
        }

    }

    public enum ComponentType
    {
        X, Y, M, T, C, SM, S, CR, AI, AQ, V, TV, CV, SV
    }
    public enum SizeType
    {
        Non, Bit, Register
    }
    public static class ComponentExtantion
    {
        public static string GetName(this ComponentType value)
        {
            return value.ToString();
        }
        public static ComponentType GetComponentType(this string value)
        {
            return value switch
            {
                "X" => ComponentType.X,
                "Y" => ComponentType.Y,
                "M" => ComponentType.M,
                "T" => ComponentType.T,
                "C" => ComponentType.C,
                "SM" => ComponentType.SM,
                "S" => ComponentType.S,
                "CR" => ComponentType.CR,
                "AI" => ComponentType.AI,
                "AQ" => ComponentType.AQ,
                "V" => ComponentType.V,
                "TV" => ComponentType.TV,
                "CV" => ComponentType.CV,
                "SV" => ComponentType.SV,
                _ => throw new NotImplementedException()
            };
        }

        public static string GetName(this SizeType value)
        {
            return value.ToString();
        }
        public static SizeType GetComponentSizeType(this string value)
        {
            return value switch
            {
                "Bit" => SizeType.Bit,
                "Register" => SizeType.Register,
                _ => SizeType.Non
            };
        }
    }
}
