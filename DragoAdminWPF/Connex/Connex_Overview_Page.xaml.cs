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

        public async void BindData(string searchKeyWord)
        {
            Task<List<DragoConnex>> DragoConnexListAsTask = new DragoConnexProvider().GetDragoconnexesAsync();
            dragoConnexes = await DragoConnexListAsTask;
            ConnexGridview.ItemsSource = dragoConnexes.Where(x => x.AreaDescription.ToUpper().Contains(searchKeyWord) || x.DragoConnexID.ToUpper().Contains(searchKeyWord)).ToList();
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
    }
}
