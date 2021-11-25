using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs; 
using TekhnelogosInterviewProject.WebUI.Helpers;
using TekhnelogosInterviewProject.WebUI.Models;

namespace TekhnelogosInterviewProject.WebUI.Controllers
{
    [Authorize(Roles = "product_personal,product_manager")]
    public class HomeController : Controller
    {  
        private readonly string _baseAddress;
        public HomeController()
        {
            _baseAddress = ApiService.BaseAddress;
        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("accessToken");

            HelperRestApi<CargoDto> helperForCargo = new HelperRestApi<CargoDto>();
            ViewBag.CargoCount = helperForCargo.GetConnectRestApiForList($"{_baseAddress}/cargo", token).Count;

            HelperRestApi<CustomerDto> helperForCategory = new HelperRestApi<CustomerDto>();
            ViewBag.CustomerCount = helperForCategory.GetConnectRestApiForList($"{_baseAddress}/customer", token).Count;

            HelperRestApi<PersonalDto> helperForPersonal = new HelperRestApi<PersonalDto>();
            ViewBag.PersonalCount = helperForPersonal.GetConnectRestApiForList($"{_baseAddress}/personal", token).Count;

            HelperRestApi<RoleDto> helperForRole = new HelperRestApi<RoleDto>();
            ViewBag.RoleCount = helperForRole.GetConnectRestApiForList($"{_baseAddress}/role", token).Count;

            return View();
        }

    }
}
