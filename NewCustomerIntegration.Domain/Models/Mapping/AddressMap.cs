using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NewCustomerIntegration.Domain.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.AddressId);

            // Properties
            this.Property(t => t.AddressLine1)
                .HasMaxLength(200);

            this.Property(t => t.AddressLine2)
                .HasMaxLength(200);

            this.Property(t => t.AddressLine3)
                .HasMaxLength(200);

            this.Property(t => t.City)
                .HasMaxLength(100);

            this.Property(t => t.PostalCode)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.SiteId).HasColumnName("SiteId");
            this.Property(t => t.AddressTypeId).HasColumnName("AddressTypeId");
            this.Property(t => t.AddressLine1).HasColumnName("AddressLine1");
            this.Property(t => t.AddressLine2).HasColumnName("AddressLine2");
            this.Property(t => t.AddressLine3).HasColumnName("AddressLine3");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.StateProvinceRegionId).HasColumnName("StateProvinceRegionId");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.CountryRegionId).HasColumnName("CountryRegionId");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDateTime).HasColumnName("ModifiedDateTime");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");

            // Relationships
            this.HasRequired(t => t.Site)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.SiteId);

        }
    }
}
