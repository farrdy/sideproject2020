using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? Roleid { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
