using System;
using System.Collections.Generic;

namespace RatesCalculator.Data.Models
{
    public partial class AuditEntityField
    {
        public int AuditEntityFieldId { get; set; }
        public int AuditEntityId { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual AuditEntity AuditEntity { get; set; }
    }
}
