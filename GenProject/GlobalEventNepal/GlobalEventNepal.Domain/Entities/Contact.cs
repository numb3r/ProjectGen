using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalEventNepal.Domain.Entities
{
    public class Contact : DataItem
    {
        public override Guid Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
          
        public virtual ICollection<ContactAddress> Addresses { get; set; }

        public virtual ICollection<ContactEmail> EmailAddresses { get; set; }

        public virtual ICollection<ContactPhone> Phones { get; set; }
    }
}
