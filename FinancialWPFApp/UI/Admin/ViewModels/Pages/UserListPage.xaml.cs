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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinancialWPFApp.UI.Admin.ViewModels.Pages
{
    /// <summary>
    /// Interaction logic for UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void cbPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.Text != "")
            {
                int selectedIndex = cb.SelectedIndex;
                int pageSize = 0;
                if (selectedIndex == 0)
                {
                    pageSize = 10;

                }

                if (selectedIndex == 1)
                {
                    pageSize = 15;

                }

                if (selectedIndex == 2)
                {
                    pageSize = 20;

                }

           
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            //if (_viewModel.CurrentPage > 1)
            //{

            //    _viewModel.CurrentPage -= 1;
            //    InitializePagination();
            //    _viewModel.LoadWallets();
            //}
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            //if (_viewModel.CurrentPage < _viewModel.TotalPage)
            //{

            //    _viewModel.CurrentPage += 1;
            //    InitializePagination();
            //    _viewModel.LoadWallets();
            //}
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (txtSearch.Text != null)
            //{
            //    _viewModel.FilterSearch = txtSearch.Text;
            //    InitializePagination();
            //    _viewModel.LoadWallets();
            //}
        }
    }
}
