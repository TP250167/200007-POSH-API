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

namespace EL.API.Controllers.Administration
{
    [Route("api/auth")]
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
    }
}