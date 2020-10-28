using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public virtual User UserRole1 { get; set; }
        public virtual Role UserRoleNavigation { get; set; }
    }
}
