using System;
using System.Collections.Generic;

namespace NewCustomerIntegration.Domain.Models
{
    public partial class Person
    {
        public long UserId { get; set; }
        public long OrganizationId { get; set; }
        public long UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UnitName { get; set; }
        public string UnitNumber { get; set; }
        public string Department { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
