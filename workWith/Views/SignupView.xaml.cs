using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using workWith.ViewModels.Login;
using workWith.Models.Login;

namespace workWith.Views
{
    /// <summary>
    /// signupView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignupView : Window, IClosable
    {
        public SignupView()
        {
            InitializeComponent();
            DataContext = new SignupViewModel();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is SignupViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
