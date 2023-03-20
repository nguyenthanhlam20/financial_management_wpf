using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialLibrary.Models;
using FinancialWPFApp.UI.User.Commands.Pages;

namespace FinancialWPFApp.UI.User.ViewModels.Pages
{
    public class TransactionViewModel
    {


        public ReplayCommand GetTransactions { get; set; }

        public ReplayCommand InsertTransaction { get; set; }

        public ReplayCommand UpdateTransaction { get; set; }

        public ReplayCommand FilterTransaction { get; set; }


        public string FilterKeyword { get; set; }

        public List<Transaction> transactions { get; set; }



        public TransactionViewModel()
        {
            TransactionCommand commands = new TransactionCommand(this);
        }
    }
}
