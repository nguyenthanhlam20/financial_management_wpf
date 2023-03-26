using FinancialWPFApp.Constants;
using FinancialWPFApp.Models;
using FinancialWPFApp.UI.User.ViewModels.Pages;
using FinancialWPFApp.UI.User.Views.Pages;
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
    /// Interaction logic for ChooseExportOptionView.xaml
    /// </summary>
    public partial class ChooseExportOptionView : Window
    {
        private TransactionView transactionView { get; set; }

        private TransactionViewModel _viewModel { get; set; }
        public ChooseExportOptionView()
        {
            InitializeComponent();
            Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");
            transactionView = frame.Content as TransactionView;
            _viewModel = transactionView._viewModel;

            LoadDefaultValue();
        }

        public void LoadDefaultValue()
        {
            using (var context = new FinancialManagementContext())
            {
                List<Wallet> wallets = new List<Wallet>();
                wallets.Add(new Wallet() { WalletId = 100, WalletName = "All Wallet", Email = Properties.Settings.Default.Email });

                wallets.AddRange(context.Wallets.Where(w => w.Email == Properties.Settings.Default.Email).ToList());

                cbWallet.ItemsSource = wallets;
                cbWallet.DisplayMemberPath = "DisplayWallet";
                cbWallet.SelectedValuePath = "WalletId";
                cbWallet.SelectedValue = _viewModel.WalletExport;
            }


            LoadStatus();


        }

        public void LoadStatus()
        {
            if (_viewModel.StatusExport == (int)AppConstants.TransctionStatus.Completed)
            {
                rdCompleted.IsChecked = true;
            }

            if (_viewModel.StatusExport == (int)AppConstants.TransctionStatus.Pending)
            {
                rdPending.IsChecked = true;
            }


            if (_viewModel.StatusExport == (int)AppConstants.TransctionStatus.Draft)
            {
                rdDraft.IsChecked = true;
            }

            if (_viewModel.StatusExport == (int)AppConstants.TransctionStatus.Cancel)
            {
                rdCancel.IsChecked = true;
            }
            if (_viewModel.StatusExport == (int)AppConstants.TransctionStatus.All)
            {
                rdStatusAll.IsChecked = true;
            }




            if (_viewModel.TypeExport == (int)AppConstants.TransactionType.Income)
            {
                rdIncome.IsChecked = true;
            }

            if (_viewModel.TypeExport == (int)AppConstants.TransactionType.Expense)
            {
                rdExpense.IsChecked = true;
            }

            if (_viewModel.TypeExport == (int)AppConstants.TransactionType.All)
            {
                rdTypeAll.IsChecked = true;
            }

            dpFrom.Text = _viewModel.FromExport.ToString();
            dpTo.Text = _viewModel.ToExport.ToString();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {



            if (rdCompleted.IsChecked == true)
            {
                _viewModel.StatusExport = (int)AppConstants.TransctionStatus.Completed;
            }


            if (rdDraft.IsChecked == true)
            {
                _viewModel.StatusExport = (int)AppConstants.TransctionStatus.Draft;
            }

            if (rdCancel.IsChecked == true)
            {
                _viewModel.StatusExport = (int)AppConstants.TransctionStatus.Cancel;
            }

            if (rdPending.IsChecked == true)
            {
                _viewModel.StatusExport = (int)AppConstants.TransctionStatus.Pending;
            }

            if (rdStatusAll.IsChecked == true)
            {
                _viewModel.StatusExport = (int)AppConstants.TransctionStatus.All;
            }

            if (rdIncome.IsChecked == true)
            {
                _viewModel.TypeExport = (int)AppConstants.TransactionType.Income;
            }

            if (rdExpense.IsChecked == true)
            {
                _viewModel.TypeExport = (int)AppConstants.TransactionType.Expense;
            }

            if (rdTypeAll.IsChecked == true)
            {
                _viewModel.TypeExport = (int)AppConstants.TransactionType.All;
            }


            _viewModel.FromExport = DateTime.Parse(dpFrom.Text);
            _viewModel.ToExport = DateTime.Parse(dpTo.Text);


            _viewModel.WalletExport = (int)cbWallet.SelectedValue;


            transactionView.ExportToExcel();

            this.Close();
        }
    }
}
