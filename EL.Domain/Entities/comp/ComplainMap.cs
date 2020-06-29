using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities.comp
{
  public  class ComplainMap
    {
        
        public ComplainMap(EntityTypeBuilder<Complain> builder)
        {
            builder.ToTable("COMPLAIN_TBL");
          
            builder.Property(s => s.Complaintdate).HasColumnName("COMPLAINT_DATE");
            builder.Property(s => s.Complaintdesc).HasColumnName("COMPLAIN_DESCTIPTION");
            builder.Property(s => s.ComplaintFrom).HasColumnName("COMPLAINT_FROM");
            builder.Property(s => s.Complaintname).HasColumnName("COMPLAIN_NAME");
           
            builder.Property(s => s.Compstatus).HasColumnName("COMPLAIN_STATUS");
            builder.Property(s => s.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(s => s.ModifiedOn).HasColumnName("MODIFIED_ON");
        }
      
    }
}
