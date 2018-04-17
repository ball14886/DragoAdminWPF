using DragoAdminWPF.Models;
using DragoAdminWPF.Provider;
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

namespace DragoAdminWPF.Connex
{
    public partial class Connex_Config_Page : Page
    {
        public Connex_Config_Page()
        {
            InitializeComponent();
            Dispatcher.Invoke(() =>
            {
                BindDDLAsync();
            });
        }

        public Connex_Config_Page(string dragoConnexID)
        {
            InitializeComponent();
            Dispatcher.Invoke(() =>
            {
                BindDDLAsync();
            });
        }

        private async Task BindDDLAsync()
        {
            List<string> state = AppProvider.EnableStates;
            CloudUploadComboBox.ItemsSource = state;
            LanguageComboBox.ItemsSource = state;
            FTPComboBox.ItemsSource = state;
            CheckUpdateComboBox.ItemsSource = state;
            EmailAlertComboBox.ItemsSource = state;
            EmailAfterResetComboBox.ItemsSource = state;
            EmailReportComboBox.ItemsSource = state;

            MonthComboBox.ItemsSource = AppProvider.Months;

            UTCComboBox.ItemsSource = AppProvider.UTCs;

            DayComboBox.ItemsSource = AppProvider.NumericDays;

            DateComboBox.ItemsSource = AppProvider.WordDays;

            AlarmTypeComboBox.ItemsSource = AppProvider.AlarmTypes;

            HourComboBox.ItemsSource = AppProvider.HourString();

            MinuteComboBox.ItemsSource = AppProvider.MinuteString();

            SecondComboBox.ItemsSource = AppProvider.SecondString();

            LogTimeComboBox.ItemsSource = AppProvider.MinuteString();

            var buildings = await new BuildingProvider().GetBuildingsAsync();
            AreaCombobox.ItemsSource = buildings;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Text.Trim();
            }
        }
    }
}