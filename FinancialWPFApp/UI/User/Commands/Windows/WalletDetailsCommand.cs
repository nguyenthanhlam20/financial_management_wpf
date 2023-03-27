using FinancialWPFApp.Models;
using FinancialWPFApp.UI.User.ViewModels.Windows;
using FinancialWPFApp.UI.User.Views.Pages;
using FinancialWPFApp.UI.User.Views.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinancialWPFApp.UI.User.Commands.Windows
{
    public class WalletDetailsCommand
    {

        public WalletDetailsViewModel _viewModel;

        public WalletDetailsCommand(WalletDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.CloseWindowCommand = new ReplayCommand(CloseWindow);
            if (_viewModel.actionType == Constants.AppConstants.ActionType.Insert)
            {
                _viewModel.AddNewWalletCommand = new ReplayCommand(AddNew);
            }

            if (_viewModel.actionType == Constants.AppConstants.ActionType.Edit)
            {
                _viewModel.AddNewWalletCommand = new ReplayCommand(EditWallet);
            }
        }

        public void EditWallet(object parameter)
        {
            if (String.IsNullOrEmpty(_viewModel.Name) || String.IsNullOrEmpty(_viewModel.Description))
            {

                MessageBox.Show("Please enter all required fields");

            }
            else
            {
                using (var context = new FinancialManagementContext())
                {
                    Wallet w = new Wallet()
                    {
                        WalletId = _viewModel.WalletId,
                        WalletName = _viewModel.Name,
                        Balance = double.Parse(_viewModel.Balance.ToString(), NumberStyles.Currency),
                        Description = _viewModel.Description,
                        Email = Properties.Settings.Default.Email,
                    };

                    context.Wallets.Update(w);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Update wallet successfully");
                        Window win = parameter as Window;


                        Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");


                        MyWallet mw = frame.Content as MyWallet;

                        mw.LoadWallets(false);


                        win.Close();
                    }
                }
            }
        }


        public void AddNew(object parameter)
        {
            if (String.IsNullOrEmpty(_viewModel.Name) || String.IsNullOrEmpty(_viewModel.Description))
            {

                MessageBox.Show("Please enter all required fields");

            }
            else
            {
                using (var context = new FinancialManagementContext())
                {
                    Wallet w = new Wallet()
                    {
                        WalletName = _viewModel.Name,
                        Balance = double.Parse(_viewModel.Balance.ToString(), NumberStyles.Currency),
                        Description = _viewModel.Description,
                        Email = Properties.Settings.Default.Email,
                    };

                    context.Wallets.Add(w);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Add wallet successfully");
                        Window win = parameter as Window;


                        Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");


                        MyWallet mw = frame.Content as MyWallet;

                        mw.LoadWallets(true);
              
                        win.Close();
                    }
                }
            }
        }



        public void CloseWindow(object parameter)
        {
            Window w = parameter as Window;

            w.Close();
        }



    }
}
