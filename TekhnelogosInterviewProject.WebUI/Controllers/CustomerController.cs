using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs; 
using TekhnelogosInterviewProject.WebUI.Helpers;

namespace TekhnelogosInterviewProject.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly string _baseAddress; 
        private readonly HelperRestApi<CustomerDto> _helperRestApi; 
        public CustomerController()
        {
            _baseAddress = ApiService.BaseAddress;
            _helperRestApi = new HelperRestApi<CustomerDto>();
        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("accessToken"); 
            var response = _helperRestApi.GetConnectRestApiForList($"{_baseAddress}/customer", token).OrderByDescending(x => x.CreatedDate).ToList();

            return View(response);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {  
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerDto item)
        {
            item.CreatedDate = DateTime.Now;
            item.IsActive = true;

            var token = HttpContext.Session.GetString("accessToken"); 
            var result = _helperRestApi.PostConnectRestApi($"{_baseAddress}/customer", token,item);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("AddCargo", "Cargo");

        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var token = HttpContext.Session.GetString("accessToken"); 
            var result = _helperRestApi.GetConnectRestApi(String.Format($"{ _baseAddress}/customer/{id}"), token);

            if (result != null)
            {
                return View(result);
            }

            return RedirectToAction("Index", "Category");

        }

        [HttpPost]
        public IActionResult EditCustomer(CustomerDto item)
        {
            var token = HttpContext.Session.GetString("accessToken"); 
            var result = _helperRestApi.PutConnectRestApi(String.Format($"{ _baseAddress}/customer"), token, item);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("EditCustomer", "Customer", item.CustomerId);

        }
         
        public IActionResult DeleteCustomer(int id)
        {
            var token = HttpContext.Session.GetString("accessToken"); 
             _helperRestApi.DeleteConnectRestApi(String.Format($"{ _baseAddress}/customer/{id}"), token);
            return RedirectToAction("Index");

        }
    }
}
