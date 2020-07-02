using EL.Domain.Entities.Iccemp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.IccEmpService
{
  public  interface IEmpService
    {
        Task<ServiceResponse<Icc>> CreateIccEmp(Icc icc);
    }
}
