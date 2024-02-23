﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VistaBasket.Auth.Service.Interface;
using VistaBasket.Auth.Service.Model;
using Hosting = Microsoft.AspNetCore.Hosting;

namespace VistaBasket.Auth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ResponseDto _response;
        private readonly Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IAuthService _authService;
        public AuthController(Hosting.IHostingEnvironment hostingEnvironment, IAuthService authService)
        {
            _response = new ResponseDto();
            _hostingEnvironment = hostingEnvironment;
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto loginModel)
        {
            var loginResponse = await _authService.Login(loginModel);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequestDto registerRequest)
        {
            var errorMessage = await _authService.Register(registerRequest);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            //await _messageBus.PublishMessage(model.Email, _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue"));
            return Ok(_response);
        }
    }
}
