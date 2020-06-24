using System;
using System.Collections.Generic;
using System.Text;

namespace EL.ViewModel.ViewModels.Auth
{
  public  class UserResetViewModel
    {
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public Guid Id { get; set; }
    }
}
