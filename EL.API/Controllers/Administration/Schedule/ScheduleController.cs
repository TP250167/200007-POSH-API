using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;
using EL.Service;
using EL.Domain.Entities;

namespace EL.API.Controllers.Administration

{
    [Route("api/schedule")]
    public class ScheduleController : Controller
    {

        private readonly IScheduleService _scheduleService;
        private readonly ILoggerManager _logger;

        public ScheduleController(IScheduleService scheduleService, ILoggerManager logger)
        {

            _scheduleService = scheduleService;
            _logger = logger;
        }

        #region Get Method
        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            ServiceResponse<IEnumerable<Schedule>> serviceResponse = new ServiceResponse<IEnumerable<Schedule>>();

            serviceResponse = await _scheduleService.GetAllSchedulesAsync();
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);

        }
        [HttpGet("{id}", Name = "ScheduleById")]
        public async Task<IActionResult> GetScheduleById(Guid id)
        {
            ServiceResponse<Schedule> serviceResponse = new ServiceResponse<Schedule>();

            var schedule = await _scheduleService.GetScheduleByIdAsync(id);
            if (schedule == null)
            {
                _logger.LogError($"Schedule with id: {id}, hasn't been found in db.");

                return NotFound(serviceResponse);
            }

            _logger.LogInfo($"Returned Schedule with id: {id}");
            return Ok(schedule);



        }
        #endregion

        #region Post Methods

        [HttpPost("Createschedule")]
        public async Task<IActionResult> Create([FromBody]Schedule schedule)
        {
            ServiceResponse<Schedule> serviceResponse = new ServiceResponse<Schedule>();
            if (schedule == null)
            {
                _logger.LogError("schedule object sent from client is null.");
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "schedule object sent from client is null";
                return BadRequest(serviceResponse);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid schedule object sent from client.");
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Invalid schedule object sent from client.";
                return BadRequest(serviceResponse);
            }
            serviceResponse = await _scheduleService.CreateSchedule(schedule);
            if (serviceResponse == null)
            {
                return BadRequest(serviceResponse);
            }          
            
            serviceResponse.Message = "Schedule Successfully Created";
            return Ok(serviceResponse);

        }
        #endregion

    }

}
