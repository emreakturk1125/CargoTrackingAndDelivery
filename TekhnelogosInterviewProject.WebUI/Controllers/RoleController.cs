using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using TekhnelogosInterviewProject.Entity.DTOs;
using TekhnelogosInterviewProject.WebUI.Helpers;

namespace TekhnelogosInterviewProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly string _baseAddress; 
        public RoleController()
        {
            _baseAddress = ApiService.BaseAddress;
        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<RoleDto> helper = new HelperRestApi<RoleDto>();
            var response = helper.GetConnectRestApiForList($"{_baseAddress}/role", token);

            return View(response);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(RoleDto item)
        { 
            item.IsActive = true;

            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<RoleDto> helper = new HelperRestApi<RoleDto>();
            var result = helper.PostConnectRestApi($"{_baseAddress}/role", token, item);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("AddRole", "Role");

        }


        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<RoleDto> helperForCustomer = new HelperRestApi<RoleDto>();
            var result = helperForCustomer.GetConnectRestApi(String.Format($"{ _baseAddress}/role/{id}"), token);

            if (result != null)
            {
                return View(result);
            }

            return RedirectToAction("Index", "Category");

        }

        [HttpPost]
        public IActionResult EditRole(RoleDto item)
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<RoleDto> helperForRole = new HelperRestApi<RoleDto>();
            var result = helperForRole.PutConnectRestApi(String.Format($"{ _baseAddress}/role"), token, item);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("EditRole", "Role", item.RoleId);

        }

        public IActionResult DeleteRole(int id)
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<RoleDto> helperForRole= new HelperRestApi<RoleDto>();
            var result = helperForRole.DeleteConnectRestApi(String.Format($"{ _baseAddress}/role/{id}"), token);
            return RedirectToAction("Index");

        }
    }
}
