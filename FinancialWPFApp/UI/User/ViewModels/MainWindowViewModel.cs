using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using FinancialWPFApp.UI.User.Commands;

namespace FinancialWPFApp.UI.User.ViewModels
{
    public class MainWindowViewModel 
    {

        [MaybeNull]
        public ReplayCommand MaximizeWindowCommand { get; set; }
        [MaybeNull]
        public ReplayCommand MinimizeWindowCommand { get; set; }
        [MaybeNull]
        public ReplayCommand CloseWindowCommand { get; set; }

        [MaybeNull]
        public ReplayCommand SwitchThemeCommand { get; set; }

       
        public MainWindowViewModel()
        {
            MainWindowCommand commands = new MainWindowCommand(this);
        }
    }
}
