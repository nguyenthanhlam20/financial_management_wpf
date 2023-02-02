using System;
using System.Collections.Generic;

namespace FinancialLibrary.DataAccess
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
