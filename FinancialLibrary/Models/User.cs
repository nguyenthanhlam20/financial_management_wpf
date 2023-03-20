using System;
using System.Collections.Generic;

namespace FinancialLibrary.Models
{
    public partial class User
    {
        public User()
        {
            Transactions = new HashSet<Transaction>();
            Wallets = new HashSet<Wallet>();
        }

        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; } = null!;
        public string? Avatar { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
