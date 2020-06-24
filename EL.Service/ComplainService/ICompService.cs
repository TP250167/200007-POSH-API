using EL.Domain.Entities.comp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.Service.ComplainService
{
   public interface ICompService
    {
        Task<ServiceResponse<Complain>> Createdecisionloop(Complain complain);
    }
}
