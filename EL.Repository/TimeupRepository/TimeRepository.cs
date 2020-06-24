using EL.Domain.Entities.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Repository.TimeupRepository
{
  public  class TimeRepository : EntityBaseRepository<Timeup>, ITimeRepository
    {
        public TimeRepository(ELContext context) : base(context)
        {

        }
    }
}
