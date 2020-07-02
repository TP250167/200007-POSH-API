using EL.Domain.Entities;
using EL.ViewModel;
using EL.ViewModel.ViewModels.Auth;
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
        //Task<ServiceResponse<UserViewModel>> ResetPassword(string username, string password);

       // Task<ServiceResponse<User>> ResetPassword(User user, string password,string Cpassword);
        Task<ServiceResponse<User>> ResetPassword(UserResetViewModel userResetViewModel);

        Task<bool> UserExists(string username);

        

    }
}
