using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs;
using TekhnelogosInterviewProject.Entity.HelperConcrete;
using TekhnelogosInterviewProject.WebUI.Helpers;
using TekhnelogosInterviewProject.WebUI.ValidationRules;

namespace TekhnelogosInterviewProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly string _baseAddress; 
        public LoginController()
        {
            _baseAddress = ApiService.BaseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginDto item)
        {

            LoginValidator loginValidator = new LoginValidator();
            ValidationResult resultValidation = loginValidator.Validate(item);

            if (resultValidation.IsValid)
            {
                HelperRestApi<TokenResultDto> helper = new HelperRestApi<TokenResultDto>();
                var resultFromAuthLogin = helper.AuthConnectRestApi($"{_baseAddress}/auth/token", item);

                if (resultFromAuthLogin.Token != null)
                {

                    HelperRestApi<PersonalWithRoleDto> helperForProduct = new HelperRestApi<PersonalWithRoleDto>();
                    var personal = helperForProduct.GetConnectRestApi(String.Format($"{_baseAddress}/personal/{resultFromAuthLogin.PersonalId}/roles"), resultFromAuthLogin.Token);

                    HttpContext.Session.SetString("accessToken", resultFromAuthLogin.Token); // Token Session

                    if (personal != null)
                    {
                        var claims = new List<Claim>
                          {
                              new Claim(ClaimTypes.Name,$"{personal.PersonalName} {personal.PersonalSurname}"),
                              new Claim(ClaimTypes.Role,personal.Role.RoleName)
                          };

                        var identity = new ClaimsIdentity(
                         claims, CookieAuthenticationDefaults.AuthenticationScheme
                         );

                        var principle = new ClaimsPrincipal(identity);
                        var props = new AuthenticationProperties();
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle, props).Wait();
                    }

                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in resultValidation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View();
        }
         
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
