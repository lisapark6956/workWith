using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using workWith.ViewModels.Login;

namespace workWith.ViewModels.Login
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _statusMessage;
        private bool _rememberMe;
        private bool _isLoading;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
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

        public bool RememberMe
        {
            get => _rememberMe;
            set
            {
                _rememberMe = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand OpenSignupCommand { get; }
        public ICommand OpenPasswordRecoveryCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin);
            OpenSignupCommand = new RelayCommand(OpenSignup);
            OpenPasswordRecoveryCommand = new RelayCommand(OpenPasswordRecovery);
        }

        private void Login(object parameter)
        {
            IsLoading = true;

            // 여기에 실제 로그인 로직을 구현합니다.
            if (Username == "admin" && Password == "password")
            {
                StatusMessage = "Login successful!";
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // 로그인 상태 유지 로직 추가
                if (RememberMe)
                {
                    // Remember me logic (예: 사용자 이름과 토큰을 로컬 저장소에 저장)
                }
            }
            else
            {
                StatusMessage = "Invalid username or password.";
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            IsLoading = false;
        }

        private void OpenSignup(object parameter)
        {
            var signupView = new Views.SignupView();
            signupView.Show();
        }

        private void OpenPasswordRecovery(object parameter)
        {
            var passwordRecoveryView = new Views.PasswordRecoveryView();
            passwordRecoveryView.Show();
        }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
