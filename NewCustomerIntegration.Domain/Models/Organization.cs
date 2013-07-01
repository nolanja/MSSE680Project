using System;
using System.Collections.Generic;

namespace NewCustomerIntegration.Domain.Models
{
    public partial class Organization
    {
        public Organization()
        {
            this.People = new List<Person>();
            this.Sites = new List<Site>();
        }

        public long OrganizationId { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string ParentOrganizationCode { get; set; }
        public string Theme { get; set; }
        public string Skin { get; set; }
        public bool Active { get; set; }
        public bool DELETED { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Site> Sites { get; set; }
    }
}
