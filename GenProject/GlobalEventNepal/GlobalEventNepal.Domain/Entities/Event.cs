using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalEventNepal.Domain.Entities
{
    public class Event : DataItem
    {
        public override Guid Id { get; set; }

        public Guid ContactId { get; set; }

        public string EventName { get; set; }

        public string Category { get; set; }

        public string Organization { get; set; }

        public DateTime Starts { get; set; }

        public DateTime Ends { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool Featured { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
