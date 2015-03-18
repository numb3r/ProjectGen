using System.Data.Entity.ModelConfiguration;

namespace GlobalEventNepal.Domain.Entities.Mapping
{
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            HasKey(a => a.Id);
            Property(p => p.EventName).IsRequired().HasMaxLength(25);
            Property(p => p.Category).HasMaxLength(25);
            Property(p => p.Organization).HasMaxLength(25);
            Property(p => p.Description).HasMaxLength(100);

            HasOptional(p => p.Contact).WithMany().Map(m => m.MapKey("ContactId"));
            ToTable("Events");
        }
    }
}
