using EL.Domain.Entities.Time;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.TimeUpService
{
  public  interface ITimeService
    {

        Task<ServiceResponse<Timeup>> Register(Timeup timeup, string password);
    }
}
