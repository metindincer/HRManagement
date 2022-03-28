using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly RoleManager<Role> roleManager;
        public RoleController(RoleManager<Role> rm)
        {
            roleManager = rm;
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(RoleDTO roleDTO)
        {
            IdentityResult result = await roleManager.CreateAsync(new Role { Name = roleDTO.Name, CreationDate = DateTime.Now });
            if (result.Succeeded)
            {
                return Ok("Role created succesfully");
            }
            return BadRequest("Role creation failed");
            
        }

        [HttpPost("updateRole")]
        public async Task<IActionResult> CreateRole(RoleDTO roleDTO, string id)
        {
            IdentityResult result = null;
            if (id != null)
            {
                Role role = await roleManager.FindByIdAsync(id);
                role.Name = roleDTO.Name;
                result = await roleManager.UpdateAsync(role);
            }
            else
                result = await roleManager.CreateAsync(new Role { Name = roleDTO.Name, CreationDate = DateTime.Now });

            if (result.Succeeded)
            {
                return Ok("Role updated succesfully");
            }
            return BadRequest("Role update failed");
        }

        [HttpGet("deleteRole")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            Role role = await roleManager.FindByIdAsync(id);
            IdentityResult result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok("Role deleted succesfully");
            }
            return BadRequest("Role removal failed");
        }
    
        [HttpGet("getRoles")]
        public IActionResult GetRoles()
        {
            return Ok(roleManager.Roles.ToList());
        }
    }
}
