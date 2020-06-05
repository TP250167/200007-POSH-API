using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities
{
    public class AttendeeMap
    {
        public AttendeeMap(EntityTypeBuilder<Attendee> builder)
        {
            builder
            .ToTable("ATTENDEE_TBL");

            builder
                .HasOne(a => a.User)
                .WithMany(u => u.SchedulesAttended)
                .HasForeignKey(a => a.UserId);

            builder
                .HasOne(a => a.Schedule)
                .WithMany(s => s.Attendees)
                .HasForeignKey(a => a.ScheduleId);

        }
    }
}
