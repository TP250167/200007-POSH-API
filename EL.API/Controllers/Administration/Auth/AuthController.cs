using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EL.Service;
using EL.Domain.Entities;
using EL.Service.AuthService;
using EL.ViewModel.Auth;
using EL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using EL.ViewModel.ViewModels.Auth;

namespace EL.API.Controllers.Administration
{
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private ILoggerManager _logger;
       
        private readonly IAuthService _authService;

        public AuthController(ILoggerManager logger,IAuthService authService)
        {
            _logger = logger;            
            _authService = authService;
        }
        //public IActionResult Index()
        //{
        //    UserViewModel userViewModel = new UserViewModel();
        //    return Ok(_mapper.Map<User>(userViewModel));
        //}
        [AllowAnonymous]
        [HttpPost("Register")]
        
        public async Task<IActionResult> Register([FromBody]UserRegisterViewModel request)
        {
            ServiceResponse<User> response = await _authService.Register(new User {UserName=request.Username,Name=request.Name },request.Password);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserRegisterViewModel request)
        {
            ServiceResponse<UserViewModel> response = await _authService.Login(
                request.Username, request.Password);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        //[AllowAnonymous]
        //[HttpGet("ResetPassword")]
        //public async Task<IActionResult> ResetPassword([FromBody]UserRegisterViewModel request)
        //{
        //    ServiceResponse<UserViewModel> response = await _authService.ResetPassword(
        //        request.Username, request.Password);
        //    if (!response.IsSuccess)
        //    {
        //        return BadRequest(response);
        //    }
        //    return Ok(response);
        //}

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody]UserResetViewModel request)
        //public async Task<IActionResult> ResetPassword([FromBody]UserRegisterViewModel userResetViewModel)
        {
            // ServiceResponse<User> response = await _authService.ResetPassword(new User { UserName = request.Password }, request.Password,request.Confirmpassword);
         //    ServiceResponse<User> response = await _authService.ResetPassword(new User {Id= userResetViewModel.Id }, userResetViewModel.Password, userResetViewModel.Cpassword);
            ServiceResponse<User> response = await _authService.ResetPassword(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}