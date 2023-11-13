using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Application.Authentication.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x=> x.FirstName).NotEmpty();
            RuleFor(x=> x.LastName).NotEmpty();
           
        }
    }
}
