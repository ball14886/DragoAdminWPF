using DragoAdminWPF.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DragoAdminWPF.Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            usernameTextBox.Focus();
            //LogoIcon.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Resources/Logo.png"));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (AuthenticationProvider.Authenticate(usernameTextBox.Text, passwordTextBox.Text))
            {
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
            }
        }

        private void usernamePasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
    }
}
