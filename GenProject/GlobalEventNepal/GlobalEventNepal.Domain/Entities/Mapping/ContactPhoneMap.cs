using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEventNepal.Domain.Entities.Mapping
{
    public class ContactPhoneMap: EntityTypeConfiguration<ContactPhone>
    {
        public ContactPhoneMap()
        {
            HasKey(a => a.Id);
            Property(p => p.Number).HasMaxLength(50).IsRequired();
            Property(p => p.Description).HasMaxLength(255);

            ToTable("ContactPhones");
        }
    }
}
