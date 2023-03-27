using FinancialWPFApp.UI.Admin.Commands;
using FinancialWPFApp.UI.Admin.ViewModels.Pages;
using FinancialWPFApp.UI.User.Commands;
using FinancialWPFApp.UI.User.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWPFApp.UI.Admin.ViewModels
{
    public class AdminMainWindowViewModel : INotifyPropertyChanged
    {
        [MaybeNull]
        public ReplayCommand MaximizeWindowCommand { get; set; }
        [MaybeNull]
        public ReplayCommand MinimizeWindowCommand { get; set; }
        [MaybeNull]
        public ReplayCommand CloseWindowCommand { get; set; }

        [MaybeNull]
        public ReplayCommand SwitchThemeCommand { get; set; }
        public ReplayCommand LogoutCommand { get; set; }

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

        public string _title = "Dashboard";
        public string Title
        {
            get { return _title; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("Title");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public AdminMainWindowViewModel()
        {
            AdminMainWindowCommand commands = new AdminMainWindowCommand(this);
            CurrentPage = new DashboardPage();
        }
    }
}
