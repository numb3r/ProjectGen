﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEventNepal.Domain.Entities
{
    public class ContactPhone
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Number { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
        public bool IsPrimary { get; set; }
    }
}
