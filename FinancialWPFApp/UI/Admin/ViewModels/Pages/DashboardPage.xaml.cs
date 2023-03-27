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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts.Defaults;
using System.Runtime.Serialization;
using System.ComponentModel;
using FinancialWPFApp.Constants;
using LiveCharts.Wpf;
using System.Globalization;
using LiveCharts;

namespace FinancialWPFApp.UI.Admin.ViewModels.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public LiveCharts.SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public int currentYear = DateTime.Now.Year;

        public DashboardPage()
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
                List<Account> accounts = context.Accounts.Where(ac => ac.RoleId != 1).ToList();
                var min = accounts.Min(o => o.RegisteredDate);
                var max = accounts.Max(o => o.RegisteredDate);

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

                List<Account> accounts = context.Accounts.Where(ac => ac.RoleId != 1).ToList();


                List<int> users = new();


                for (int i = 1; i <= 12; i++)
                {
                    int totalUser = 0;
                    foreach (Account ac in accounts)
                    {
                        if (ac.RegisteredDate.Month == i)
                        {
                            totalUser++;
                        }
                    }
                    users.Add(totalUser);

                }





                SeriesCollection.Add(new ColumnSeries
                {
                    Title = "User",
                    Foreground = System.Windows.Application.Current.Resources["PrimaryTextColor"] as Brush,
                    MaxColumnWidth = 35,
                    Values = new ChartValues<int>(users)
                });




                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                chartHorizontal.Series = SeriesCollection;
            }




        }


        public void GetCardData()
        {
            using (var context = new FinancialManagementContext())
            {
                List<Account> accounts = context.Accounts.Where(ac => ac.RoleId != 1).ToList();

                List<Transaction> transactions = context.Transactions.ToList();
                lbTotalTransaction.Content = transactions.Count().ToString();

                lbTotalUser.Content = accounts.Count().ToString();

                int newAccounts = 0;

                foreach (Account ac in accounts)
                {
                    if (ac.RegisteredDate.Year == DateTime.Now.Year &&
                     ac.RegisteredDate.Month <= DateTime.Now.Month
                     && ac.RegisteredDate.Month >= DateTime.Now.Month - 2)
                    {
                        newAccounts++;
                    }
                }

                lbNewUser.Content = newAccounts.ToString();

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
