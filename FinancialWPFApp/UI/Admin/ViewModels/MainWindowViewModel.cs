using FinancialWPFApp.UI.Admin.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinancialWPFApp.UI.Admin.ViewModels
{
    public class MainWindowViewModel
    {

        public ICommand WindowMaximizeCommand { get; }

        public ICommand WindowMinimizeCommand { get; }


        public MainWindowViewModel()
        {
            WindowMaximizeCommand = new MainWindowCommand();
            WindowMinimizeCommand = new MainWindowCommand();
        }
    }
}
