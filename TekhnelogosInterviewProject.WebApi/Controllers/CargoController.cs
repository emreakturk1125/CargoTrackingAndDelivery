using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.Entity.DTOs;
using TekhnelogosInterviewProject.Helper.Response;
using TekhnelogosInterviewProject.WebApi.Filters;

namespace TekhnelogosInterviewProject.WebApi.Controllers
{
    //[Authorize]
    [ValidationFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CargoController(ICargoService cargoService,ICustomerService customerService, IMapper mapper)
        {
            _cargoService = cargoService;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            BaseResponse<IEnumerable<Cargo>> response = await _cargoService.GetAllAsync();

            if (response.Success)
            {
                return Ok(_mapper.Map<IEnumerable<CargoDto>>(response.Content));
            }

            return BadRequest(response.ErrorMessage);

        }

        [HttpGet("getallwithcustomerandpersonal")]
        public async Task<IActionResult> GetAllwithCustomerandPersonal()
        { 
            BaseResponse<IEnumerable<Cargo>> response = await _cargoService.GetCargoWithCustomerAndPersonalListByDateAsync();

            if (response.Success)
            {
                return Ok(_mapper.Map<IEnumerable<CargoWithCustAndPerDto>>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        { 

            BaseResponse<Cargo> response = await _cargoService.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(_mapper.Map<CargoDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
        }
         
        [HttpPost]
        public async Task<IActionResult> Save(CargoDto cargoDto)
        { 

            BaseResponse<Cargo> response = await _cargoService.AddAsync(_mapper.Map<Cargo>(cargoDto));

            if (response.Success)
            {
                return Ok(_mapper.Map<CargoDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage);

        }

        [HttpPut]
        public async Task<IActionResult> Update(CargoDto cargoDto)
        {
            var cargoItemResponse = _cargoService.GetByIdAsync(cargoDto.CargoId).Result;

            if (cargoItemResponse.Success)
            {
                cargoItemResponse.Content.CargoName = cargoDto.CargoName;
                cargoItemResponse.Content.PersonalId = cargoDto.PersonalId;
                cargoItemResponse.Content.CargoPrice = cargoDto.CargoPrice;
                cargoItemResponse.Content.DeliveryDate = DateTime.Now;

                BaseResponse<Cargo> response = await _cargoService.UpdateAsync(cargoItemResponse.Content);

                if (response.Success)
                {
                    return Ok(_mapper.Map<CargoDto>(response.Content));
                }

                return BadRequest(response.ErrorMessage);
            }
            
            return BadRequest(cargoItemResponse.ErrorMessage);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            BaseResponse<Cargo> cargoResponse = await _cargoService.GetByIdAsync(id);

            if (cargoResponse.Success)
            {
                cargoResponse.Content.IsActive = false;

                BaseResponse<Cargo> response = await _cargoService.UpdateAsync(cargoResponse.Content);

                if (response.Success)
                {
                    return Accepted(_mapper.Map<CargoDto>(response.Content));
                }

                return BadRequest(response.ErrorMessage);

            }

            return BadRequest(cargoResponse.ErrorMessage);
             
        }

        [HttpGet("{id}/customerandpersonal")]
        public async Task<IActionResult> GetCargoWithCustomerAndPersonalById(int id)
        {
            BaseResponse<Cargo> cargoResponse = await _cargoService.GetByIdAsync(id);

            if (cargoResponse.Success)
            {
              return Ok(_mapper.Map<CargoWithCustAndPerDto>(cargoResponse.Content));
            }

            return BadRequest(cargoResponse.ErrorMessage);
             
        }

        [HttpGet("srvgetkargoteslim")]
        public async Task<IActionResult> GetByDaySrvKargoTeslim(int day)
        { 

            BaseResponse<IEnumerable<Cargo>> response = await _cargoService.Find(x => x.DeliveryDate == null);

            if (response.Success)
            {
                List<Cargo> result = new List<Cargo>();

                foreach (var item in response.Content)
                {
                    int differenceDay = Convert.ToInt32((DateTime.Now.Date - item.ShippingDate.Date).TotalDays);

                    if (differenceDay == day)
                    {
                        result.Add(item);
                    }
                }

                return Ok(_mapper.Map<IEnumerable<CargoDto>>(result));
            }
            return BadRequest(response.ErrorMessage);


        }

        [HttpGet("srvkargoteslim")]
        public async Task<IActionResult> GetSrvKargoTeslim(DateTime startDate, DateTime endDate)
        {
            BaseResponse<IEnumerable<Cargo>> response = await _cargoService.GetCargoWithCustomerAndPersonalListByDateAsync();

            if (response.Success)
            {
                IEnumerable<Cargo> cargos = response.Content.Where(x => x.DeliveryDate >= startDate && x.DeliveryDate <= endDate && x.DeliveryDate != null && x.IsActive == true);
                return Ok(_mapper.Map<IEnumerable<CargoWithCustAndPerDto>>(cargos));
            }

            return BadRequest(response.ErrorMessage);
        }


    }
}
