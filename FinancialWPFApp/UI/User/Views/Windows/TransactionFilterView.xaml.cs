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
    /// Interaction logic for TransactionFilterView.xaml
    /// </summary>
    public partial class TransactionFilterView : Window
    {
        private TransactionView transactionView { get; set; }

        private TransactionViewModel _viewModel { get; set; }
        public TransactionFilterView()
        {
            InitializeComponent();
            Frame frame = (Frame)Application.Current.MainWindow.FindName("frameContent");
            transactionView = frame.Content as TransactionView;
            _viewModel = transactionView._viewModel;
            dpFrom.Text = _viewModel.FromFilter.ToString();
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
                cbWallet.SelectedValue = _viewModel.WalletFilter;
            }


            LoadStatus();


        }




        public void LoadStatus()
        {
            if (_viewModel.StatusFilter == (int)AppConstants.TransctionStatus.Completed)
            {
                rdCompleted.IsChecked = true;
            }

            if (_viewModel.StatusFilter == (int)AppConstants.TransctionStatus.Pending)
            {
                rdPending.IsChecked = true;
            }


            if (_viewModel.StatusFilter == (int)AppConstants.TransctionStatus.Draft)
            {
                rdDraft.IsChecked = true;
            }

            if (_viewModel.StatusFilter == (int)AppConstants.TransctionStatus.Cancel)
            {
                rdCancel.IsChecked = true;
            }
            if (_viewModel.StatusFilter == (int)AppConstants.TransctionStatus.All)
            {
                rdStatusAll.IsChecked = true;
            }




            if (_viewModel.TypeFilter == (int)AppConstants.TransactionType.Income)
            {
                rdIncome.IsChecked = true;
            }

            if (_viewModel.TypeFilter == (int)AppConstants.TransactionType.Expense)
            {
                rdExpense.IsChecked = true;
            }

            if (_viewModel.TypeFilter == (int)AppConstants.TransactionType.All)
            {
                rdTypeAll.IsChecked = true;
            }

            dpFrom.Text = _viewModel.FromFilter.ToString();
            dpTo.Text = _viewModel.ToFilter.ToString();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {



            if (rdCompleted.IsChecked == true)
            {
                _viewModel.StatusFilter = (int)AppConstants.TransctionStatus.Completed;
            }


            if (rdDraft.IsChecked == true)
            {
                _viewModel.StatusFilter = (int)AppConstants.TransctionStatus.Draft;
            }

            if (rdCancel.IsChecked == true)
            {
                _viewModel.StatusFilter = (int)AppConstants.TransctionStatus.Cancel;
            }

            if (rdPending.IsChecked == true)
            {
                _viewModel.StatusFilter = (int)AppConstants.TransctionStatus.Pending;
            }

            if (rdStatusAll.IsChecked == true)
            {
                _viewModel.StatusFilter = (int)AppConstants.TransctionStatus.All;
            }

            if (rdIncome.IsChecked == true)
            {
                _viewModel.TypeFilter = (int)AppConstants.TransactionType.Income;
            }

            if (rdExpense.IsChecked == true)
            {
                _viewModel.TypeFilter = (int)AppConstants.TransactionType.Expense;
            }

            if (rdTypeAll.IsChecked == true)
            {
                _viewModel.TypeFilter = (int)AppConstants.TransactionType.All;
            }


            _viewModel.FromFilter = DateTime.Parse(dpFrom.Text);
            _viewModel.ToFilter = DateTime.Parse(dpTo.Text);


            _viewModel.WalletFilter = (int)cbWallet.SelectedValue;


            transactionView.LoadTransactions(false);

            this.Close();
        }

        private void dpTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker db = sender as DatePicker;

            _viewModel.ToFilter = DateTime.Parse(db.Text);
        }
        
        private void dpFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker db = sender as DatePicker;

            _viewModel.FromFilter = DateTime.Parse(db.Text);
        }

        private void cbWallet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
