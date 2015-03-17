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

        public DbSet<Event> Events { get; set; }
        public DbSet<ContactAddress> ContactAddresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new ContactAddressMap());
            modelBuilder.Configurations.Add(new ContactMap());
        }
    }
}
