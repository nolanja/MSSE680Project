using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NewCustomerIntegration.Domain.Models.Mapping
{
    public class RuleMap : EntityTypeConfiguration<Rule>
    {
        public RuleMap()
        {
            // Primary Key
            this.HasKey(t => t.RuleId);

            // Properties
            this.Property(t => t.RuleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RuleName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RuleDescription)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Rules");
            this.Property(t => t.RuleId).HasColumnName("RuleId");
            this.Property(t => t.ValueTypeId).HasColumnName("ValueTypeId");
            this.Property(t => t.RuleName).HasColumnName("RuleName");
            this.Property(t => t.RuleDescription).HasColumnName("RuleDescription");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedDateTime).HasColumnName("ModifiedDateTime");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
