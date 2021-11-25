using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Entity.DTOs;
using TekhnelogosInterviewProject.Entity.HelperConcrete;
using TekhnelogosInterviewProject.Helper.Response; 

namespace TekhnelogosInterviewProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IPersonalService _personalService;

        public AuthController(IPersonalService personalService)
        {
            _personalService = personalService;
        }

        //[HttpPost("{login}")]
        //public async Task<IActionResult> Login(LoginDto login)
        //{
        //    var response = await _personalService.GetPersonalByUsernameAndPasswordAsync(login.UserName, login.UserPassword);
        //    if (response.Success)
        //    {
        //        return Ok(response.Content);
        //    }

        //    return BadRequest(response.ErrorMessage);
        //}

        [HttpPost("{token}")]
        public async Task<IActionResult> Accesstoken(LoginDto loginDto)
        {
            var response = await _personalService.CreateAccessToken(loginDto.UserName, loginDto.UserPassword);

            if (response.Success)
            {
                return Ok(response.Content);
            }
            else
            {
                return BadRequest(response.ErrorMessage);
            }
        }

    }
}
