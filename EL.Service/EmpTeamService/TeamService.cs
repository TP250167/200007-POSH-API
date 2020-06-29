using AutoMapper;
using EL.Domain.Entities;
using EL.Domain.Entities.Team;
using EL.Repository.EmpTeamRepository;
using EL.ViewModel.ViewModels.TeamVM;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.EmpTeamService
{
 public  class TeamService:ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILoggerManager _logger;
        //private readonly IConfiguration _configuration;
        private IMapper _mapper;
        private readonly IOptions<AppSetting> _appSetting;

        public TeamService(ITeamRepository teamRepository, ILoggerManager logger, IOptions<AppSetting> appSetting, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _logger = logger;
            _appSetting = appSetting;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<TeamEmp>> Addteam(TeamEmp teamEmp, string password)
        {
            ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
            try
            {

                //if (await UserExists(teamEmp.TeamempId))
                //{
                //    serviceResponse.IsSuccess = false;
                //    serviceResponse.Message = "Username already exist";
                //    return serviceResponse;
                //}
                //   CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                // user.PasswordHash = passwordHash;
                //   user.PasswordSalt = passwordSalt;
                //timeup.CreatedOn = Convert.ToDateTime(DateTime.Now);

                //timeup.TimeStart = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                //timeup.TimeEnd = DateTime.Now.AddHours(1);

                serviceResponse.Data = await _teamRepository.AddData(teamEmp);
                serviceResponse.Message = "Registered successfully";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                serviceResponse.Message = ex.Message.ToString();
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}");
            }

            return serviceResponse;

        }

      

        public async Task<ServiceResponse<TeamEmp>> Addteam(TeamEmp teamEmp)
        {
            ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
            try
            {

                if (await UserExists(teamEmp.TeamId))
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Teamid already exist";
                    return serviceResponse;
                }
                //   CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                // user.PasswordHash = passwordHash;
                //   user.PasswordSalt = passwordSalt;
                //timeup.CreatedOn = Convert.ToDateTime(DateTime.Now);

                //timeup.TimeStart = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                //timeup.TimeEnd = DateTime.Now.AddHours(1);

                serviceResponse.Data = await _teamRepository.AddData(teamEmp);
                serviceResponse.Message = "Team Registered successfully";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                serviceResponse.Message = ex.Message.ToString();
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}");
            }

            return serviceResponse;

        }
        public async Task<ServiceResponse<TeamEmp>> UpdateTeam(TeamEmp teamEmp)

        {
            ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
            try
            {

                TeamEmp teamUser = await _teamRepository.GetSingle(teamEmp.Id);
                if (teamUser != null)
                {

                    //CreatePasswordHash(userResetViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

                    //oUser.PasswordHash = passwordHash;
                    //oUser.PasswordSalt = passwordSalt;

                    teamUser.TeamId = teamEmp.TeamId;
                    teamUser.Teamtype = teamEmp.Teamtype;

                    serviceResponse.Data = await _teamRepository.UpdateData(teamUser);
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

        public async Task<ServiceResponse<TeamEmp>> UpdateTeam(TeamViewModel teamviewmodel)

        {
            ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
            try
            {

                TeamEmp teamUser = await _teamRepository.GetSingle(teamviewmodel.Id);
                if (teamUser != null)
                {

                    //CreatePasswordHash(userResetViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

                    //oUser.PasswordHash = passwordHash;
                    //oUser.PasswordSalt = passwordSalt;

                    teamUser.TeamId = teamviewmodel.TeamId;
                    teamUser.Teamtype = teamviewmodel.Teamtype;

                    serviceResponse.Data = await _teamRepository.UpdateData(teamUser);
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

        public async Task<bool> UserExists(string userName)
        {
            //ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            if (await _teamRepository.GetSingle(u => u.TeamId.ToLower().Equals(userName.ToLower())) != null)
            {
                return true;
            }



            return false;
        }

        public async Task<ServiceResponse<IEnumerable<TeamEmp>>> GetAllTeam()
        {

            ServiceResponse<IEnumerable<TeamEmp>> serviceResponse = new ServiceResponse<IEnumerable<TeamEmp>>();
            try
            {

                serviceResponse.Data = await _teamRepository.GetAll();

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

        public TeamEmp totalcount()
        {

            //ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
            var total = _teamRepository.Count();
            TeamEmp tc=new TeamEmp();
            tc.count = total;
            ////   List<totalc> count=new List<totalc>
            //Teamcount tc = new Teamcount();
            //tc.count = total;
            //   serviceResponse.Data = total;
            ///  serviceResponse.Data = TeamEmp;
            //   return Teamcount;
          //  return total.ToString();
            return tc;
        }
      //  public async Task<ServiceResponse<TeamEmp>> Getteamcount()
      ////  public async Task<ServiceResponse<IE<TeamEmp>>> Getteamcount()
      //  {
      //    var i= totalcount();
      //      //   ServiceResponse<IEnumerable<TeamEmp>> serviceResponse = new ServiceResponse<IEnumerable<TeamEmp>>();
      //      ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
      //      try
      //      {
      //          var total = _teamRepository.Count();
      //          TeamEmp tc = new TeamEmp();
      //          tc.count = total;
      //          object a = tc.count;
      //          serviceResponse.Data =await a;

      //          //  totalcount();
      //          //   serviceResponse.Data= await _teamRepository.to

      //          //  serviceResponse.Data= _teamRepository.Count();

      //          // serviceResponse.Data=
      //          // var total = await _teamRepository.Count();
      //          //EL.Repository.ELContext
      //          //if (await _teamRepository.Count(u => u.UserName.ToLower().Equals(userName.ToLower())) != null)
      //          //{
      //          //    return true;
      //          //}
      //          //var sql = "SELECT COUNT(*) FROM dbo.Logs";
      //          //var total = el context.Database.SqlQuery<int>(sql).Single();

      //          //  serviceResponse.Data = await _teamRepository.Count.;
      //          //  var query = cont.Set<EventTable>();
      //          //var page = query.OrderBy(e => e.Id)
      //          //                .Select(e => e)
      //          //                .Skip(100).Take(100)
      //          //                .GroupBy(e => new { Total = query.Count() })
      //          //                .FirstOrDefault();


      //          //var _result = serviceResponse.Data;
      //          //if (_result != null && _result.Count() > 0)
      //          //{
      //          //    var treeList = new List<Decisionloop>();
      //          //    var treechildList = new List<Decisionloop>();
      //          //    foreach (var item in _result)
      //          //    {
      //          //        //if (item. == -1)
      //          //    }
      //          //}



      //      }
      //      catch (Exception ex)
      //      {
      //          serviceResponse.IsSuccess = false;
      //          serviceResponse.Message = ex.Message;
      //          _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");

      //      }
      //      return serviceResponse;

      //  }


        //public async Task<ServiceResponse<TeamEmp>> GetTeamIdcountAsync()
        //{
        //    ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
        //    try
        //    {
        //       // var total = _teamRepository.Count();
        //       //  = _teamRepository.Count();
        //       //   serviceResponse.Data = _teamRepository.Count();
        //        //var total = _teamRepository.Count();
        //        //serviceResponse.Data= total;
        //        //  serviceResponse.Data = await _teamRepository.GetSingle(scheduleId);


        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.IsSuccess = false;
        //        serviceResponse.Message = ex.Message;
        //        _logger.LogError($"Something went wrong inside CreateSchedule action: {ex.Message}");


        //    }
        //  //  serviceResponse.Data=to
        //    return serviceResponse;

        //}
        public async Task<ServiceResponse<TeamEmp>> GetTeamIdAsync(Guid teamId)
        {
            ServiceResponse<TeamEmp> serviceResponse = new ServiceResponse<TeamEmp>();
            try
            {


              //  serviceResponse.Data = _teamRepository.Count.ToString();
                //var total = _teamRepository.Count();
                //serviceResponse.Data= total;
                serviceResponse.Data = await _teamRepository.GetSingle(teamId);
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
    }
}
