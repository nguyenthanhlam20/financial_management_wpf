using FinancialWPFApp.Models;
using FinancialWPFApp.Constants;
using FinancialWPFApp.Helpers;
using FinancialWPFApp.UI.Admin.Views;
using FinancialWPFApp.UI.Public.ViewModels.Pages;
using FinancialWPFApp.UI.Public.Views.Pages;
using FinancialWPFApp.UI.User.Views;
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


            Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");

            if (String.IsNullOrEmpty(_viewModel.Email) || String.IsNullOrEmpty(_viewModel.Password)
                || String.IsNullOrEmpty(_viewModel.FullName) || String.IsNullOrEmpty(_viewModel.ConfirmPassword))
            {
                MessageBox.Show("Please enter all required feilds");
            }
            else
            {

                if (ValidationHelper.IsValidEmail(_viewModel.Email) == false)
                {
                    MessageBox.Show("Please enter email in correct form (example@gmail.com)");
                }

                else if (ValidationHelper.IsValidPassword(_viewModel.Password) == false
                    || ValidationHelper.IsValidPassword(_viewModel.ConfirmPassword) == false)
                {
                    MessageBox.Show("Password must have at least 6 characters");
                }
                else if (_viewModel.Password != _viewModel.ConfirmPassword)
                {
                    MessageBox.Show("Password doesn't match");

                }
                else if (ValidationHelper.IsExistAccount(_viewModel.Password) == true)
                {
                    MessageBox.Show("The account is already exist");

                }
                else
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
