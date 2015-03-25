using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEventNepal.Domain.Entities
{
    public abstract class DataItem
    {
        public abstract Guid Id { get; set; }
        public string Source { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(DataItem update)
        {
            Source = update.Source;
            UpdatedDate = update.UpdatedDate = DateTime.Now;
        }
    }
}
