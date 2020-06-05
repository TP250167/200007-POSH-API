using System;
using System.Collections.Generic;
using System.Text;
using EL.Domain.Entities;


namespace EL.Repository
{
    public class AuthRepository : EntityBaseRepository<User>, IAuthRepository
    {
        public AuthRepository(ELContext context) : base(context)
        {

        }
    }
}
