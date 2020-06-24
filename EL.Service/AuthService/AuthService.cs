using AutoMapper;
using EL.Domain.Entities;
using EL.Repository;
using EL.ViewModel;
using EL.ViewModel.ViewModels.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ILoggerManager _logger;
        //private readonly IConfiguration _configuration;
        private IMapper _mapper;
        private readonly IOptions<AppSetting> _appSetting;

        public AuthService(IAuthRepository authRepository, ILoggerManager logger, IOptions<AppSetting> appSetting,IMapper mapper)
        {
            _authRepository = authRepository;
            _logger = logger;
            _appSetting = appSetting;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserViewModel>> Login(string username, string password)
        {
            ServiceResponse<UserViewModel> serviceResponse = new ServiceResponse<UserViewModel>();
            try
            {

                User user = await _authRepository.GetSingle(x => x.UserName.ToLower().Equals(username.ToLower()));
                if (user == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "User not found.";
                }
                else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Wrong password.";
                }
                else
                {
                    serviceResponse.Data = _mapper.Map<UserViewModel>(user);

                    serviceResponse.Data.Token= CreateToken(user);

                }
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside Login action: {ex.Message}");
            }

            return serviceResponse;
        }


        //public async Task<ServiceResponse<UserViewModel>> ResetPassword(string username, string password)
        //{
        //    ServiceResponse<UserViewModel> serviceResponse = new ServiceResponse<UserViewModel>();
        //    try
        //    {

        //        User user = await _authRepository.GetSingle(x => x.UserName.ToLower().Equals(username.ToLower()));
        //        if (user == null)
        //        {
        //            serviceResponse.IsSuccess = false;
        //            serviceResponse.Message = "User not found.";
        //        }
        //        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //        {
        //            serviceResponse.IsSuccess = false;
        //            serviceResponse.Message = "Wrong password.";
        //        }
        //        else
        //        {
        //            serviceResponse.Data = _mapper.Map<UserViewModel>(user);

        //            serviceResponse.Data.Token = CreateToken(user);

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        serviceResponse.IsSuccess = false;
        //        serviceResponse.Message = ex.Message;
        //        _logger.LogError($"Something went wrong inside Login action: {ex.Message}");
        //    }

        //    return serviceResponse;
        //}


        public async Task<ServiceResponse<User>> Register(User user, string password)
        {
            ServiceResponse<User> serviceResponse = new ServiceResponse<User>();
            try
            {

                if (await UserExists(user.UserName))
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Username already exist";
                    return serviceResponse;
                }
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                serviceResponse.Data = await _authRepository.AddData(user);
                serviceResponse.Message = "Registered successfully";
            }
            catch (Exception ex)
            {

                serviceResponse.IsSuccess = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError($"Something went wrong inside Register action: {ex.Message}");
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<User>> ResetPassword(UserResetViewModel userResetViewModel)
       // public async Task<ServiceResponse<User>> ResetPassword(User user, string password,string Cpassword)
        {
            ServiceResponse<User> serviceResponse = new ServiceResponse<User>();
            try
            {

                User oUser = await _authRepository.GetSingle(userResetViewModel.Id);
                  if(oUser!=null)
                {
                   
                    CreatePasswordHash(userResetViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);

                    oUser.PasswordHash = passwordHash;
                    oUser.PasswordSalt = passwordSalt;
                    //Guid id= Guid.Parse("59c36528 - 5ffc - 4547 - f7d6 - 08d815098ccd");
                   // user.Id = user.Id;
                  //  user.ModifiedOn = "2020/05/05 05:50:06";
                    //user.ModifiedOn =Convert.ToDateTime( DateTime.Now.ToString());
                    //user.Name = user.UserName;

                    serviceResponse.Data = await _authRepository.UpdateData(oUser);
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


        public async Task<bool> UserUpdate(string userName)
        {
          //  var id = "59c36528-5ffc-4547-f7d6-08d815098ccd";

          //   var result1 = _authRepository.GetSingle(a => a.Id.Equals(id)); 
            //endregion
            //  userName = "validusername";
            //ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            //   var tempUser = context.Users.FirstOrDefault(u => u.UserName == username && u.PasswordHash == bytes);
            //if (await _authRepository.GetSingle(u => u.UserName==userName) != null)
            //{
            //    return true;
            //}
            if (await _authRepository.GetSingle(u => u.UserName.ToLower().Equals(userName.ToLower())) != null)
            {
                return false;
            }

            return false;
        }

        public async Task<bool> UserExists(string userName)
        {
            //ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

            if (await _authRepository.GetSingle(u => u.UserName.ToLower().Equals(userName.ToLower())) != null)
            {
                return true;
            }

          

                return false;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_appSetting.Value.Token));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
