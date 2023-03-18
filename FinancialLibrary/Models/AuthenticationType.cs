using System;
using System.Collections.Generic;

namespace FinancialLibrary.Models
{
    public partial class AuthenticationType
    {
        public AuthenticationType()
        {
            Users = new HashSet<User>();
        }

        public int AuthenticationTypeId { get; set; }
        public string AuthenticationTypeName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
