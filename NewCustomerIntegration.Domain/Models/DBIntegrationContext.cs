using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NewCustomerIntegration.Domain.Models.Mapping;

namespace NewCustomerIntegration.Domain.Models
{
    public partial class DBIntegrationContext : DbContext
    {
        static DBIntegrationContext()
        {
            Database.SetInitializer<DBIntegrationContext>(null);
        }

        public DBIntegrationContext()
            : base("Name=DBIntegrationContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<SiteType> SiteTypes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new OrganizationMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new RuleMap());
            modelBuilder.Configurations.Add(new SiteMap());
            modelBuilder.Configurations.Add(new SiteTypeMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserTypeMap());
        }
    }
}
