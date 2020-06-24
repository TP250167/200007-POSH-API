using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL.Domain.Entities;
using EL.Domain.Entities.DecisionloopEntity;
using EL.Domain.Entities.Time;
using EL.Domain.Entities.comp;
using EL.Domain.Entities.Iccemp;

namespace EL.Repository
{
    public class ELContext:DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Decisionloop> Decisionloops { get; set; }
        public DbSet<Timeup> Timeups { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Icc> Iccs { get; set; }
        public ELContext(DbContextOptions<ELContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
            new ScheduleMap(modelBuilder.Entity<Schedule>());
            new UserMap(modelBuilder.Entity<User>());
            new AttendeeMap(modelBuilder.Entity<Attendee>());
            new DecisionloopMap(modelBuilder.Entity<Decisionloop>());
            new TimeupMap(modelBuilder.Entity<Timeup>());
            new IccMap(modelBuilder.Entity<Icc>());
            new ComplainMap(modelBuilder.Entity<Complain>());

        }
    }
}
