using FinancialWPFApp.UI.Public.Commands.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinancialWPFApp.UI.Public.ViewModels.Pages
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        [MaybeNull]
        public ReplayCommand SignInCommand { get; set; }

        [MaybeNull]
        public ReplayCommand SignInWithGoogleCommand { get; set; }

        [MaybeNull]
        public ReplayCommand RedirectToSignUpCommand { get; set; }

        [MaybeNull]
        public ReplayCommand RedirectToForgotPasswordCommand { get; set; }

        [MaybeNull]
        public string Email { get; set; }

        [MaybeNull]
        public string Password { get; set; }

        [MaybeNull] 
        public bool IsRemember { get; set; }


        public LoginViewModel()
        {
            LoginCommand commands = new LoginCommand(this);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
