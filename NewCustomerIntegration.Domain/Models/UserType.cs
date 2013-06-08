using System;
using System.Collections.Generic;

namespace NewCustomerIntegration.Domain.Models
{
    public partial class UserType
    {
        public UserType()
        {
            this.People = new List<Person>();
        }

        public long UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
