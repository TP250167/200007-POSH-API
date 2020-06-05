using System;
using System.Collections.Generic;
using System.Text;
using EL.Domain.Entities;


namespace EL.Repository
{
    public class ScheduleRepository: EntityBaseRepository<Schedule>, IScheduleRepository
    {
        private readonly ELContext context;
        public ScheduleRepository(ELContext context) : base(context)
        {
            this.context = context;
        }
    }
}
