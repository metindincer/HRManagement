using AutoMapper;
using Core.Models;
using Core.Services_Abstract;
using FluentValidation;
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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            var companiesDTO = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyDTO>>(companies);
            return Ok(companiesDTO);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CompanyDTO>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            var companyDTO = _mapper.Map<Company, CompanyDTO>(company);
            return Ok(companyDTO);
        }

        [HttpPost("newCompany")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> CreateCompany([FromBody] CompanyDTO company)
        {


            var validator = new CreateCompanyResourceValidator();

            var validationResult = await validator.ValidateAsync(company);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyToCreate = _mapper.Map<CompanyDTO, Company>(company);
            var newCompany = await _companyService.CreateCompany(companyToCreate);

            return Ok(new { Result = "New Company Added." });
        }

        [HttpPut("UpdateCompany")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CompanyDTO>> UpdateCompany(int id, [FromBody] CompanyDTO saveCompanyResource)
        {
            var validator = new CreateCompanyResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCompanyResource);
            var requestIsInvalid = id == 0 || !validationResult.IsValid;
            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);
            var companyToUpdate = await _companyService.GetCompanyById(id);
            if (companyToUpdate == null)
            {
                return NotFound();
            }
            var company = _mapper.Map<CompanyDTO, Company>(saveCompanyResource);
            await _companyService.UpdateCompany(id, company);
            var updateCompany = await _companyService.GetCompanyById(id);
            var updateCompanyResource = _mapper.Map<Company, CompanyDTO>(updateCompany);
            return Ok(updateCompanyResource);
        }
        [HttpDelete("DeleteCompany")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            if (id == 0)
                return BadRequest();

            var company = await _companyService.GetCompanyById(id);
            if (company == null)
                return NotFound();
            await _companyService.DeleteCompany(company);
            return Ok(new { Result = "Company Deleted " });
        }

        [HttpPut("UpdateMembership")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CompanyDTO>> UpdateMembership(int id, [FromBody] UpdateCompanysMembershipDTO saveCompanyMembershipResource)
        {
            
            var companyToUpdate = await _companyService.GetCompanyById(id);
            if (companyToUpdate == null)
            {
                return NotFound();
            }
            var company = _mapper.Map<UpdateCompanysMembershipDTO, Company>(saveCompanyMembershipResource);
            await _companyService.UpdateCompany(id, company);
            var updateCompany = await _companyService.GetCompanyById(id);
            var updateCompanyResource = _mapper.Map<Company, UpdateCompanysMembershipDTO>(updateCompany);
            return Ok(updateCompanyResource);
        }
    }
}
