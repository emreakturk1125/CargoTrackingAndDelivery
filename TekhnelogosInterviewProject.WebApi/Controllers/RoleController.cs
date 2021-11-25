using AutoMapper;
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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;    

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            BaseResponse<IEnumerable<Role>> response = await _roleService.GetAllAsync();

            if (response.Success)
            {
                return Ok(_mapper.Map<IEnumerable<RoleDto>>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
             
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            BaseResponse<Role> response = await _roleService.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(_mapper.Map<RoleDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage);
             
        }
         
        [HttpPost]
        public async Task<IActionResult> Save(RoleDto roleDto)
        {
            BaseResponse<Role> response = await _roleService.AddAsync(_mapper.Map<Role>(roleDto));

            if (response.Success)
            {
                return Ok(_mapper.Map<RoleDto>(response.Content));
            }

            return BadRequest(response.ErrorMessage); 
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDto roleDto)
        {

            BaseResponse<Role> roleItemResponse = await _roleService.GetByIdAsync(roleDto.RoleId);

            if (roleItemResponse.Success)
            {
                roleItemResponse.Content.RoleName = roleDto.RoleName;
                roleItemResponse.Content.IsActive = roleDto.IsActive;

                BaseResponse<Role> response = await _roleService.UpdateAsync(roleItemResponse.Content);

                if (response.Success)
                {
                    return Ok(_mapper.Map<RoleDto>(response.Content));
                }

                return BadRequest(response.ErrorMessage);
            }

            return BadRequest(roleItemResponse.ErrorMessage); 

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        { 
            BaseResponse<Role> roleResponse = await _roleService.GetByIdAsync(id);

            if (roleResponse.Success)
            {
                roleResponse.Content.IsActive = false;

                BaseResponse<Role> response = await _roleService.UpdateAsync(roleResponse.Content);

                if (response.Success)
                {
                    return Accepted(_mapper.Map<RoleDto>(response.Content));
                }

                return BadRequest(response.ErrorMessage);
            }

            return BadRequest(roleResponse.ErrorMessage);
        }
    }
}
