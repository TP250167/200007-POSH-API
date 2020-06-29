using EL.Domain.Entities.Team;
using EL.ViewModel.ViewModels.TeamVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.EmpTeamService
{
  public  interface ITeamService
    {
        Task<ServiceResponse<TeamEmp>> Addteam(TeamEmp teamEmp, string password);

        Task<ServiceResponse<TeamEmp>> Addteam(TeamEmp teamEmp);
        Task<ServiceResponse<TeamEmp>> UpdateTeam(TeamViewModel teamviewmodel);
        Task<ServiceResponse<TeamEmp>> UpdateTeam(TeamEmp teamEmp);

        Task<ServiceResponse<IEnumerable<TeamEmp>>> GetAllTeam();
        //   Task<ServiceResponse<IEnumerable<TeamEmp>>> Getteamcount();
     //   Task<ServiceResponse<TeamEmp>> Getteamcount();
      //  public Task<ServiceResponse<TeamEmp>> Getteamcount();
     //   Getteamcount

        Task<ServiceResponse<TeamEmp>> GetTeamIdAsync(Guid id);
      //  Task<ServiceResponse<TeamEmp>> GetTeamIdcountAsync(Guid id);

        



    }
}
