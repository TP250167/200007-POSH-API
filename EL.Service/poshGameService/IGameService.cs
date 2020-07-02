using EL.Domain.GamePosh;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.poshGameService
{
 public   interface IGameService
    {
        Task<ServiceResponse<Game>> Creategame(Game game, string password);
        Task<ServiceResponse<Game>> Createdecisionloop(Game game);

        Task<ServiceResponse<Game>> UpdateGame(Game game);

        ServiceResponse<int> GetGameCount();

        Task<ServiceResponse<IEnumerable<Game>>> GetAllGame();

        Task<ServiceResponse<Game>> GetGameIdAsync(Guid id);

        //    Task<ServiceResponse<GameCount>> Getgamcount();
    }
}
