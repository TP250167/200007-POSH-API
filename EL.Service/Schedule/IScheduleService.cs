using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EL.Domain.Entities;

namespace EL.Service
{
    public interface IScheduleService
    {
         Task<ServiceResponse<IEnumerable<Schedule>>> GetAllSchedulesAsync();
         Task<ServiceResponse<Schedule>> GetScheduleByIdAsync(Guid id);
         Task<ServiceResponse<Schedule>> CreateSchedule(Schedule schedule);
    }
}
