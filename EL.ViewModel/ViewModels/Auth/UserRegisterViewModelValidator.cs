using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EL.ViewModel.Auth
{
    public class UserRegisterViewModelValidator:AbstractValidator<UserRegisterViewModel>
    {
        public UserRegisterViewModelValidator()
        {
            RuleFor(user => user.Username).NotEmpty().WithMessage("Username cannot be empty");           
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password cannot be empty");
           
        }
    }
}
