using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities
{
    public class ScheduleMap
    {
        public ScheduleMap(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("SCHEDULE_TBL");

            builder
                .Property(s => s.CreatedOn)
                .IsRequired().HasColumnName("CREATED_ON");

         
            builder
                .Property(s => s.ModifiedOn)
                .HasDefaultValue(DateTime.Now);

            builder
                .Property(s => s.Type)
                .HasDefaultValue(ScheduleType.Work);

            builder
                .Property(s => s.Status)
                .HasDefaultValue(ScheduleStatus.Valid);

            builder
                .HasOne(s => s.Creator)
                .WithMany(c => c.SchedulesCreated);

            //modelBuilder.Entity<User>()
            //    .ToTable("User");

            //modelBuilder.Entity<User>()
            //    .Property(u => u.Name)
            //    .HasMaxLength(100)
            //    .IsRequired();

            //modelBuilder.Entity<Attendee>()
            //    .ToTable("Attendee");

            //modelBuilder.Entity<Attendee>()
            //    .HasOne(a => a.User)
            //    .WithMany(u => u.SchedulesAttended)
            //    .HasForeignKey(a => a.UserId);

            //modelBuilder.Entity<Attendee>()
            //    .HasOne(a => a.Schedule)
            //    .WithMany(s => s.Attendees)
            //    .HasForeignKey(a => a.ScheduleId);
        }
    }
}
