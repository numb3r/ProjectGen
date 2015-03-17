using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalEventNepal.Domain.Entities
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string EventName { get; set; }

        [Required]
        [MaxLength(25)]
        public string Category { get; set; }

        [Required]
        [MaxLength(25)]
        public string Organization { get; set; }

        [Required]
        public DateTime Starts { get; set; }

        public DateTime Ends { get; set; }

        [Required]
        [MaxLength(25)]
        public string Location { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public double Price { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
