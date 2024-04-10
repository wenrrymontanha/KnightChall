using FluentValidation;
using KnightChall.Domain.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightChall.Service.Validator
{
    public class KnightValidator : AbstractValidator<Knight>
    {
        public KnightValidator()
        {
            RuleFor(c => c.name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");
        }
    }
}
