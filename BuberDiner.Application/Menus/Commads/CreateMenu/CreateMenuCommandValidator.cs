using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDiner.Application.Menus.Commads.CreateMenu
{
    public class CreateMenuCommandValidator: AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Description).NotEmpty();             

        }
    }
}
