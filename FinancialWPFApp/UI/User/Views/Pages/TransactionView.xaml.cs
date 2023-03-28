using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using FinancialWPFApp.Constants;
using FinancialWPFApp.Models;
using FinancialWPFApp.UI.User.ViewModels.Pages;
using FinancialWPFApp.UI.User.Views.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace FinancialWPFApp.UI.User.Views.Pages
{
    /// <summary>
    /// Interaction logic for Transaction.xaml
    /// </summary>
    public partial class TransactionView : System.Windows.Controls.Page
    {
        public TransactionViewModel _viewModel { get; set; }

        private ChooseExportOptionView chooseExportWindow { get; set; }

        static Excel.Application excel = new Excel.Application();
        static Excel.Workbook workbook = excel.Workbooks.Add();
        static Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.Add();
        static Excel.Worksheet excelWorksheet = (Excel.Worksheet)workbook.Worksheets[1];


        public TransactionView()
        {
            excel = new Excel.Application();
            workbook = excel.Workbooks.Add();
            worksheet = (Excel.Worksheet)workbook.Worksheets.Add();
            excelWorksheet = (Excel.Worksheet)workbook.Worksheets[1];
            try
            {
                // Set the width of the first column to 20 characters
                Excel.Range column1 = excelWorksheet.Columns[1];
                column1.ColumnWidth = 7;

                // Set the width of the second column to 30 characters
                Excel.Range column2 = excelWorksheet.Columns[2];
                column2.ColumnWidth = 20;


                // Set the width of the second column to 30 characters
                Excel.Range column3 = excelWorksheet.Columns[3];
                column3.ColumnWidth = 12;


                // Set the width of the second column to 30 characters
                Excel.Range column4 = excelWorksheet.Columns[4];
                column4.ColumnWidth = 10;


                // Set the width of the second column to 30 characters
                Excel.Range column5 = excelWorksheet.Columns[5];
                column5.ColumnWidth = 10;


                // Set the width of the second column to 30 characters
                Excel.Range column6 = excelWorksheet.Columns[6];
                column6.ColumnWidth = 12;


                // Set the width of the second column to 30 characters
                Excel.Range column7 = excelWorksheet.Columns[7];
                column7.ColumnWidth = 50;

                // Set the width of the second column to 30 characters
                Excel.Range column8 = excelWorksheet.Columns[8];
                column8.ColumnWidth = 12;

                Excel.Range allCells = excelWorksheet.Cells;
                //allCells.WrapText = true;
                //allCells.EntireRow.AutoFit();

                // Set the horizontal alignment of all cells to center
                allCells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                // Set the vertical alignment of all cells to center
                allCells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                InitializeComponent();

                _viewModel = new TransactionViewModel();
                DataContext = _viewModel;

                InitializePageSize();
                InitializePagination();
            }
            catch (Exception)
            {


            }
        }

        public void ResetDefaultValue()
        {
            _viewModel.ToFilter = DateTime.Now;
            _viewModel.StatusFilter = (int)AppConstants.TransctionStatus.All;
            _viewModel.TypeFilter = (int)AppConstants.TransactionType.All;
            _viewModel.WalletFilter = AppConstants.WalletLimitation;
        }
        public void LoadTransactions(bool isInsert)
        {
            _viewModel.LoadTransactions();

            if (isInsert == true)
            {
                dgTransaction.ItemsSource = _viewModel.GetAllTransaction();
                _viewModel.CurrentPage = 1;
            }
            else
            {
                dgTransaction.ItemsSource = _viewModel.Transactions;

            }
            lbFromIndex.Content = _viewModel.FromIndex;
            lbToIndex.Content = _viewModel.ToIndex;
            lbTotalTransaction.Content = _viewModel.TotalTransaction;

            InitializePagination();
        }

        public void InitializePageSize()
        {
            cbPage.Items.Add(10);
            cbPage.Items.Add(15);
            cbPage.Items.Add(20);
            cbPage.SelectedIndex = 0;
        }

        public void InitializePagination()
        {
            pageContainer.Children.Clear();
            using (var context = new FinancialManagementContext())
            {
                List<Transaction> Transactions = _viewModel.GetAllTransaction();


                int totalRecord = Transactions.Count();


                _viewModel.TotalTransaction = totalRecord;
                int pageSize = _viewModel.PageSize;

                _viewModel.TotalPage = totalRecord % pageSize != 0 ? (totalRecord / pageSize) + 1 : totalRecord / pageSize;


                if (totalRecord == 0)
                {
                    bottomContent.Visibility = Visibility.Collapsed;
                    dgTransaction.Visibility = Visibility.Collapsed;
                    lbNoRecords.Visibility = Visibility.Visible;
                }
                else
                {
                    bottomContent.Visibility = Visibility.Visible;
                    dgTransaction.Visibility = Visibility.Visible;
                    lbNoRecords.Visibility = Visibility.Collapsed;
                }
                System.Windows.Controls.Button btn = new System.Windows.Controls.Button();

                //MessageBox.Show(pageSize.ToString());
                for (int i = 1; i <= _viewModel.TotalPage; i++)
                {
                    btn = new System.Windows.Controls.Button();
                    btn.Content = i.ToString();
                    btn.Style = System.Windows.Application.Current.Resources["PagingButton"] as System.Windows.Style;

                    if (_viewModel.CurrentPage == i)
                    {
                        btn.Background = System.Windows.Application.Current.Resources["ButtonHover"] as Brush;
                        btn.Foreground = System.Windows.Application.Current.Resources["TertiaryWhiteColor"] as Brush;

                    }
                    btn.Click += Btn_Click;
                    pageContainer.Children.Add(btn);

                }
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = sender as System.Windows.Controls.Button;

            int pageIndex = int.Parse(btn.Content.ToString());
            //MessageBox.Show("Clic " + pageIndex);

            _viewModel.CurrentPage = pageIndex;
            LoadTransactions(false);

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

                //MessageBox.Show(pageSize.ToString());
                _viewModel.PageSize = pageSize;
                _viewModel.CurrentPage = 1;
                LoadTransactions(true);
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CurrentPage > 1)
            {

                _viewModel.CurrentPage -= 1;
                LoadTransactions(false);

            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CurrentPage < _viewModel.TotalPage)
            {

                _viewModel.CurrentPage += 1;
                LoadTransactions(false);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text != null)
            {
                _viewModel.FilterSearch = txtSearch.Text;
                LoadTransactions(false);
            }
        }


        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";


            if (saveFileDialog.ShowDialog() == true)
            {
                ImportDataFromExcel(@"" + saveFileDialog.FileName);
            }
        }

        private void ImportDataFromExcel(string filePath)
        {
            try
            {
                // Create a new Excel Application
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                // Open the Excel workbook
                Workbook workbook = excelApp.Workbooks.Open(filePath);

                // Get the first worksheet
                Worksheet worksheet = workbook.Sheets[1];

                // Get the used range of cells
                Range range = worksheet.UsedRange;

                using (var context = new FinancialManagementContext())
                {
                    // Loop through each row and column in the range and retrieve the cell data
                    for (int row = 2; row <= 9; row++)
                    {
                        string client = range.Cells[row, 1].Value2.ToString();
                        string date = range.Cells[row, 2].Value2.ToString();
                        string type = range.Cells[row, 3].Value2.ToString();
                        string wallet = range.Cells[row, 4].Value2.ToString();
                        string amount = range.Cells[row, 5].Value2.ToString();
                        string note = range.Cells[row, 6].Value2.ToString();
                        string status = range.Cells[row, 7].Value2.ToString();

                        int typeId = context.TransactionTypes.SingleOrDefault(t => t.TransactionTypeName == type).TransactionTypeId;
                        int statusId = context.TransactionStatuses.SingleOrDefault(t => t.TransactionStatusName == status).TransactionStatusId;
                        Wallet w = context.Wallets.Where(w => w.WalletName == wallet).ToList().ElementAt(0);

                        int walletId = w.WalletId;

                        Transaction tr = new Transaction()
                        {
                            Owner = Properties.Settings.Default.Email,
                            FromTo = client,
                            TransactionDate = DateTime.Now,
                            TransactionTypeId = typeId,
                            TransactionStatusId = statusId,
                            WalletId = walletId,
                            Description = note,
                            Amount = Double.Parse(amount)
                        };

                        context.Transactions.Add(tr);
                    }
                    int number = context.SaveChanges();
                    if (number > 0)
                    {
                        LoadTransactions(true);
                        MessageBox.Show($"Import {number} transactions successful");
                    }
                    else
                    {
                        MessageBox.Show($"Import failed please check excel content format");
                    }
                }

                // Close the workbook and Excel Application
                workbook.Close();
                excelApp.Quit();
            }
            catch (Exception)
            {

                MessageBox.Show($"Import failed please check excel content format");
            }
        }



        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

            bool isExist = false;
            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
            {
                if (window.GetType() == typeof(ChooseExportOptionView))
                {
                    isExist = true;
                }
            }
            if (isExist == false)
            {
                chooseExportWindow = new ChooseExportOptionView();

                chooseExportWindow.Show();
            }
            else
            {
                if (chooseExportWindow.Topmost == false)
                {
                    chooseExportWindow.Activate();
                }
            }

        }


        public void ExportToExcel()
        {



            try
            {

                List<Transaction> list;

                using (var context = new FinancialManagementContext())
                {
                    list = context.Transactions.Where(w => w.Owner == Properties.Settings.Default.Email).Include(t => t.TransactionType)
               .Include(r => r.TransactionStatus).Include(e => e.Wallet).ToList();

                    //var dd = list.Min(o => o.TransactionDate);
                    //if (dd != null || dd.ToString() != "")
                    //{
                    //    DateTime smallestDate = DateTime.Parse(dd.ToString());
                    //    FromFilter = smallestDate;

                    //}

                    if (_viewModel.StatusExport != (int)AppConstants.TransctionStatus.All)
                    {
                        list = list.Where(t => t.TransactionStatusId == _viewModel.StatusExport).ToList();

                    }


                    if (_viewModel.TypeExport != (int)AppConstants.TransactionType.All)
                    {
                        list = list.Where(t => t.TransactionTypeId == _viewModel.TypeExport).ToList();
                    }

                    if (_viewModel.WalletExport != (int)AppConstants.WalletLimitation)
                    {
                        list = list.Where(t => t.WalletId == _viewModel.WalletExport).ToList();
                    }

                    list = list.Where(t => t.TransactionDate >= _viewModel.FromExport && t.TransactionDate <= _viewModel.ToExport).ToList();

                    //MessageBox.Show(list.Count().ToString());

                }


                if (list.Count() > 0)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.DefaultExt = ".xlsx";
                    saveFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";


                    if (saveFileDialog.ShowDialog() == true)
                    {
                        for (int i = 0; i < dgTransaction.Columns.Count - 1; i++)
                        {
                            worksheet.Cells[1, i + 1] = dgTransaction.Columns[i].Header;
                            for (int j = 0; j < list.Count(); j++)
                            {
                                Transaction tran = list[j];



                                for (int x = 0; x < dgTransaction.Columns.Count - 1; x++)
                                {
                                    worksheet.Cells[j + 2, x + 1] = tran.GetValue(x);
                                }
                            }
                        }
                        string filename = saveFileDialog.FileName;
                        workbook.SaveAs(@"" + filename);


                        workbook.Close();
                        excel.Quit();


                        MessageBox.Show("Export to excel file successful.");
                    }
                }
                else
                {

                    MessageBox.Show("There are no records that matches to your filters");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to export file." + ex);
            }
        }
    }
}
