using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEventNepal.Domain.Entities.Mapping
{
    public class ContactAddressMap:EntityTypeConfiguration<ContactAddress>
    {
        public ContactAddressMap()
        {
            HasKey(p => p.Id);
            Property(p => p.Street1).HasMaxLength(20).IsRequired();
            Property(p => p.Street2).HasMaxLength(20);
            Property(p => p.Street3).HasMaxLength(20);
            Property(p => p.City).HasMaxLength(20).IsRequired();
            Property(p => p.State).HasMaxLength(20);
            Property(p => p.Country).HasMaxLength(3).IsRequired();
            Property(p => p.PostalCode).HasMaxLength(20).IsRequired();

            ToTable("ContactAddresses");
        }
    }
}
