using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEventNepal.Domain.Entities.Mapping
{
    public class ContactEmailMap : EntityTypeConfiguration<ContactEmail>
    {
        public ContactEmailMap()
        {
            HasKey(a => a.Id);
            Property(p => p.Address).HasMaxLength(255).IsRequired();
            Property(p => p.Description).HasMaxLength(255);

            ToTable("ContactEmails");
        }
    }
}
