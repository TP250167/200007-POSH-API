using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EL.Domain.Entities.Time;
using EL.Service;
using EL.Service.TimeUpService;
using EL.ViewModel.ViewModels.TimeupSeq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL.API.Controllers.TimeSequence
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSeqController : ControllerBase
    {
        private ILoggerManager _logger;

        private readonly ITimeService _timeService;

        public TimeSeqController(ILoggerManager logger, ITimeService timeService)
        {
            _logger = logger;
            _timeService = timeService;
        }

        //[HttpGet("Register")]
        ////  public async Task<IActionResult> Create([FromBody]Decisionloop decisionloop)
        //public async Task<IActionResult> Register([FromBody]Timeup timeup)

        //{
        //  //  ServiceResponse<Timeup> response = new ServiceResponse<Timeup>();
        //      ServiceResponse<Timeup> response = await _timeService.Register(new Timeup { Questionname = request.Questionname, Option1 = request.Option1 }, request.Option2);
        //    if (!response.IsSuccess)
        //    {
        //        return BadRequest(response);
        //    }
        //    return Ok(response);
        //}

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]TimeUpCreateViewModel request)
        {
            ServiceResponse<Timeup> response = await _timeService.Register(new Timeup { Questionname = request.Questionname, QuestionId=request.QuestionId, Option1 = request.Option1, Option2 = request.Option2, Result =request.Result }, request.Option2);
           // ServiceResponse<Timeup> response = await _timeService.Register(new Timeup { Questionname = request.Questionname, Option1 = request.Option1 }, request.Option2);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
          //  response.Data = request.Id;
           // return Ok(response);
           return Ok(request);
        }
    }
}