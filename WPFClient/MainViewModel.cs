using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace WPFClient
{
    class MainViewModel : INotifyPropertyChanged
    {
        ServiceReference1.ServiceClient _service;
        public MainViewModel()
        {
            _service = new ServiceReference1.ServiceClient();
        }

        string _inputValue;
        public string InputValue
        {
            get { return _inputValue; }
            set
            {
                string result = this.NumberInWordFormat;

                if (value == null || value == "")
                {
                    _inputValue = value;
                    result = "";
                }
                else if (Regex.IsMatch(value, @"^[0-9]\d*(\,\d{0,2})?$") 
                      || Regex.IsMatch(value, @"^[0-9]\d*(\.\d{0,2})?$"))
                {
                    _inputValue = value;
                    result = _service.ConvertToWord(_inputValue);
                }

                this.NumberInWordFormat = result;
                OnPropertyChanged();
            }
        }

        private string _numberInWordFormat;
        public string NumberInWordFormat
        {
            get { return _numberInWordFormat; }
            set
            {
                _numberInWordFormat = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}