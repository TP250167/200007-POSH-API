﻿using EL.Domain.Entities.comp;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Repository.ComplainRepository
{
    public class CompRepository:EntityBaseRepository<Complain>, ICompRepository
    {
     //   private readonly ELContext context;
        public CompRepository(ELContext context):base(context)
        {

        }
       
    }
}
