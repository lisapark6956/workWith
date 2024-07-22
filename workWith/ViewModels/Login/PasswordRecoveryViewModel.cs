using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace workWith.ViewModels.Login
{
    public class PasswordRecoveryViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _statusMessage;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand RecoverCommand { get; }

        public PasswordRecoveryViewModel()
        {
            RecoverCommand = new RelayCommand(Recover, CanRecover);
        }

        private void Recover(object parameter)
        {
            if (IsValidEmail(Email))
            {
                StatusMessage = "Recovery email sent!";
                MessageBox.Show("Recovery email sent!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                StatusMessage = "Invalid email address.";
                MessageBox.Show("Invalid email address.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanRecover(object parameter)
        {
            return !string.IsNullOrEmpty(Email);
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
