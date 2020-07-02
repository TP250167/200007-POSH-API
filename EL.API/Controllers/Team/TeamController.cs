using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EL.Domain.Entities.Team;
using EL.Service;
using EL.Service.EmpTeamService;
using EL.ViewModel.ViewModels.TeamVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL.API.Controllers.Team
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        //private ILoggerManager _logger;
        //private IMapper _mapper;

        //private ITeamService _IteamService;

        //public TeamController(ILoggerManager logger, IMapper mapper, ITeamService _teamService)
        //{
        //    _logger = logger;
        //    _mapper = mapper;
        //    this._IteamService = _teamService;
        //}
        private ILoggerManager _logger;

        private readonly ITeamService _teamService;

        public TeamController(ILoggerManager logger, ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }


        [AllowAnonymous]
        [HttpPost("Createteam")]
        public async Task<IActionResult> Createteam([FromBody]TeamViewModel teamviewmodel)
        {
            ServiceResponse<TeamEmp> response = await _teamService.Addteam(new TeamEmp {Id=teamviewmodel.Id, Teamempname = teamviewmodel.Teamempname,  TeamDescription = teamviewmodel.TeamDescription, TeamId = teamviewmodel.TeamId, Teamtype = teamviewmodel.Teamtype , Active =teamviewmodel.Active});
            // ServiceResponse<Timeup> response = await _timeService.Register(new Timeup { Questionname = request.Questionname, Option1 = request.Option1 }, request.Option2);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            //  response.Data = request.Id;
             return Ok(response);
           // return Ok(teamviewmodel);
        }

        [HttpPost("Updateteam")]
        public async Task<IActionResult> Updateteam([FromBody]TeamViewModel teamviewmodel)
        {
            ServiceResponse<TeamEmp> response = await _teamService.UpdateTeam(new TeamEmp { Id = teamviewmodel.Id, Teamempname = teamviewmodel.Teamempname, TeamDescription = teamviewmodel.TeamDescription, TeamId = teamviewmodel.TeamId, Teamtype = teamviewmodel.Teamtype, Active = teamviewmodel.Active });
            // ServiceResponse<Timeup> response = await _timeService.Register(new Timeup { Questionname = request.Questionname, Option1 = request.Option1 }, request.Option2);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            //  response.Data = request.Id;
            return Ok(response);
            // return Ok(teamviewmodel);
        }

        [HttpGet("Getteam")]
        public async Task<IActionResult> Getteam()
        {
            ServiceResponse<IEnumerable<TeamEmp>> serviceResponse = new ServiceResponse<IEnumerable<TeamEmp>>();

            serviceResponse = await _teamService.GetAllTeam();
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);

        }

        //[HttpGet("Getteamcount")]
        //public async Task<IActionResult> Getteamcount()
        //{
        //    ServiceResponse<IEnumerable<TeamEmp>> serviceResponse = new ServiceResponse<IEnumerable<TeamEmp>>();

        //    serviceResponse = await _teamService.Getteamcount();
        //    if (serviceResponse.Data == null)
        //    {
        //        return NotFound(serviceResponse);
        //    }

        //    return Ok(serviceResponse);

        //}




        //  [HttpGet("GetDecisionloopId/{id:Guid}/{Result}/{SubstoryId}/{QuestionId}")]
        [HttpGet("GetTeamId/{id:Guid}")]
        //  [HttpGet("{id}", Name = "DecisionloopByIds")]
        public async Task<IActionResult> GetTeamId(Guid id)
        {
            // Guid result = "";
            if (id == null)
            { return BadRequest(); }
            //  result = await postRepository.DeletePost(postId);
            ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();

            var teamId = await _teamService.GetTeamIdAsync(id);
            if (teamId == null)
            {
                _logger.LogError($"Team with id: {id}, hasn't been found in db.");

                return NotFound(serviceResponse);
            }

            _logger.LogInfo($"Returned Team with id: {id}");
            return Ok(teamId);
        }


        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]TeamEmp teamEmp)
        {
            ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
            if (teamEmp == null)
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
            serviceResponse = await _teamService.Addteam(teamEmp);
            if (serviceResponse == null)
            {
                return BadRequest(serviceResponse);
            }

         //   serviceResponse.Message = "Schedule Successfully Created";
            return Ok(serviceResponse);

        }
    }
}