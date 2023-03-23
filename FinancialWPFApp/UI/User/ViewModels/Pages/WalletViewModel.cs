using FinancialWPFApp.Models;
using FinancialWPFApp.UI.User.Commands.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWPFApp.UI.User.ViewModels.Pages
{
    public class WalletViewModel : INotifyPropertyChanged
    {
        public List<Wallet> _wallets { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Wallet> Wallets
        {
            get { return _wallets; }
            set
            {
                _wallets = value;
                OnPropertyChanged("Wallets");

            }
        }



        public ReplayCommand AddNewWalletCommand { get; set; }  
        public ReplayCommand EditWalletCommand { get; set; }  
        public ReplayCommand ViewtWalletCommand { get; set; }  

        public void LoadWallets()
        {
            using (var context = new FinancialManagementContext())
            {

                Wallets = context.Wallets.Where(w => w.Email == Properties.Settings.Default.Email).ToList();
            }
        }

        public WalletViewModel()
        {

            WalletCommand command = new WalletCommand(this);

            LoadWallets();

        }

    }
}
