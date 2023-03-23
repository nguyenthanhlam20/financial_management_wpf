using FinancialWPFApp.Models;
using FinancialWPFApp.UI.User.Commands.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FinancialWPFApp.UI.User.ViewModels.Pages
{
    public class TransactionViewModel
    {
        public List<Transaction> _transactions { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Transaction> Transactions
        {
            get { return _transactions; }
            set
            {
                _transactions = value;
                OnPropertyChanged("Transactions");

            }
        }

        public int _currentPage;

        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");

            }
        }
        public int _fromIndex;

        public int FromIndex
        {
            get { return _fromIndex; }
            set
            {
                _fromIndex = value;
                OnPropertyChanged("FromIndex");

            }
        }


        public int _toIndex;

        public int ToIndex
        {
            get { return _toIndex; }
            set
            {
                _toIndex = value;
                OnPropertyChanged("ToIndex");

            }
        }

        public int _totalTransaction;

        public int TotalTransaction
        {
            get { return _totalTransaction; }
            set
            {
                _totalTransaction = value;
                OnPropertyChanged("TotalTransaction");

            }
        }

        public int PageSize { get; set; }


        public int TotalPage { get; set; }
        public string FilterSearch { get; set; } = "";
        public ReplayCommand AddNewTransactionCommand { get; set; }
        public ReplayCommand EditTransactionCommand { get; set; }
        public ReplayCommand ViewtTransactionCommand { get; set; }

        public void LoadTransactions()
        {
            using (var context = new FinancialManagementContext())
            {
                List<Transaction> list = context.Transactions.Where(w => w.Owner == Properties.Settings.Default.Email && w.TransactionId.ToString().Contains(FilterSearch)).ToList();
                if (list.Count() > 0)
                {

                    int from = (CurrentPage - 1) * PageSize;

                    if (CurrentPage * PageSize >= TotalTransaction)
                    {
                        int step = TotalTransaction - from;
                        Transactions = list.GetRange(from, step);

                        FromIndex = (CurrentPage - 1) * PageSize + 1;
                        ToIndex = TotalTransaction;
                    }
                    else
                    {

                        Transactions = list.GetRange(from, PageSize);
                        FromIndex = (CurrentPage - 1) * PageSize + 1;
                        ToIndex = CurrentPage * PageSize;
                    }
                }

            }
        }




        public TransactionViewModel()
        {

            TransactionCommand command = new TransactionCommand(this);

            CurrentPage = 1;
            PageSize = 10;

            using (var context = new FinancialManagementContext())
            {
                List<Transaction> Transactions = context.Transactions.Where(w => w.Owner == Properties.Settings.Default.Email && w.TransactionId.ToString().Contains(FilterSearch)).ToList();


                TotalTransaction = Transactions.Count();


            }

            LoadTransactions();
        }

    }
}
