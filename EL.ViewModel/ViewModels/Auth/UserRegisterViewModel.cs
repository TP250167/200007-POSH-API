using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EL.ViewModel.Auth
{
    public class UserRegisterViewModel:IValidatableObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Cpassword { get; set; }
        public Guid Id { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new UserRegisterViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
