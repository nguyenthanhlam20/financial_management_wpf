using FinancialLibrary.Models;
using FinancialWPFApp.Constants;
using FinancialWPFApp.UI.Admin.Views;
using FinancialWPFApp.UI.Public.ViewModels.Pages;
using FinancialWPFApp.UI.Public.Views.Pages;
using FinancialWPFApp.UI.User.Views;
using FinancialWPFApp.UI.User.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinancialWPFApp.UI.Public.Commands.Pages
{
    public class LoginCommand
    {
        private LoginViewModel _viewModel;
        public LoginCommand(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.RedirectToSignUpCommand = new ReplayCommand(RedirectToSignUp);
            _viewModel.SignInCommand = new ReplayCommand(SignIn);
            _viewModel.SignInWithGoogleCommand = new ReplayCommand(SignInWithGoogle);
            _viewModel.RedirectToForgotPasswordCommand = new ReplayCommand(RedirectToForgotPassword);
        }

        private void SignIn(object parameter)
        {
            Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");
            using (var context = new FinancialManagementContext())
            {
                Account account = context.Accounts.SingleOrDefault(u => u.Email == _viewModel.Email && u.Password == _viewModel.Password);

                if (account != null)
                {
                    Application.Current.MainWindow.Hide();
                    if (account.RoleId == (int)AppConstants.Roles.Admin)
                    {

                        AdminMainWindowView window = new AdminMainWindowView();
                        window.Show();
                    }
                    else
                    {
                        UserMainWindowView window = new UserMainWindowView();
                        window.Show();
                    }

                }
                else
                {

                }

            }
        }

        private void RedirectToForgotPassword(object parameter)
        {
            Frame frame = (Frame)parameter;
            frame.Navigate(new LoginView());
        }

        private void RedirectToSignUp(object parameter)
        {
            Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");
            frame.Navigate(new RegisterView());
        }

        private void SignInWithGoogle(object parameter) { }


    }
}
