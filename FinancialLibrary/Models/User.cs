using System;
using System.Collections.Generic;

namespace FinancialLibrary.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; } = null!;
        public string AvatarUrl { get; set; } = null!;
        public int? AuthenticationTypeId { get; set; }
        public int? Role { get; set; }

        public virtual AuthenticationType? AuthenticationType { get; set; }
        public virtual Role? RoleNavigation { get; set; }
    }
}
