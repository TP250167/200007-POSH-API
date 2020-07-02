using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EL.Domain.GamePosh;
using EL.Service;
using EL.Service.poshGameService;
using EL.ViewModel.ViewModels.Game;
using EL.ViewModel.ViewModels.GameVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EL.API.Controllers.PoshGame
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private ILoggerManager _logger;

        private readonly IGameService _gameService;

        public GameController(ILoggerManager logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody]GameViewModel gameAddViewModel)
        {


            ServiceResponse<Game> response = await _gameService.Creategame(new Game { GameName = gameAddViewModel.Name, Description = gameAddViewModel.Description, MaxScore = gameAddViewModel.MaxScore, Noofcases = gameAddViewModel.Noofcases, Duration = gameAddViewModel.Duration ,Active=gameAddViewModel.Active}, gameAddViewModel.Active);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [AllowAnonymous]
        [HttpPost("UpdateGame")]

        public async Task<IActionResult> UpdateGame([FromBody]GameViewModel gameAddViewModel)
        {
            ServiceResponse<Game> response = await _gameService.UpdateGame(new Game {Id=gameAddViewModel.Id, GameName = gameAddViewModel.Name, Description = gameAddViewModel.Description, MaxScore = gameAddViewModel.MaxScore, Noofcases = gameAddViewModel.Noofcases, Duration = gameAddViewModel.Duration, Active = gameAddViewModel.Active });

            //ServiceResponse<Game> response = await _gameService.Creategame(new Game { GameName = gameAddViewModel.Name, Description = gameAddViewModel.Description, MaxScore = gameAddViewModel.MaxScore, Noofcases = gameAddViewModel.Noofcases, Duration = gameAddViewModel.Duration, Active = gameAddViewModel.Active }, gameAddViewModel.Active);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
          
        }

        [HttpGet("GetGameId/{id:Guid}")]
        //  [HttpGet("{id}", Name = "DecisionloopByIds")]
        public async Task<IActionResult> GetGameId(Guid id)
        {
            // Guid result = "";
            if (id == null)
            { return BadRequest(); }
            //  result = await postRepository.DeletePost(postId);
            ServiceResponse<Game> serviceResponse = new ServiceResponse<Game>();

            var teamId = await _gameService.GetGameIdAsync(id);
            if (teamId == null)
            {
                _logger.LogError($"Team with id: {id}, hasn't been found in db.");

                return NotFound(serviceResponse);
            }

            _logger.LogInfo($"Returned Team with id: {id}");
            return Ok(teamId);
        }


        [HttpGet("GetGameCount")]
        public  IActionResult GetGameCount()
        {
          //  ServiceResponse<IEnumerable<Game>> serviceResponse = new ServiceResponse<IEnumerable<Game>>();
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            serviceResponse =  _gameService.GetGameCount();
            if (serviceResponse==null)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);

        }



        [HttpGet("GetGame")]
        public async Task<IActionResult> GetGame()
        {
             ServiceResponse<IEnumerable<Game>> serviceResponse = new ServiceResponse<IEnumerable<Game>>();
          //  ServiceResponse<Game> serviceResponse = new ServiceResponse<Game>();
            serviceResponse = await _gameService.GetAllGame();
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }

            return Ok(serviceResponse);

        }





        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]Game game)
        {
            ServiceResponse<Game> serviceResponse = new ServiceResponse<Game>();
            if (game == null)
            {
                _logger.LogError("Game object sent from client is null.");
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Game object sent from client is null";
                return BadRequest(serviceResponse);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid schedule object sent from client.");
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Invalid schedule object sent from client.";
                return BadRequest(serviceResponse);
            }
            serviceResponse = await _gameService.Createdecisionloop(game);
            if (serviceResponse == null)
            {
                return BadRequest(serviceResponse);
            }

            serviceResponse.Message = "Schedule Successfully Created";
            return Ok(serviceResponse);

        }
    }
}