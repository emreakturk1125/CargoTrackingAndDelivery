using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs;
using TekhnelogosInterviewProject.WebUI.Helpers;

namespace TekhnelogosInterviewProject.WebUI.Controllers
{
    public class PersonalController : Controller
    {
        private readonly string _baseAddress; 
        private readonly HelperRestApi<PersonalDto> _helperRestApi; 

        public PersonalController()
        {
            _baseAddress = ApiService.BaseAddress;
            _helperRestApi = new HelperRestApi<PersonalDto>();

        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<PersonalWithRoleDto>  _helper = new HelperRestApi<PersonalWithRoleDto>();
            var response = _helper.GetConnectRestApiForList($"{_baseAddress}/personal/getallwithrole", token);
             

            return View(response);
        }

        [HttpGet]
        public IActionResult AddPersonal()
        {
            var token = HttpContext.Session.GetString("accessToken");

            HelperRestApi<RoleDto> helperForRole = new HelperRestApi<RoleDto>();
            var resultRoleList = helperForRole.GetConnectRestApiForList($"{_baseAddress}/role", token);

            if (resultRoleList != null)
            {
                List<SelectListItem> valueRole = (from x in resultRoleList.Where(x => x.IsActive == true)
                                                  select new SelectListItem
                                                  {
                                                      Text = x.RoleName,
                                                      Value = x.RoleId.ToString()
                                                  }).ToList();
                ViewBag.vlcRole = valueRole;
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddPersonal(PersonalDto item)
        {
            item.CreatedDate = DateTime.Now;
            item.IsActive = true;

            var token = HttpContext.Session.GetString("accessToken"); 
            var result = _helperRestApi.PostConnectRestApi($"{_baseAddress}/personal", token, item);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("AddCargo", "Cargo");

        }


        [HttpGet]
        public IActionResult EditPersonal(int id)
        {
            var token = HttpContext.Session.GetString("accessToken"); 
            var result = _helperRestApi.GetConnectRestApi(String.Format($"{ _baseAddress}/personal/{id}"), token);

            HelperRestApi<RoleDto> helperForRole = new HelperRestApi<RoleDto>();
            var resultRoleList = helperForRole.GetConnectRestApiForList($"{_baseAddress}/role", token);

            if (resultRoleList != null)
            {
                List<SelectListItem> valueRole = (from x in resultRoleList.Where(x => x.IsActive == true)
                                                  select new SelectListItem
                                                  {
                                                      Text = x.RoleName,
                                                      Value = x.RoleId.ToString()
                                                  }).ToList();
                ViewBag.vlcRole = valueRole;
            }

            if (result != null)
            {
                return View(result);
            }

            return RedirectToAction("Index", "Cargo");

        }

        [HttpPost]
        public IActionResult EditPersonal(PersonalDto item)
        { 
            var token = HttpContext.Session.GetString("accessToken"); 
            var result = _helperRestApi.PutConnectRestApi(String.Format($"{ _baseAddress}/personal"), token, item);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("EditPersonal", "Personal", item.PersonalId);

        }

        public IActionResult DeletePersonal(int id)
        {
            var token = HttpContext.Session.GetString("accessToken"); 
            var result = _helperRestApi.DeleteConnectRestApi(String.Format($"{ _baseAddress}/personal/{id}"), token);
            return RedirectToAction("Index");

        }
    }
}
