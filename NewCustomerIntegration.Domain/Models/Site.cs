using System;
using System.Collections.Generic;

namespace NewCustomerIntegration.Domain.Models
{
    public partial class Site
    {
        public Site()
        {
            this.Addresses = new List<Address>();
        }

        public long SiteId { get; set; }
        public long OrganizationId { get; set; }
        public long SiteTypeId { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public long TimeZoneId { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual SiteType SiteType { get; set; }
    }
}
