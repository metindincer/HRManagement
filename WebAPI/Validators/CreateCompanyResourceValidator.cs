using Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Validators
{
    public class CreateCompanyResourceValidator:AbstractValidator<CompanyDTO>
    {
        public CreateCompanyResourceValidator()
        {
            RuleFor(m => m.CompanyName).NotEmpty().MaximumLength(200);
            RuleFor(m => m.LogoPath).NotEmpty();
            
        }
    }
}
