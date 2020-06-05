using EL.Domain.Entities;
using EL.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<User>> Register(User user, string password);
        Task<ServiceResponse<UserViewModel>> Login(string username, string password);
        Task<bool> UserExists(string username);
        
    }
}
