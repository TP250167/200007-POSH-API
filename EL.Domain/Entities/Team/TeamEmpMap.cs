using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities.Team
{
  public  class TeamEmpMap
    {
        public TeamEmpMap(EntityTypeBuilder<TeamEmp> builder)
        {
            builder.ToTable("TEAM_EMP_TBL");
            builder.Property(s => s.Teamempname).HasColumnName("TEAM_EMP_NAME");
          //  builder.Property(s => s.TeamempId).HasColumnName("TEAM_EMP_ID");
            builder.Property(s => s.TeamDescription).HasColumnName("TEAM_DESCRIPTION");         
            builder.Property(s => s.TeamId).HasColumnName("TEAM_ID");
            builder.Property(s => s.Teamtype).HasColumnName("TEAM_TYPE");
            builder.Property(s => s.Active).HasColumnName("IS_ACTIVE");          
            builder.Property(s => s.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(s => s.ModifiedOn).HasColumnName("MODIFIED_ON");
        }
    }

  
}
