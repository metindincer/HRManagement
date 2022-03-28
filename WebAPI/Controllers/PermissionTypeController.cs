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
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeService permissionTypeService;
        private readonly IMapper mapper;
        public PermissionTypeController(IPermissionTypeService permissionTypeService, IMapper mapper)
        {
            this.mapper = mapper;
            this.permissionTypeService = permissionTypeService;
        }

        [HttpGet("PermissionTypes")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PermissionTypeDTO>>> GetPermissionTypes()
        {
            var permissionTypes = await permissionTypeService.GetAllPermissionTypes();
            var permissionTypeDTO = mapper.Map<IEnumerable<PermissionType>, IEnumerable<PermissionTypeDTO>>(permissionTypes);
            return Ok(permissionTypeDTO);
        }

        [HttpPost("newPermissionType")]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult> CreatePermissionType([FromBody] PermissionTypeDTO permissionType)
        {
            

            var validator = new PermissionTypeResourceValidator();

            var validationResult = await validator.ValidateAsync(permissionType);

            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var permissionTypeToCreate = mapper.Map<PermissionTypeDTO, PermissionType>(permissionType);
            var newPermissionType = await permissionTypeService.CreatePermissionType(permissionTypeToCreate);

            return Ok(new { Result = "New Permission Type Added." });
        }

        [HttpDelete("DeletePermissionType")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeletePermissionType(int id)
        {
            if (id == 0)
                return BadRequest();

            var permissionType = await permissionTypeService.GetPermissionTypeById(id);
            if (permissionType == null)
                return NotFound();
            await permissionTypeService.DeletePermissionType(permissionType);
            return Ok(new { Result= "Permission Type Deleted "});
        }
    }
}
