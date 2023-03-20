using FinancialLibrary.Models;
using FinancialWPFApp.UI.Public.ViewModels.Pages;
using FinancialWPFApp.UI.Public.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinancialWPFApp.UI.Public.Commands.Pages
{
    public class RegisterCommand
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
            using (var context = new FinancialManagementContext())
            {
                Account account = new Account();
                account.Email = _viewModel.Email;
                account.Password = _viewModel.Password;
                account.IsActive = true;
                account.FullName = _viewModel.FullName;


                context.Accounts.Add(account);
                if (context.SaveChanges() > 0)
                {

                    RedirectToSignIn(parameter);
                }
                else
                {
                    MessageBox.Show("Failed to sign up new account");
                }

            }
        }


        private void RedirectToSignIn(object parameter)
        {
            Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");
            frame.Navigate(new LoginView());
        }

        private void SignUpWithGoogle(object parameter) { }

    }
}
