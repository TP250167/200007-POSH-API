using EL.Domain.GamePosh;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Repository.poshGameRepository
{
  public class GameRepository : EntityBaseRepository<Game>, IGameRepository
    {
      //  private readonly ELContext context;
        public GameRepository(ELContext context) : base(context)
        {
          //  this.context = context;
        }
    }
}

   