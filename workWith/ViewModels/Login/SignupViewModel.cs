using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using workWith.Models.Login;

namespace workWith.ViewModels.Login
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _email;
        private string _password;
        private string _statusMessage;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
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

        public ICommand SignupCommand { get; }

        public SignupViewModel()
        {
            SignupCommand = new RelayCommand(Signup, CanSignup);
        }

        private void Signup(object parameter)
        {
            // 여기에 실제 회원가입 로직을 구현합니다.
            if (IsValidUsername(Username) && IsValidEmail(Email) && IsValidPassword(Password))
            {
                StatusMessage = "Signup successful!";
                MessageBox.Show("Signup successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseWindow(parameter);
            }
            else
            {
                StatusMessage = "Invalid username, email or password.";
                MessageBox.Show("Invalid username, email or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanSignup(object parameter)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private bool IsValidUsername(string username)
        {
            return username.Length >= 3; // Example validation rule
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 8 && Regex.IsMatch(password, @"[~!@#*/]");
        }

        private void CloseWindow(object parameter)
        {
            if (parameter is IClosable closable)
            {
                closable.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
