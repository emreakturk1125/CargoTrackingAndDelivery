using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Entity.Concrete; 
using TekhnelogosInterviewProject.WebApi.Filters; 
using TekhnelogosInterviewProject.Helper.Response;
using TekhnelogosInterviewProject.Entity.DTOs;

namespace TekhnelogosInterviewProject.WebApi.Controllers
{
    [Authorize]
    [ValidationFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;   // AutoMapper Kütüphanelerini yüklemek gerekiyor

        public CustomerController(ICustomerService customerService, ICargoService cargoService, IMapper mapper)
        {
            _customerService = customerService;
            _cargoService = cargoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            BaseResponse<IEnumerable<Customer>> response = await _customerService.GetAllAsync();

            if (response.Success)
            {
                return Ok(_mapper.Map<IEnumerable<CustomerDto>>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            BaseResponse<Customer> response = await _customerService.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(_mapper.Map<CustomerDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            BaseResponse<Customer> response = await _customerService.AddAsync(_mapper.Map<Customer>(customerDto));

            if (response.Success)
            {
                return Ok(_mapper.Map<CustomerDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            BaseResponse<Customer> customerItemResponse = await _customerService.GetByIdAsync(customerDto.CustomerId);

            if (customerItemResponse.Success)
            {
                customerItemResponse.Content.CustomerName = customerDto.CustomerName;
                customerItemResponse.Content.CustomerSurname = customerDto.CustomerSurname;
                customerItemResponse.Content.CustomerAddress = customerDto.CustomerAddress;
                customerItemResponse.Content.IsActive = customerDto.IsActive;

                BaseResponse<Customer> response = await _customerService.UpdateAsync(customerItemResponse.Content);

                if (response.Success)
                {
                    return Ok(_mapper.Map<CustomerDto>(response.Content));
                }

                return BadRequest(response.ErrorMessage);
            }
             
            return BadRequest(customerItemResponse.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            BaseResponse<Customer> customerResponse = await _customerService.GetByIdAsync(id);

            if (customerResponse.Success)
            {
                customerResponse.Content.IsActive = false;

                BaseResponse<Customer> response = await _customerService.UpdateAsync(customerResponse.Content);

                if (response.Success)
                {
                    return Accepted(_mapper.Map<CustomerDto>(response.Content));
                }

                return BadRequest(response.ErrorMessage);
            }

            return BadRequest(customerResponse.ErrorMessage);
             
        }

        [HttpGet("srvgetmusteri")]
        public async Task<IActionResult> GetSrvMusteri(int day)
        {
              
            BaseResponse<IEnumerable<Cargo>> cargoListByDayResponse = await _cargoService.Find(x => x.ShippingDate.Date > DateTime.Now.Date.AddDays(-day));

            if (cargoListByDayResponse.Success)
            {
                BaseResponse<IEnumerable<Customer>> response = await _customerService.GetAllAsync();

                if (response.Success)
                {
                    var result = response.Content.Where(x => cargoListByDayResponse.Content.All(x2 => x2.CustomerId != x.CustomerId));
                    return Ok(_mapper.Map<IEnumerable<CustomerDto>>(result));
                }

                return BadRequest(response.ErrorMessage);

            }

            return BadRequest(cargoListByDayResponse.ErrorMessage);
             
        }
         
    }
}
