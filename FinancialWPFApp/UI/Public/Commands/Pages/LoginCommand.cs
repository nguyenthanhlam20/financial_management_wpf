using FinancialWPFApp.Models;
using FinancialWPFApp.Constants;
using FinancialWPFApp.Helpers;
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
using FinancialWPFApp.Properties;

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

            if (String.IsNullOrEmpty(_viewModel.Email) || String.IsNullOrEmpty(_viewModel.Password))
            {
                MessageBox.Show("Please enter email and password");
            }
            else
            {

                if (ValidationHelper.IsValidEmail(_viewModel.Email) == false)
                {
                    MessageBox.Show("Please enter email in correct form (example@gmail.com)");
                }

                else if (ValidationHelper.IsValidPassword(_viewModel.Password) == false)
                {
                    MessageBox.Show("Password must have at least 6 characters");
                }
                else
                {

                    using (var context = new FinancialManagementContext())
                    {
                        Account account = context.Accounts.SingleOrDefault(u => u.Email == _viewModel.Email && u.Password == _viewModel.Password);
                        if (account != null)
                        {
                           if(account.IsActive == true)
                            {
                                // Store the username and password in the application settings
                                Properties.Settings.Default.Email = account.Email;
                                Properties.Settings.Default.Password = account.Password;

                                // Save the settings
                                Properties.Settings.Default.Save();

                                Application.Current.MainWindow.Hide();
                                if (account.RoleId == (int)AppConstants.Roles.Admin)
                                {

                                    AdminMainWindowView window = new AdminMainWindowView();
                                    Application.Current.MainWindow = window;

                                }
                                else
                                {
                                    UserMainWindowView window = new UserMainWindowView();
                                    Application.Current.MainWindow = window;


                                }
                                Application.Current.MainWindow.Show();
                            } else
                            {
                                MessageBox.Show("Your account is blocked");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect email or password");

                        }

                    }
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
