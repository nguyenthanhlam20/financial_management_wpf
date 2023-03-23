using FinancialWPFApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinancialWPFApp.UI.User.Views.Windows
{
    /// <summary>
    /// Interaction logic for TransactionDetails.xaml
    /// </summary>
    public partial class TransactionDetails : Window
    {
        public TransactionDetails()
        {
            InitializeComponent();
        }



        public void LoadWallets()
        {
            using(var context = new FinancialManagementContext())
            {
                cbWallet.ItemsSource = context.Wallets.ToList();
                cbWallet.DisplayMemberPath = "WalletName";
                cbWallet.SelectedValuePath = "WalletId";
                cbWallet.SelectedIndex = 0;
            }
        }

        public void LoadTransactionTypes()
        {
            using (var context = new FinancialManagementContext())
            {
                cbTransactionType.ItemsSource = context.Wallets.ToList();
                cbTransactionType.DisplayMemberPath = "TransactionTypeName";
                cbTransactionType.SelectedValuePath = "TransactionTypeId";
                cbTransactionType.SelectedIndex = 0;
            }
        }

        public void LoadStatus()
        {
            using (var context = new FinancialManagementContext())
            {
                cbStatus.ItemsSource = context.Wallets.ToList();
                cbStatus.DisplayMemberPath = "TransactionStatusName";
                cbStatus.SelectedValuePath = "TransactionStatusId";
                cbStatus.SelectedIndex = 0;
            }
        }
    }
}
