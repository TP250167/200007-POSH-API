﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> builder)
        {
            builder
            .ToTable("USER_TBL");

            builder
                .Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.ModifiedOn).HasColumnName("MODIFIED_ON");
            builder.Property(s => s.CreatedOn).HasColumnName("CREATED_ON");
        }
    }
}
