using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EL.Domain.Entities;
using EL.Domain.Entities.DecisionloopEntity;
using EL.Service;
using EL.Service.DecisionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL.API.Controllers.Decis
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecisionController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;

        private IDecisionloopService _IDecisionloopService;

        public DecisionController(ILoggerManager logger, IMapper mapper, IDecisionloopService _IDecisionloopService)
        {
            _logger = logger;
            _mapper = mapper;
            this._IDecisionloopService = _IDecisionloopService;
        }

        // #region Get Method
    
        [HttpGet("GetAllDecision")]
        public async Task<IActionResult> GetAllDecision()
        {
            ServiceResponse<IEnumerable<Decisionloop>> serviceResponse = new ServiceResponse<IEnumerable<Decisionloop>>();

            serviceResponse = await _IDecisionloopService.GetAllDecisionloopAsync();
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);

        }

        [HttpGet("GetAllDecisionquestion")]
        public async Task<IActionResult> GetAllDecisionq()
        {
            ServiceResponse<IEnumerable<Decisionloop>> serviceResponse = new ServiceResponse<IEnumerable<Decisionloop>>();

            serviceResponse = await _IDecisionloopService.GetAllDecisionloopAsynca();
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);

        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]Decisionloop decisionloop)
        {
            ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();
            if (decisionloop == null)
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
            serviceResponse = await _IDecisionloopService.Createdecisionloop(decisionloop);
            if (serviceResponse == null)
            {
                return BadRequest(serviceResponse);
            }

            serviceResponse.Message = "Schedule Successfully Created";
            return Ok(serviceResponse);

        }

        
        //public async Task<IActionResult> Createshed([FromBody]Schedule decisionloopa)
        //{
        //    ServiceResponse<Schedule> serviceResponse = new ServiceResponse<Schedule>();
        //    if (decisionloopa == null)
        //    {
        //        _logger.LogError("schedule object sent from client is null.");
        //        serviceResponse.IsSuccess = false;
        //        serviceResponse.Message = "schedule object sent from client is null";
        //        return BadRequest(serviceResponse);
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        _logger.LogError("Invalid schedule object sent from client.");
        //        serviceResponse.IsSuccess = false;
        //        serviceResponse.Message = "Invalid schedule object sent from client.";
        //        return BadRequest(serviceResponse);
        //    }
        // //   serviceResponse = await _IDecisionloopService.Createdecisionloop(decisionloopa);
        //    if (serviceResponse == null)
        //    {
        //        return BadRequest(serviceResponse);
        //    }

        //    serviceResponse.Message = "Schedule Successfully Created";
        //    return Ok(serviceResponse);

        //}





        //  [HttpGet("{id}", Name = "DecisionloopById")]
        //  [HttpGet("GetDecisionloopId/{id}")]
        //   [HttpGet("GetDecisionloopId")]
        [HttpGet("GetDecisionloopId/{id:Guid}/{Result}/{SubstoryId}/{QuestionId}")]
     //   [HttpGet("GetDecisionloopId/{Year}/{Result}")]
        public async Task<IActionResult> GetDecisionloopId(Guid id,string Result, int SubstoryId, int QuestionId)
        {
            ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();

            var schedule = await _IDecisionloopService.GetDecisionloopAnsIdAsync(id,Result, SubstoryId, QuestionId);
            if (schedule == null)
            {
                _logger.LogError($"DecisionloopId with id: {id}, hasn't been found in db.");

                return NotFound(serviceResponse);
            }

            _logger.LogInfo($"Returned Schedule with id: {id}");
            return Ok(schedule);



        }

      //  [HttpGet("{Result}")]
        //[HttpGet("{id}", Name = "Result")]
        //public async Task<IActionResult> AnswerDecisionloopId(Guid id)
        //{
        //    ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();

        //    var schedule = await _IDecisionloopService.GetDecisionloopIdAsync(id);
        //    if (schedule == null)
        //    {
        //        _logger.LogError($"Question with id: {id}, hasn't been found in db.");

        //        return NotFound(serviceResponse);
        //    }

        //    _logger.LogInfo($"Returned Decision with id: {id}");
        //    return Ok(schedule);



        //}

        //[HttpPost("{id}", Name = "DecisionloopByIds")]
        //public async Task<IActionResult> DeleteDecisionloopId(Guid id)
        //{
        //    // Guid result = "";
        //    if (id == null)
        //    { return BadRequest(); }
        //    //  result = await postRepository.DeletePost(postId);
        //    ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();

        //    var schedule = await _IDecisionloopService.GetDecisionloopIdAsync(id);
        //    if (schedule == null)
        //    {
        //        _logger.LogError($"Schedule with id: {id}, hasn't been found in db.");

        //        return NotFound(serviceResponse);
        //    }

        //    _logger.LogInfo($"Returned Schedule with id: {id}");
        //    return Ok(schedule);



        //}
        [HttpPost("{update}")]
        public async Task<IActionResult> Update([FromBody]Decisionloop decisionloop)
        {
            ServiceResponse<Decisionloop> serviceResponse = new ServiceResponse<Decisionloop>();
            if (decisionloop == null)
            {
                _logger.LogError("Decision object sent from client is null.");
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Decision object sent from client is null";
                return BadRequest(serviceResponse);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid Decision object sent from client.");
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Invalid Decision object sent from client.";
                return BadRequest(serviceResponse);
            }
            serviceResponse = await _IDecisionloopService.Updatedecisionloop(decisionloop);
            if (serviceResponse == null)
            {
                return BadRequest(serviceResponse);
            }

            serviceResponse.Message = "Decision Successfully Updated";
            return Ok(serviceResponse);

        }



    }
}
