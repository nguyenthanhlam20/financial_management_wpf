using FinancialWPFApp.Constants;
using FinancialWPFApp.Models;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.Office.Interop.Excel;
using LiveCharts.Defaults;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace FinancialWPFApp.UI.User.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : System.Windows.Controls.Page
    {
        public LiveCharts.SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public int currentYear = DateTime.Now.Year;

        public DashboardView()
        {
            InitializeComponent();
            GetCardData();
            LoadYears();
            CreateBarChart();
            DataContext = this;
        }

        public void LoadYears()
        {

            using (var context = new FinancialManagementContext())
            {
                List<Transaction> transactions = context.Transactions.Where(tr => tr.Owner == Properties.Settings.Default.Email).ToList();

                transactions.Where(tr => tr.TransactionDate.Year == currentYear).ToList();
                var min = transactions.Min(o => o.TransactionDate);
                var max = transactions.Max(o => o.TransactionDate);

                int minYear = DateTime.Parse(min.ToString()).Year;
                int maxYear = DateTime.Parse(max.ToString()).Year;

                List<int> years = new();
                for (int i = maxYear; i >= minYear; i--)
                {
                    years.Add(i);
                }

                cbYears.ItemsSource = years;
                cbYears.SelectedIndex = 0;
            }
        }

        public void CreateBarChart()
        {

            SeriesCollection = new LiveCharts.SeriesCollection();
            using (var context = new FinancialManagementContext())
            {

                List<Transaction> transactions = context.Transactions.Where(tr => tr.Owner == Properties.Settings.Default.Email).ToList();
                transactions = transactions.Where(tr => tr.TransactionDate.Year == currentYear).ToList();

                List<double> incomes = new();
                List<double> expenses = new();

                for (int i = 1; i <= 12; i++)
                {

                    double totalIncome = 0;
                    double totalExpense = 0;

                    foreach (Transaction tr in transactions)
                    {
                        if (DateTime.Parse(tr.TransactionDate.ToString()).Month == i)
                        {
                            if (tr.TransactionTypeId == (int)AppConstants.TransactionType.Income
                                && tr.TransactionStatusId == (int)AppConstants.TransctionStatus.Completed)
                            {
                                totalIncome += tr.Amount;
                            }

                            if (tr.TransactionTypeId == (int)AppConstants.TransactionType.Expense
                               && tr.TransactionStatusId == (int)AppConstants.TransctionStatus.Completed)
                            {
                                totalExpense += tr.Amount;
                            }
                        }
                    }

                    incomes.Add(totalIncome);
                    expenses.Add(totalExpense);

                }





                SeriesCollection.Add(new ColumnSeries
                {
                    Title = "Income",
                    Foreground = System.Windows.Application.Current.Resources["PrimaryTextColor"] as Brush,
                    MaxColumnWidth = 25,
                    Values = new ChartValues<double>(incomes)
                });

                //adding series will update and animate the chart automatically
                SeriesCollection.Add(new ColumnSeries
                {
                    Title = "Expense",
                    MaxColumnWidth = 25,

                    Foreground = System.Windows.Application.Current.Resources["PrimaryTextColor"] as Brush,
                    Values = new ChartValues<double>(expenses)
                });



                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                Formatter = value => value.ToString("C2");
                chartHorizontal.Series = SeriesCollection;
            }




        }


        public void GetCardData()
        {
            using (var context = new FinancialManagementContext())
            {
                double totalIncome = 0, totalExpense = 0, totalBalance = 0;
                List<Wallet> wallets = context.Wallets.Where(w => w.Email == Properties.Settings.Default.Email).ToList();

                List<Transaction> transactions = context.Transactions.Where(t => t.Owner == Properties.Settings.Default.Email).ToList();


                foreach (Transaction tr in transactions)
                {

                    if (tr.TransactionTypeId == (int)AppConstants.TransactionType.Income &&
                            tr.TransactionStatusId == (int)AppConstants.TransctionStatus.Completed)
                    {
                        totalIncome += tr.Amount;
                    }

                    if (tr.TransactionTypeId == (int)AppConstants.TransactionType.Expense &&
                           tr.TransactionStatusId == (int)AppConstants.TransctionStatus.Completed)
                    {
                        totalExpense += tr.Amount;
                    }
                }



                foreach (Wallet wa in wallets)
                {
                    totalBalance += wa.Balance;
                }


                decimal amount = Decimal.Parse(totalBalance.ToString());
                string formattedPrice = amount.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

                lbTotalBalance.Content = formattedPrice;

                amount = Decimal.Parse(totalIncome.ToString());
                formattedPrice = amount.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

                lbTotalIncome.Content = formattedPrice;

                amount = Decimal.Parse(totalExpense.ToString());
                formattedPrice = amount.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"));

                lbTotalExpense.Content = formattedPrice;



                lbTotalWallet.Content = wallets.Count();
            }
        }

        private void cbYears_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            if (String.IsNullOrEmpty(text) == false)
            {
                currentYear = int.Parse(text);

                CreateBarChart();
            }

        }
    }
}
