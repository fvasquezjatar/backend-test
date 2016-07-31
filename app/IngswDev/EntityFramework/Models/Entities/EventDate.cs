using System;

namespace IngswDev.EntityFramework.Models.Entities
{
    public class EventDate : IEntity
    {
        public long Id { get; set; }
        public DateTime TargetDate { get; set; }
        public string TimeZone { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; }
        public bool Deleted { get; set; }
    }
}
