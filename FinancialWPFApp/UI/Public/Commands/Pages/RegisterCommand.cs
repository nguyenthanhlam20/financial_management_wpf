using FinancialWPFApp.UI.Public.ViewModels.Pages;
using FinancialWPFApp.UI.Public.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinancialWPFApp.UI.Public.Commands.Pages
{
    public  class RegisterCommand
    {

        private RegisterViewModel _viewModel;
        public RegisterCommand(RegisterViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.RedirectToSignInCommand = new ReplayCommand(RedirectToSignIn);
            _viewModel.SignUpCommand = new ReplayCommand(SignUp);
            _viewModel.SignUpWithGoogleCommand = new ReplayCommand(SignUpWithGoogle);
        }

        private void SignUp(object parameter)
        {

        }


        private void RedirectToSignIn(object parameter)
        {
            Frame frame = (Frame)parameter;
            frame.Navigate(new LoginView());
        }

        private void SignUpWithGoogle(object parameter) { }

    }
}
