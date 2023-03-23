using FinancialWPFApp.Models;
using FinancialWPFApp.UI.User.Commands.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinancialWPFApp.UI.User.ViewModels.Pages
{
    public class TransactionViewModel
    {


        public ReplayCommand GetTransactions { get; set; }

        public ReplayCommand InsertTransaction { get; set; }

        public ReplayCommand UpdateTransaction { get; set; }

        public ReplayCommand FilterTransaction { get; set; }


        public string FilterKeyword { get; set; }

        public List<Transaction> Transactions { get; set; }


        public TransactionViewModel()
        {
            using(var context = new FinancialManagementContext())
            {
                Transactions = context.Transactions.Include(tr => tr.TransactionType).Include(tr => tr.TransactionStatus)
                    .Where(tr => tr.Owner == Properties.Settings.Default.Email).ToList();

            }

            TransactionCommand commands = new TransactionCommand(this);
        }
    }
}
