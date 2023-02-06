using FinancialWPFApp.UI.Admin.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinancialWPFApp.UI.Admin.ViewModels
{
    public class MainWindowViewModel
    {

        [NotNull]
        public ReplayCommand MaximizeWindowCommand { get; private set; }

        [NotNull]
        public ReplayCommand MinimizeWindowCommand { get; private set; }

        [NotNull]
        public ReplayCommand CloseWindowCommand { get; private set; }

        [NotNull]
        public ReplayCommand SwitchThemeCommand { get; private set; }



        public MainWindowViewModel()
        {
            MainWindowCommand commands = new MainWindowCommand();
            MaximizeWindowCommand = new ReplayCommand(commands.MaximizeWindow);
            MinimizeWindowCommand = new ReplayCommand(commands.MinimizeWindow);
            CloseWindowCommand = new ReplayCommand(commands.CloseWindow);
            SwitchThemeCommand = new ReplayCommand(commands.SwitchTheme);
        }
    }
}
