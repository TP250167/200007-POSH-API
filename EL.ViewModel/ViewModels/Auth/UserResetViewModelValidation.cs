using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.ViewModel.ViewModels.Auth
{
 public  class UserResetViewModelValidation : AbstractValidator<UserResetViewModel>
    {
        public UserResetViewModelValidation()
        {
            //RuleFor(user => user.Password).NotEmpty().WithMessage("Username cannot be empty");
            //RuleFor(user => user.Password).NotEmpty().WithMessage("Password cannot be empty");

            RuleFor(user => user.Confirmpassword).NotEqual(user=>user.Password).WithMessage("Password and Conform Password Should match");
          // RuleFor(user => user.Password != user.Conformpassword).NotEqual(false).WithMessage("Welcome");

           // RuleFor(user => user.Password == user.Confirmpassword).Equal(true).WithMessage("Welcome");
         //   RuleFor(user => user.Password == user.Confirmpassword).Equal(false).WithMessage("Password and ConformPassword not match");
        }

        //public UserRegisterViewModelValidator()
        //{
          

        //}
    }
}
