using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities.Iccemp
{
  public class IccMap
    {
        public IccMap(EntityTypeBuilder<Icc> builder)
        {
            builder.ToTable("ICC_EMP_TBL");
            builder.Property(s => s.Iccempdeparttype).HasColumnName("EMP_DEPART_TYPE");
            builder.Property(s => s.Iccempemail).HasColumnName("EMP_MAIL");
            builder.Property(s => s.Iccempjobtitle).HasColumnName("EMP_JOB_TITLE");
            builder.Property(s => s.Iccempname).HasColumnName("EMP_NAME");
            builder.Property(s => s.Iccempphoneno).HasColumnName("EMP_PHONE_NO");
            builder.Property(s => s.Iccempqulification).HasColumnName("EMP_QULIFICATION");
            builder.Property(s => s.Iccempstatus).HasColumnName("EMP_STATUS");
            builder.Property(s => s.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(s => s.ModifiedOn).HasColumnName("MODIFIED_ON");
        }
    }
}
