using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NewCustomerIntegration.Domain.Models.Mapping
{
    public class OrganizationMap : EntityTypeConfiguration<Organization>
    {
        public OrganizationMap()
        {
            // Primary Key
            this.HasKey(t => t.OrganizationId);

            // Properties
            this.Property(t => t.OrganizationCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OrganizationName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(50);

            this.Property(t => t.FaxNumber)
                .HasMaxLength(50);

            this.Property(t => t.ParentOrganizationCode)
                .HasMaxLength(50);

            this.Property(t => t.Theme)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Skin)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Organization");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.OrganizationCode).HasColumnName("OrganizationCode");
            this.Property(t => t.OrganizationName).HasColumnName("OrganizationName");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.FaxNumber).HasColumnName("FaxNumber");
            this.Property(t => t.ParentOrganizationCode).HasColumnName("ParentOrganizationCode");
            this.Property(t => t.Theme).HasColumnName("Theme");
            this.Property(t => t.Skin).HasColumnName("Skin");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.DELETED).HasColumnName("DELETED");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDateTime).HasColumnName("ModifiedDateTime");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
