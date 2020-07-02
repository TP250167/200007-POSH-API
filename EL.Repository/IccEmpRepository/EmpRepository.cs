using EL.Domain.Entities.Iccemp;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Repository.IccEmpRepository
{
  public class EmpRepository : EntityBaseRepository<Icc>, IEmpRepository
    {
      //  private readonly ELContext context;
        public EmpRepository(ELContext context) : base(context)
        {

        }
    }
}
