using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalEventNepal.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [MaxLength(25)]
        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        [Required]
        public string EmailAddress { get; set; }

        public virtual ICollection<ContactAddress> Addresses { get; set; }
        public virtual Event Event { get; set; }
    }
}
