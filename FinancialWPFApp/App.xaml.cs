using FinancialLibrary.Repository;
using FinancialWPFApp.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FinancialWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IAccountRepository), typeof(AccountRepository));
            services.AddSingleton(typeof(ITransactionRepository), typeof(TransactionRepository));

        }



    }
}
