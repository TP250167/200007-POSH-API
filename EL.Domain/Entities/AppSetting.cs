using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EL.Domain.Entities
{
    [NotMapped]
    public class AppSetting
    {
        public string Token { get; set; }

    }
}
