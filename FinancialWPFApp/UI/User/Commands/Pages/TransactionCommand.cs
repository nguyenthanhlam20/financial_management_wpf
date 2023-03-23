using FinancialWPFApp.UI.User.ViewModels.Pages;
using FinancialWPFApp.UI.User.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWPFApp.UI.User.Commands.Pages
{
    public class TransactionCommand
    {

        private TransactionViewModel _viewModel;
        private TransactionDetails td;

        public TransactionCommand(TransactionViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void OpenTransactionWindow(object parameter)
        {
            td = new TransactionDetails();
            td.Show();
        }

       

    }
}
