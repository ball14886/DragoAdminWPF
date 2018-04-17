using DragoAdminWPF.Models;
using DragoAdminWPF.Provider;
using Microsoft.Win32;
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
using Telerik.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using System.IO;

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
            });
            BusyIndicator.IsBusy = false;
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
            RadButton deletingDragoConnex = sender as RadButton;
            string deletingDragoConnexID = (deletingDragoConnex.DataContext as DragoConnex).DragoConnexID ?? "";
            if (!string.IsNullOrEmpty(deletingDragoConnexID))
            {
                MessageBoxResult result = MessageBox.Show("Confirm delete DragoConnex?"
                                                          , "Delete DragoConnex"
                                                          , MessageBoxButton.OKCancel
                                                          , MessageBoxImage.Warning);

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

        private void CreateConfigButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm create config files?"
                                                      , "Create Config Files"
                                                      , MessageBoxButton.YesNo
                                                      , MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                string dragoConnexID = "";
                RadButton dragoConnexButton = sender as RadButton;
                dragoConnexID = (dragoConnexButton.DataContext as DragoConnex).DragoConnexID ?? "";
                if (!string.IsNullOrEmpty(dragoConnexID))
                {
                    DragoConnex target = dragoConnexes.SingleOrDefault(x => x.DragoConnexID == dragoConnexID);
                    if (target != null)
                    {
                        if (string.IsNullOrEmpty(target.DragoSetting))
                        {
                            MessageBox.Show("DragoConnex has no setting specified"
                                            , "Create Config Files"
                                            , MessageBoxButton.OK
                                            , MessageBoxImage.Warning);
                        }
                        else
                        {
                            CreateConfigFile(target.DragoSetting, target.DragoConnexID);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid DragoConnex ID"
                                    , "Create Config Files"
                                    , MessageBoxButton.OK
                                    , MessageBoxImage.Warning);
                }
            }
        }

        private async Task<DragoConnex> GetDragoconnexAsync(string dragoConnexID)
        {
            var dragoConnex = await new DragoConnexProvider().GetDragoconnexAsync(dragoConnexID);
            return dragoConnex as DragoConnex;
        }

        async void CreateConfigFile(string setting, string dragoConnexCode)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                var configFolder = $"{dialog.FileName} \\Config {dragoConnexCode}\\";
                Directory.CreateDirectory(configFolder);

                Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(setting);
                string toWrite = "";
                foreach (var item in dict.Reverse().Skip(2).Reverse())
                {
                    if (string.IsNullOrEmpty(item.Value))
                    {
                        toWrite += "\"" + Environment.NewLine;
                    }
                    else
                    {
                        if (!item.Key.Equals("AlarmSetting") || !item.Key.Equals("AMRSetting"))
                        {
                            toWrite += item.Value + Environment.NewLine;
                        }
                    }
                }

                toWrite = toWrite.Remove(toWrite.Length - 1);
                toWrite += Environment.NewLine;
                File.WriteAllText(configFolder + "NETWORK.csv", toWrite);
                MeterProvider MeterProvider = new MeterProvider();
                toWrite = "";
                var meters = await MeterProvider.GetMetersAsync("http://dragoservices.azurewebsites.net/api/DragoAdmin/Meters/DragoConnex/" + dragoConnexCode);
                if (meters != null)
                {
                    foreach (var meter in meters)
                    {
                        Dictionary<string, string> dictMeter = JsonConvert.DeserializeObject<Dictionary<string, string>>(meter.MeterSetting);
                        foreach (var item in dictMeter)
                        {

                            toWrite += item.Value + ",";

                        }

                        toWrite = toWrite.Remove(toWrite.Length - 1);
                        toWrite += Environment.NewLine;
                    }

                    File.WriteAllText(configFolder + "METER.csv", toWrite);
                }
                var dictAlarmSetting = JsonConvert.DeserializeObject<Dictionary<string, string>>(dict["AlarmSetting"]);
                toWrite = "";
                foreach (var item in dictAlarmSetting)
                {
                    if (String.IsNullOrEmpty(item.Value))
                        toWrite += "0" + ",";
                    else
                        toWrite += item.Value + ",";
                }
                toWrite = toWrite.Remove(toWrite.Length - 1);
                toWrite += Environment.NewLine;

                File.WriteAllText(configFolder + "ALARM.csv", toWrite);

                var dictAMRSetting = JsonConvert.DeserializeObject<Dictionary<string, string>>(dict["AMRSetting"]);
                toWrite = "";
                foreach (var item in dictAMRSetting)
                {
                    if (String.IsNullOrEmpty(item.Value))
                        toWrite += "0" + Environment.NewLine;
                    else
                        toWrite += item.Value + Environment.NewLine;
                }
                File.WriteAllText(configFolder + "AMR.csv", toWrite);
            }
        }

        private void EditConnexButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Confirm edit DragoConnex?"
                                                     , "Edit DragoConnex"
                                                     , MessageBoxButton.YesNo
                                                     , MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                string dragoConnexID = "";
                RadButton dragoConnexButton = sender as RadButton;
                DragoConnex dragoConnex = (dragoConnexButton.DataContext as DragoConnex);
                dragoConnexID = dragoConnex.DragoConnexID ?? "";

                if (!string.IsNullOrEmpty(dragoConnexID))
                {
                    Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(dragoConnex.DragoSetting);

                    MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                    var MainFrame = mainWindow.MainFrame;

                    Connex_Config_Page connexConfigPage = new Connex_Config_Page(dragoConnexID);
                    MainFrame.NavigationService.RemoveBackEntry();
                    MainFrame.Navigate(connexConfigPage);
                }
            }
        }
    }
}
