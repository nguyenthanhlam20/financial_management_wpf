using FinancialWPFApp.Themes;
using FinancialWPFApp.UI.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinancialWPFApp.UI.Admin.Commands
{
    public class MainWindowCommand : Window
    {
     
        public void MaximizeWindow(object parameter)
        {
            Window mainWindow = (Window) parameter;
            if(mainWindow.WindowState == WindowState.Normal)
            {
                mainWindow.WindowState = WindowState.Maximized;
            }
        } 

        public void MinimizeWindow(object parameter)
        {
            Window mainWindow = (Window)parameter;
            MessageBox.Show("Im in here");

            mainWindow.WindowState = WindowState.Minimized;
        }

        public void CloseWindow(object parameter) {
            Window mainWindow = (Window)parameter;
            mainWindow.Close();
        }
       
        public void SwitchTheme(object parameter)
        {
            RadioButton rd = (RadioButton) parameter; 
        
            if(rd.IsChecked == true)
            {
                ThemeController.SetTheme(ThemeController.ThemeTypes.Dark);
            } else
            {
                ThemeController.SetTheme(ThemeController.ThemeTypes.Light);
            }
        }
    }
}
