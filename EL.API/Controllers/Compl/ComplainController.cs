using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EL.Domain.Entities.comp;
using EL.Service;
using EL.Service.ComplainService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL.API.Controllers.Compl
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;

        private ICompService _ICompService;

        public ComplainController(ILoggerManager logger, IMapper mapper, ICompService _ICompService)
        {
            _logger = logger;
            _mapper = mapper;
            this._ICompService = _ICompService;
        }
        //[AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]Complain complain)
        {
            ServiceResponse<Complain> serviceResponse = new ServiceResponse<Complain>();
            if (complain == null)
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
            serviceResponse = await _ICompService.Createdecisionloop(complain);
            if (serviceResponse == null)
            {
                return BadRequest(serviceResponse);
            }

            serviceResponse.Message = "Schedule Successfully Created";
            return Ok(serviceResponse);

        }
    }
}