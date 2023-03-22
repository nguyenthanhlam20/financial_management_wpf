﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using FinancialWPFApp.UI.Public.Views.Pages;
using FinancialWPFApp.UI.User.Commands;
using FinancialWPFApp.UI.User.Views.Pages;

namespace FinancialWPFApp.UI.User.ViewModels
{
    public class UserMainWindowViewModel : INotifyPropertyChanged
    {

        [MaybeNull]
        public ReplayCommand MaximizeWindowCommand { get; set; }
        [MaybeNull]
        public ReplayCommand MinimizeWindowCommand { get; set; }
        [MaybeNull]
        public ReplayCommand CloseWindowCommand { get; set; }

        [MaybeNull]
        public ReplayCommand SwitchThemeCommand { get; set; }

        public ReplayCommand OpenPage { get; set; }


        public object _currentPage;
        public object CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public UserMainWindowViewModel()
        {
            UserMainWindowCommand commands = new UserMainWindowCommand(this);
            CurrentPage = new Dashboard();
        }
    }
}
