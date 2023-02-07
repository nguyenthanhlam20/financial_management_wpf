﻿using FinancialWPFApp.Themes;
using FinancialWPFApp.UI.User.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FinancialWPFApp.UI.User.Commands
{
    public class MainWindowCommand : Window
    {

        private MainWindowViewModel _viewModel;
        public MainWindowCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.MaximizeWindowCommand = new ReplayCommand(MaximizeWindow);
            _viewModel.MinimizeWindowCommand= new ReplayCommand(MinimizeWindow);
            _viewModel.SwitchThemeCommand = new ReplayCommand(SwitchTheme);
            _viewModel.CloseWindowCommand = new ReplayCommand(CloseWindow);
        }

        public void MaximizeWindow(object parameter)
        {
            Window mainWindow = (Window) parameter;
            if(mainWindow.WindowState == WindowState.Normal)
            {
                mainWindow.WindowState = WindowState.Maximized;
            } else
            {
                mainWindow.WindowState = WindowState.Normal;
            }
        } 

        public void MinimizeWindow(object parameter)
        {
            Window mainWindow = (Window)parameter;
            mainWindow.WindowState = WindowState.Minimized;
        }

        public void CloseWindow(object parameter) {
            Window mainWindow = (Window)parameter;
            mainWindow.Close();
        }
       
        public void SwitchTheme(object parameter)
        {
            ToggleButton tgb = (ToggleButton) parameter; 
        
            if(tgb.IsChecked == true)
            {
                ThemeController.SetTheme(ThemeController.ThemeTypes.Dark);
            } else
            {
                ThemeController.SetTheme(ThemeController.ThemeTypes.Light);
            }
        }
    }
}