using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Core.Services;
using TekhnelogosInterviewProject.Entity.Concrete;
using TekhnelogosInterviewProject.WebApi.Filters;
using TekhnelogosInterviewProject.Helper.Response;
using TekhnelogosInterviewProject.Entity.DTOs;

namespace TekhnelogosInterviewProject.WebApi.Controllers
{
    //[Authorize]
    [ValidationFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalService _personalService;
        private readonly IMapper _mapper;

        public PersonalController(IPersonalService personalService, IMapper mapper)
        {
            _personalService = personalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            BaseResponse<IEnumerable<Personal>> response = await _personalService.GetAllAsync();

            if (response.Success)
            {
                return Ok(_mapper.Map<IEnumerable<PersonalDto>>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpGet("getallwithrole")]
        public async Task<IActionResult> GetAllWithRole()
        {
            BaseResponse<IEnumerable<Personal>> response = await _personalService.GetPersonalListWithRoleAsync();

            if (response.Success)
            {
                return Ok(_mapper.Map<IEnumerable<PersonalWithRoleDto>>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            BaseResponse<Personal> response = await _personalService.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(_mapper.Map<PersonalDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpGet("{id}/roles")]
        public async Task<IActionResult> GetPersonalWithRoleById(int id)
        {

            BaseResponse<Personal> response = await _personalService.GetPersonalWithRoleByIdAsync(id);

            if (response.Success)
            {
                return Ok(_mapper.Map<PersonalWithRoleDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage);

        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonalDto personalDto)
        {
            BaseResponse<Personal> response = await _personalService.AddAsync(_mapper.Map<Personal>(personalDto));

            if (response.Success)
            {
                return Ok(_mapper.Map<PersonalDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage);

        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonalDto personalDto)
        {

            BaseResponse<Personal> personelItemResponse = await _personalService.GetByIdAsync(personalDto.PersonalId);

            if (personelItemResponse.Success)
            {
                personelItemResponse.Content.PersonalName = personalDto.PersonalName;
                personelItemResponse.Content.PersonalSurname = personalDto.PersonalSurname;
                personelItemResponse.Content.UserName = personalDto.UserName;
                personelItemResponse.Content.UserPassword = personalDto.UserPassword;
                personelItemResponse.Content.RoleId = personalDto.RoleId;
                personelItemResponse.Content.IsActive = personalDto.IsActive;

                BaseResponse<Personal> response = await _personalService.UpdateAsync(personelItemResponse.Content);

                if (response.Success)
                {
                    return Ok(_mapper.Map<PersonalDto>(response.Content));
                }

                return BadRequest(response.ErrorMessage);
            }

            return BadRequest(personelItemResponse.ErrorMessage);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            BaseResponse<Personal> personalResponse = await _personalService.GetByIdAsync(id);

            if (personalResponse.Success)
            {
                personalResponse.Content.IsActive = false;

                BaseResponse<Personal> response = await _personalService.UpdateAsync(personalResponse.Content);

                if (response.Success)
                {
                    return Accepted(_mapper.Map<PersonalDto>(response.Content));
                }

                return BadRequest(response.ErrorMessage);
                 
            }

            return BadRequest(personalResponse.ErrorMessage);

        }

    }
}
