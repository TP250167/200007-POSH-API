using AutoMapper;
using EL.Domain.Entities;
using EL.Domain.Entities.Team;
using EL.Domain.GamePosh;
using EL.Repository.poshGameRepository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.poshGameService
{
   public class GameService:IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly ILoggerManager _logger;
        //private readonly IConfiguration _configuration;
        private IMapper _mapper;
        private readonly IOptions<AppSetting> _appSetting;

        public GameService(IGameRepository gameRepository, ILoggerManager logger, IOptions<AppSetting> appSetting, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _logger = logger;
            _appSetting = appSetting;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Game>> Creategame(Game game, string password)
        {
            ServiceResponse<Game> serviceResponse = new ServiceResponse<Game>();
            try
            {
                // game.Id =Guid.Parse("-6c54s");
                //  Game oUser = await _gameRepository.GetSingle(game.Id);
                //   oUser.Name = game.Name;
                // oUser.ModifiedOn
               // game.ModifiedOn == ;
                //game.CreatedOn = DateTime.Now;
                //serviceResponse.Data = await _gameRepository.AddData(game);
                serviceResponse.Data = await _gameRepository.AddData(game);
                serviceResponse.Message = "Posh Game Created";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<Game>> GetGameIdAsync(Guid teamId)
        {
            ServiceResponse<Game> serviceResponse = new ServiceResponse<Game>();
            try
            {


                //  serviceResponse.Data = _teamRepository.Count.ToString();
                //var total = _teamRepository.Count();
                //serviceResponse.Data= total;
                serviceResponse.Data = await _gameRepository.GetSingle(teamId);
                serviceResponse.IsSuccess = true;
                serviceResponse.Message = "Valid Team Id:" + teamId;


            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside Get TeamId action: {ex.Message}");


            }
            return serviceResponse;

        }


        public async Task<ServiceResponse<IEnumerable<Game>>> GetAllGame()
        {

            ServiceResponse<IEnumerable<Game>> serviceResponse = new ServiceResponse<IEnumerable<Game>>();
            try
            {
                //var result=cont
                //context.
                //if (await _gameRepository.(u => u.UserName.ToLower().Equals(userName.ToLower())) != null)

                   serviceResponse.Data = await _gameRepository.GetAll();

                //var _result = serviceResponse.Data;
                //if (_result != null && _result.Count() > 0)
                //{
                //    var treeList = new List<Decisionloop>();
                //    var treechildList = new List<Decisionloop>();
                //    foreach (var item in _result)
                //    {
                //        //if (item. == -1)
                //    }
                //}



            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }
            return serviceResponse;

        }




        public async Task<ServiceResponse<Game>> UpdateGame(Game game)

        {
            ServiceResponse<Game> serviceResponse = new ServiceResponse<Game>();
            try
            {

                Game gameexit = await _gameRepository.GetSingle(game.Id);
                if (gameexit != null)
                {

                    //CreatePasswordHash(userResetViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    gameexit.Active = game.Active;
                    gameexit.BackgroundAudio = game.BackgroundAudio;
                    gameexit.Description = game.Description;
                    gameexit.Duration = game.Duration;
                    gameexit.GameName = game.GameName;
                    gameexit.GameType = game.GameType;
                    gameexit.Objective = game.Objective;
                    //gameexit.GameType = game.GameType;
                    //gameexit.GameType = game.GameType;
                    //gameexit.GameType = game.GameType;
                    //oUser.PasswordHash = passwordHash;
                    //oUser.PasswordSalt = passwordSalt;

                    //teamUser.TeamId = teamviewmodel.TeamId;
                    //teamUser.Teamtype = teamviewmodel.Teamtype;

                    serviceResponse.Data = await _gameRepository.UpdateData(game);
                    serviceResponse.Message = "Update successfully";
                    serviceResponse.Data = null;
                }
                else
                {
                    serviceResponse.Message = "User not found";
                    serviceResponse.IsSuccess = false;

                }



            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}");
            }

            return serviceResponse;

        }
        public TeamEmp totalcount()
        {

            ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
            var total = _gameRepository.Count();
            TeamEmp tc = new TeamEmp();
            tc.count = total;
            ////   List<totalc> count=new List<totalc>
            //Teamcount tc = new Teamcount();
            //tc.count = total;
            //   serviceResponse.Data = total;
            ///  serviceResponse.Data = TeamEmp;
            //   return Teamcount;
            //  return total.ToString();
            serviceResponse.Data = tc;
            return tc;
        }
        public  ServiceResponse<int> GetGameCount()
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            try
            {
              //  var i = totalcount();
             //   totalcount();
                //  serviceResponse.Message = "Total count:" + i;


              //  ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
                var total =  _gameRepository.Count();
                //GameCount tc1 = new GameCount();
                //Game tc11 = new Game();
                //tc11.count = total;
                serviceResponse.Data = total;
                serviceResponse.Message = "Game Total Count:" + total;

                //var i = totalcount();

                //TeamEmp tc = new TeamEmp();
                //        // tc.count = i;
                //         object a = tc.count;
                //      serviceResponse.Data = a;


                //  Complaint complaint1 = new Complaint();
                //we can use AutoMapper here
                //   Complaint sc = _mapper.Map<Complaint>(complaint1);
                //  game.ModifiedOn =Convert.ToDateTime(DateTime.Now.ToString());
                //  game.ModifiedOn = game.ModifiedOn;
                //game.CreatedOn = game.ModifiedOn;
                // serviceResponse.Data = await _gameRepository.AddData(game);
                //  serviceResponse.Message = "Schedule Created";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                //  serviceResponse.Message = ex.Message;
                serviceResponse.Message = ex.ToString();
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<Game>> Createdecisionloop(Game game)
        {
            ServiceResponse<Game> serviceResponse = new ServiceResponse<Game>();
            try
            {
                //  Complaint complaint1 = new Complaint();
                //we can use AutoMapper here
                //   Complaint sc = _mapper.Map<Complaint>(complaint1);
              //  game.ModifiedOn =Convert.ToDateTime(DateTime.Now.ToString());
              //  game.ModifiedOn = game.ModifiedOn;
                //game.CreatedOn = game.ModifiedOn;
                serviceResponse.Data = await _gameRepository.AddData(game);
                serviceResponse.Message = "Schedule Created";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                //  serviceResponse.Message = ex.Message;
                serviceResponse.Message = ex.ToString();
                _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

            }

            return serviceResponse;

        }

    }
}
