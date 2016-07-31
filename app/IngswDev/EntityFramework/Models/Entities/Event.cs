using System.Collections.Generic;

namespace IngswDev.EntityFramework.Models.Entities
{
    public class Event : IEntity
    {
        public Event()
        {
            TargetDates = new HashSet<EventDate>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool Highlight { get; set; }
        public string ImageUri { get; set; }
        public ICollection<EventDate> TargetDates { get; set; }
    }
}
