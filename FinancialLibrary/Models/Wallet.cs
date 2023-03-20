using System;
using System.Collections.Generic;

namespace FinancialLibrary.Models
{
    public partial class Wallet
    {
        public Wallet()
        {
            Emails = new HashSet<Account>();
        }

        public int WalletId { get; set; }
        public string WalletName { get; set; } = null!;
        public double Balance { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Account> Emails { get; set; }
    }
}
