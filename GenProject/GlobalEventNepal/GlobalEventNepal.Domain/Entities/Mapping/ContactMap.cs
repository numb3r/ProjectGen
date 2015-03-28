using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEventNepal.Domain.Entities.Mapping
{
    public class ContactMap:EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            HasKey(a => a.Id);
            Property(p => p.FirstName).HasMaxLength(50);
            Property(p => p.LastName).HasMaxLength(50);
            
            HasMany(p => p.Addresses).WithRequired().HasForeignKey(p => p.ContactId);
            HasMany(p => p.EmailAddresses).WithRequired().HasForeignKey(p => p.ContactId);
            HasMany(p => p.Phones).WithRequired().HasForeignKey(p => p.ContactId);

            ToTable("Contacts");
        }
    }
}
