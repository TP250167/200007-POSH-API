using EL.Domain.Entities.Team;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Repository.EmpTeamRepository
{
  

    public class TeamRepository : EntityBaseRepository<TeamEmp>, ITeamRepository
    {
      //  private readonly ELContext context;
        public TeamRepository(ELContext context) : base(context)
        {
           // this.context = context;
        }
    }
}
