using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EL.Domain.Entities.Iccemp;
using EL.Service;
using EL.Service.IccEmpService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpIccController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;

        private IEmpService _IempService;
        public EmpIccController(ILoggerManager logger, IMapper mapper, IEmpService _IempService)
        {
            _logger = logger;
            _mapper = mapper;
            this._IempService = _IempService;
        }
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody]Icc icc)
        {
            ServiceResponse<Icc> serviceResponse = new ServiceResponse<Icc>();
            if (icc == null)
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
            serviceResponse = await _IempService.Createdecisionloop(icc);
            if (serviceResponse == null)
            {
                return BadRequest(serviceResponse);
            }

            serviceResponse.Message = "Schedule Successfully Created";
            return Ok(serviceResponse);

        }
    }

  
}