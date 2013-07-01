using System;
using System.Collections.Generic;

namespace NewCustomerIntegration.Domain.Models
{
    public partial class Address
    {
        public long AddressId { get; set; }
        public long SiteId { get; set; }
        public long AddressTypeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public Nullable<long> StateProvinceRegionId { get; set; }
        public string PostalCode { get; set; }
        public Nullable<long> CountryRegionId { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Site Site { get; set; }
    }
}
