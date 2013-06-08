using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NewCustomerIntegration.Domain.Models.Mapping
{
    public class SiteTypeMap : EntityTypeConfiguration<SiteType>
    {
        public SiteTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.SiteTypeId);

            // Properties
            this.Property(t => t.SiteTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SiteTypeName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("SiteType");
            this.Property(t => t.SiteTypeId).HasColumnName("SiteTypeId");
            this.Property(t => t.SiteTypeName).HasColumnName("SiteTypeName");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDateTime).HasColumnName("ModifiedDateTime");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
