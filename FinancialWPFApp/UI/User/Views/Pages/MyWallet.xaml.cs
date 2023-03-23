using FinancialWPFApp.UI.User.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialWPFApp.UI.User.Views.Pages
{
    /// <summary>
    /// Interaction logic for MyWallet.xaml
    /// </summary>
    public partial class MyWallet : Page
    {

        private WalletViewModel _viewModel;
        public MyWallet()
        {
            InitializeComponent();

            _viewModel = new WalletViewModel();
            DataContext = _viewModel;
        }


        public void LoadWallets()
        {
            _viewModel.LoadWallets();
        }

    }


}
