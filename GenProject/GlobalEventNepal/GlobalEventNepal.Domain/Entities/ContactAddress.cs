using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalEventNepal.Domain.Entities
{
    public class ContactAddress
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string Street3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        //Should be from ISO 3166-1 Country Codes
        public string Country { get; set; }

        public string PostalCode { get; set; }
    }
}
