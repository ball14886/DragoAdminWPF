using DragoAdminWPF.Connex;
using DragoAdminWPF.Login;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragoAdminWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogouButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            Application.Current.MainWindow = loginWindow;
            loginWindow.Show();
            this.Close();
        }

        private void Connex_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Connex_Overview_Page connexOverviewPage = new Connex_Overview_Page();
            MainFrame.NavigationService.RemoveBackEntry();
            MainFrame.Navigate(connexOverviewPage);
        }
    }
}
