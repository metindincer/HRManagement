using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Validators
{
    public class UpdateCommentResourceValidator : AbstractValidator<CreateComentDTO>
    {
        public UpdateCommentResourceValidator()
        {
            RuleFor(a => a.CommentText).NotEmpty();
            RuleFor(a => a.CommentTitle).NotEmpty();
        }
    }
}
