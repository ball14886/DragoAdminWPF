using DragoAdminWPF.Models;
using DragoAdminWPF.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Connex_Overview_Page : Page
    {
        List<DragoConnex> dragoConnexes = new List<DragoConnex>();

        public Connex_Overview_Page()
        {
            InitializeComponent();
        }

        private async void BindData(string searchKeyWord)
        {
            Task<List<DragoConnex>> DragoConnexListAsTask = new DragoConnexProvider().GetDragoconnexesAsync();
            dragoConnexes = await DragoConnexListAsTask;
            ConnexGridview.ItemsSource = dragoConnexes.Where(x => x.AreaDescription.ToUpper().Contains(searchKeyWord) || x.DragoConnexID.ToUpper().Contains(searchKeyWord)).ToList();
            dragoConnexes = ConnexGridview.ItemsSource as List<DragoConnex>;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchKeyWord = SearchTextBox.Text;
            if (string.IsNullOrEmpty(searchKeyWord))
            {
                searchKeyWord = "";
            }
            else
            {
                searchKeyWord = searchKeyWord.ToUpper();
            }

            Dispatcher.Invoke(() =>
            {
                BusyIndicator.IsBusy = true;
                BindData(searchKeyWord);
                BusyIndicator.IsBusy = false;
            });
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchTextBox.Text))
            {
                SearchTextBox.Text = SearchTextBox.Text.Trim();
            }
        }

        private void DeleteConnexButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton deletingDragoConnex = sender as RadioButton;
            string deletingDragoConnexID = (deletingDragoConnex.DataContext as DragoConnex).DragoConnexID ?? "";
            if (!string.IsNullOrEmpty(deletingDragoConnexID))
            {
                string messageBoxText = "Confirm delete DragoConnex?";
                string caption = string.Format("Delete DragoConnex");
                MessageBoxButton button = MessageBoxButton.OKCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

                if (result == MessageBoxResult.OK)
                {
                    DeleteDragoConnexAsync(deletingDragoConnexID);
                    ConnexGridview.ItemsSource = dragoConnexes;
                }
            }
        }

        private async void DeleteDragoConnexAsync(string dragoConnexID)
        {
            await new DragoConnexProvider().DeleteDragoConnexAsync(dragoConnexID);
        }
    }
}
