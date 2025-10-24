using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ToolKitV.Views
{
    public partial class InputNumber : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Title { get; set; } = "";
        public string Description { get; set; } = "";

        public bool IsInputEnabledValue { get; set; } = true;
        public bool IsInputEnabled
        {
            get => IsInputEnabledValue;
            set
            {
                if (value != IsInputEnabledValue)
                {
                    IsInputEnabledValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private readonly string[] _values = { "512", "1024", "2048", "4096", "8192" };

        public string NumberValue { get; set; } = "2048";
        public string Value
        {
            get => NumberValue;
            set
            {
                if (value != NumberValue)
                {
                    NumberValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double SliderValueNumber { get; set; } = 2;
        public double SliderValue
        {
            get => SliderValueNumber;
            set
            {
                if (value != SliderValueNumber)
                {
                    SliderValueNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public InputNumber()
        {
            InitializeComponent();

            DataContext = this;
            UpdateValueFromSlider();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateValueFromSlider();
        }

        private void UpdateValueFromSlider()
        {
            int index = (int)SliderValue;
            if (index >= 0 && index < _values.Length)
            {
                Value = _values[index];
            }
        }
    }
}
