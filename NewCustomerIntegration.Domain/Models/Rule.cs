using System;
using System.Collections.Generic;

namespace NewCustomerIntegration.Domain.Models
{
    public partial class Rule
    {
        public long RuleId { get; set; }
        public long ValueTypeId { get; set; }
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
    }
}
