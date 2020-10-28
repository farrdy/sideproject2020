using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class AuditEntity
    {
        public AuditEntity()
        {
            AuditEntityField = new HashSet<AuditEntityField>();
        }

        public int AuditEntityId { get; set; }
        public string Reference { get; set; }
        public DateTime Timestamp { get; set; }
        public string EntityName { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public int? ProjectId { get; set; }

        public virtual ICollection<AuditEntityField> AuditEntityField { get; set; }
    }
}
