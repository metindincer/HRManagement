using AutoMapper;
using Core.Models;
using Core.Services_Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Validators;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService permissionService;
        private readonly IMapper mapper;
        public PermissionController(IPermissionService _permissionService,IMapper _mapper)
        {
            permissionService = _permissionService;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatePermissionDTO>>> GetAllPermission()
        {
            var permissions = await permissionService.GetAllPermission();
            var permissionsDTO = mapper.Map<IEnumerable<Permission>, IEnumerable<CreatePermissionDTO>>(permissions);
            return Ok(permissionsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreatePermissionDTO>> GetPermissionById(int id)
        {
            var permission = await permissionService.GetPermissionById(id);
            var permissionDTO = mapper.Map<Permission, CreatePermissionDTO>(permission);
            return Ok(permissionDTO);
        }
        [HttpPost("Create")]
        [Authorize(Roles = "personnel")]
        public async Task<ActionResult<CreatePermissionDTO>> CreatePermission([FromBody] CreatePermissionDTO savePermissionResource)
        {
            var validator = new CreatePermissionResourceValidator();
            var validationResult = await validator.ValidateAsync(savePermissionResource);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var permissionToCreate = mapper.Map<CreatePermissionDTO, Permission>(savePermissionResource);
            var newPermission = await permissionService.CreatePermission(permissionToCreate);
            var permission = await permissionService.GetPermissionById(newPermission.PermissionId);
            var permissionResource = mapper.Map<Permission, CreatePermissionDTO>(permission);
            return Ok(permissionResource);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "personnel")]
        public async Task<ActionResult<UpdatePermissionDTO>> UpdatePermission(int id, [FromBody] UpdatePermissionDTO savePermissionResource)
        {
            var validator = new UpdatePermissionResourceValidator();
            var validationResult = await validator.ValidateAsync(savePermissionResource);
            var requestIsInvalid = id == 0 || !validationResult.IsValid;
            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);
            var permissionToUpdate = await permissionService.GetPermissionById(id);
            if (permissionToUpdate == null)
            {
                return NotFound();
            }
            var permission = mapper.Map<UpdatePermissionDTO, Permission>(savePermissionResource);
            await permissionService.UpdatePermission(id, permission);
            var updatePermission = await permissionService.GetPermissionById(id);
            var updatePermissionResource = mapper.Map<Permission, UpdatePermissionDTO>(updatePermission);
            return Ok(updatePermissionResource);
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = "personnel")]
        public async Task<ActionResult> DeletePermission(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var permission = await permissionService.GetPermissionById(id);
            if (permission == null)
            {
                return NotFound();
            }
            await permissionService.DeletePermission(permission);
            return NoContent();
        }

    }
}
