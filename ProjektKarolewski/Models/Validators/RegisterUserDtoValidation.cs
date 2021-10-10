using FluentValidation;
using ProjektKarolewski.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models.Validators
{
    public class RegisterUserDtoValidation : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidation(ProjektDbContext dbContext)
        {
            RuleFor(x => x.Username).NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .MaximumLength(20);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Username)
                .Custom((value, context) =>
                {
                    var usernameInUse = dbContext.Users.Any(u => u.Username == value);
                    if (usernameInUse)
                    {
                        context.AddFailure("Username", "That username is taken");
                    }
                });
        }
    }
}
