using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class CargoController : Controller
    {
        private readonly string _baseAddress;
        public CargoController()
        {
            _baseAddress = ApiService.BaseAddress;
        }
        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<CargoWithCustAndPerDto> helper = new HelperRestApi<CargoWithCustAndPerDto>();
            var response = helper.GetConnectRestApiForList($"{_baseAddress}/cargo/getallwithcustomerandpersonal", token).OrderBy(x => x.ShippingDate).ThenBy(x => x.DeliveryDate == null).ToList();

            return View(response);
        }

        [HttpGet]
        public IActionResult AddCargo(int? id)
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<PersonalDto> helperForPersonal = new HelperRestApi<PersonalDto>();
            var resultPersonalList = helperForPersonal.GetConnectRestApiForList($"{_baseAddress}/personal", token);

            HelperRestApi<CustomerDto> helperForCustomer = new HelperRestApi<CustomerDto>();
            var resultCustomerList = helperForCustomer.GetConnectRestApiForList($"{_baseAddress}/customer", token);
             
            if (resultPersonalList != null)
            {
                List<SelectListItem> valueParsonal = (from x in resultPersonalList.Where(x => x.IsActive == true)
                                                      select new SelectListItem
                                                      {
                                                          Text = x.PersonalName,
                                                          Value = x.PersonalId.ToString()
                                                      }).ToList();
                ViewBag.vlcPersonal = valueParsonal;
            }

            if (resultCustomerList != null)
            {
                List<SelectListItem> valueCustomer = (from x in id != null ? resultCustomerList.Where(x => x.CustomerId == id) : resultCustomerList.Where(x => x.IsActive == true)
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CustomerName +" "+x.CustomerSurname ,
                                                          Value = x.CustomerId.ToString()
                                                      }).ToList();
                ViewBag.vlcCustomer = valueCustomer;
                ViewBag.vlcCustomerCount = valueCustomer.Count();

            }



            return View();
        }

        [HttpPost]
        public IActionResult AddCargo(CargoDto item)
        {
            item.ShippingDate = DateTime.Now;
            item.IsActive = true;

            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<CargoDto> helper = new HelperRestApi<CargoDto>();
            var result = helper.PostConnectRestApi($"{_baseAddress}/cargo", token, item);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("AddCargo", "Cargo");

        }

        [HttpGet]
        public IActionResult EditCargo(int id)
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<CargoDto> helperForcargo = new HelperRestApi<CargoDto>();
            var result = helperForcargo.GetConnectRestApi(String.Format($"{ _baseAddress}/cargo/{id}"), token);

            HelperRestApi<PersonalDto> helperForPersonal = new HelperRestApi<PersonalDto>();
            var resultPersonalList = helperForPersonal.GetConnectRestApiForList($"{_baseAddress}/personal", token);

            HelperRestApi<CustomerDto> helperForCustomer = new HelperRestApi<CustomerDto>();
            var resultCustomerList = helperForCustomer.GetConnectRestApiForList($"{_baseAddress}/customer", token);

            if (resultPersonalList != null)
            {
                List<SelectListItem> valueParsonal = (from x in resultPersonalList
                                                      select new SelectListItem
                                                      {
                                                          Text = x.PersonalName,
                                                          Value = x.PersonalId.ToString()
                                                      }).ToList();
                ViewBag.vlcPersonal = valueParsonal;
            }

            if (resultCustomerList != null)
            {
                List<SelectListItem> valueCustomer = (from x in resultCustomerList
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CustomerName + " " + x.CustomerSurname,
                                                          Value = x.CustomerId.ToString()
                                                      }).ToList();
                ViewBag.vlcCustomer = valueCustomer; 

            }

            if (result != null)
            {
                return View(result);
            }

            return RedirectToAction("Index", "Cargo");

        }

        [HttpPost]
        public IActionResult EditCargo(CargoDto item)
        {
            item.DeliveryDate = DateTime.Now;
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<CargoDto> helperForCustomer = new HelperRestApi<CargoDto>();
            var result = helperForCustomer.PutConnectRestApi(String.Format($"{ _baseAddress}/cargo"), token, item);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("EditCargo", "Cargo", item.CargoId);

        }

        public IActionResult DeleteCargo(int id)
        {
            var token = HttpContext.Session.GetString("accessToken");
            HelperRestApi<CargoDto> helperForCargo = new HelperRestApi<CargoDto>();
            var result = helperForCargo.DeleteConnectRestApi(String.Format($"{ _baseAddress}/cargo/{id}"), token);
            return RedirectToAction("Index");

        }
    }
}
