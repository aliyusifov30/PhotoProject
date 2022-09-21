using FluentValidation;
using PhotoProject.Application.Features.Commands.AccountCommands.UserLoginCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Application.Validators.UserValidators
{
    public class UserLoginValidator : AbstractValidator<UserLoginCommandRequest>
    {

        public UserLoginValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
                .NotNull().NotEmpty()
                .MaximumLength(35)
                .MinimumLength(5);

            RuleFor(x => x.Password)
                .NotNull().NotEmpty()
                .MaximumLength(25)
                .MinimumLength(5);
        }
    }
}
