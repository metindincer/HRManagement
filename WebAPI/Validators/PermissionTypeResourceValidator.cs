using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Validators
{
    public class PermissionTypeResourceValidator :AbstractValidator<PermissionTypeDTO>
    {
        public PermissionTypeResourceValidator()
        {
            RuleFor(m => m.PermissionName).NotEmpty().MaximumLength(100);
        }
    }
}
