using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities
{
    public class Attendee:IBaseEntity
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }    
        public Guid ScheduleId { get; set; }
        public User User { get; set; }
        public Schedule Schedule { get; set; }
    }
}
