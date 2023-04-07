using _11ArchitekturyNET.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _11ArchitekturyNET.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // blok informujici o tom, zda ma dojit k prekresleni
        #region MVVM
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "") 
        {
            // [CallerMemberName] - nemusim psat jmeno vlastnosti, doplni se automaticky podle toho, odkud metodu volam
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        // vars
        private string _inputText = string.Empty;
        private string _resultText = string.Empty;

        public MainViewModel()
        {
            SetText = new RelayCommand(
                () => 
                {
                    ResultText = InputText;
                },
                () => !string.IsNullOrEmpty(InputText)
            );
        }

        // commands
        public RelayCommand SetText { get; private set; }

        // props
        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged();
                SetText.RaiseCanExecuteChanged(); // podminka CanExecute se mohla zmenit
            }
        }
        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }
    }
}