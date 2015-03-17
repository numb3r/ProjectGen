using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalEventNepal.Domain.Entities
{
    public class ContactAddress
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }

        [MaxLength(20)]
        [Required]
        public string Street1 { get; set; }

        [MaxLength(20)]
        public string Street2 { get; set; }

        [MaxLength(20)]
        public string Street3 { get; set; }

        [MaxLength(20)]
        [Required]
        public string City { get; set; }

        [MaxLength(20)]
        public string State { get; set; }

        //Should be from ISO 3166-1 Country Codes
        [MaxLength(3)]
        [Required]
        public string Country { get; set; }

        [MaxLength(20)]
        [Required]
        public string PostalCode { get; set; }
    }
}
