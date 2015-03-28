using System.Data.Entity;
using GlobalEventNepal.Domain.Entities;
using GlobalEventNepal.Domain.Entities.Mapping;

namespace GlobalEventNepal.Domain
{
    public class GlobalEventNepalContext : DbContext
    {
        static GlobalEventNepalContext()
        {
            Database.SetInitializer<GlobalEventNepalContext>(null);
        }

        public GlobalEventNepalContext()
            : base("Name=GlobalEventNepalContext")
        {
            Database.CommandTimeout = 300;
            Configuration.UseDatabaseNullSemantics = true;
        }

        public GlobalEventNepalContext(string connectionName)
            : base(connectionName)
        {

        }

        // Alphabetical Order
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<ContactEmail> ContactEmails { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Alphabetical Order  
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new ContactAddressMap());
            modelBuilder.Configurations.Add(new ContactEmailMap());
            modelBuilder.Configurations.Add(new ContactPhoneMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            
        }
    }
}
