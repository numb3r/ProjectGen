using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalEventNepal.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public virtual ICollection<ContactAddress> Addresses { get; set; }
    }
}
