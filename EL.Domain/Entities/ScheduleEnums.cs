using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities
{
    public enum ScheduleType
    {
        RecurringDaily = 1,
        OnlyOnce = 2,
        Work=3
        
    }

    public enum ScheduleStatus
    {
        Valid = 1,
        Cancelled = 2
    }
}
