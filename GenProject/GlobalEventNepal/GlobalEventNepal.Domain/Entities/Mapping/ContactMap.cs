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
            Property(p => p.FirstName).HasMaxLength(25);
            Property(p => p.LastName).HasMaxLength(25);
            Property(p => p.PhoneNumber).HasMaxLength(25);
            Property(p => p.EmailAddress).HasMaxLength(225);

            HasMany(p => p.Addresses).WithRequired().HasForeignKey(p => p.ContactId);

            ToTable("Contacts");
        }
    }
}
