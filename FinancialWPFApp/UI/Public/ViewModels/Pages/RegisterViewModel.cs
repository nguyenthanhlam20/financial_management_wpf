using FinancialWPFApp.UI.Public.Commands.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWPFApp.UI.Public.ViewModels.Pages
{
    public class RegisterViewModel
    {
        [MaybeNull]
        public ReplayCommand SignUpCommand { get; set; }

        [MaybeNull]
        public ReplayCommand SignUpWithGoogleCommand { get; set; }

        [MaybeNull]
        public ReplayCommand RedirectToSignInCommand { get; set; }


        [MaybeNull]
        public string Email { get; set; }

        [MaybeNull]
        public string Password { get; set; }

        [MaybeNull]
        public bool IsRemember { get; set; }

        public RegisterViewModel()
        {
            RegisterCommand commands = new RegisterCommand(this);
        }
    }
}
