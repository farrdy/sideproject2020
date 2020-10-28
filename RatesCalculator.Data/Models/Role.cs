using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
