using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities
{
    public class Schedule : IBaseEntity
    {
        public Schedule()
        {
            Attendees = new List<Attendee>();
            Creator = new User();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Location { get; set; }
        public ScheduleType Type { get; set; }
        public ScheduleStatus Status { get; set; }
        public Int64 CreatedBy { get; set; }
        public Int64 ModifiedBy { get; set; }
        public User Creator { get; set; }
        public User Modifier { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
    }
}
