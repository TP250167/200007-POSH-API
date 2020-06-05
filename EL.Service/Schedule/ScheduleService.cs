using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EL.Domain.Entities;
using EL.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using EL.ViewModel;

namespace EL.Service
{
    public class ScheduleService:IScheduleService
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IScheduleRepository _scheduleRepository;
        //Used to find current login user userid
        private readonly IHttpContextAccessor _httpContextAccessor;



        public ScheduleService(IScheduleRepository scheduleRepository, ILoggerManager logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _scheduleRepository = scheduleRepository;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Schedule>> CreateSchedule(Schedule schedule)
        {
            ServiceResponse<Schedule> serviceResponse = new ServiceResponse<Schedule>();
            try
            {
                ScheduleViewModel scheduleView = new ScheduleViewModel();
                //we can use AutoMapper here
             Schedule sc=   _mapper.Map<Schedule>(scheduleView);
                serviceResponse.Data = await _scheduleRepository.AddData(schedule);
                serviceResponse.Message = "Schedule Created";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }

            return serviceResponse;
            
        }

        public async Task<ServiceResponse<IEnumerable<Schedule>>> GetAllSchedulesAsync()
        {
            ServiceResponse<IEnumerable<Schedule>> serviceResponse = new ServiceResponse<IEnumerable<Schedule>>();
            try
            {
                //IEnumerable<Schedule> schedules= await _scheduleRepository.GetAll();
                //IEnumerable<ScheduleViewModel> scheduleViewModels = _mapper.Map<IEnumerable<ScheduleViewModel>>(schedules);
                serviceResponse.Data = await _scheduleRepository.GetAll();
                //serviceResponse.Data = scheduleViewModels;

            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Schedule>> GetScheduleByIdAsync(Guid scheduleId)
        {
            ServiceResponse<Schedule> serviceResponse = new ServiceResponse<Schedule>();
            try
            {
                serviceResponse.Data = await _scheduleRepository.GetSingle(scheduleId);

            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");


            }
            return serviceResponse;
            
        }

        // Method Return Current User Id
        private Guid GetUserId() => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
