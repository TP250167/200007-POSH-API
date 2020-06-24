using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities.Time
{
    public class TimeupMap
    {
        public TimeupMap(EntityTypeBuilder<Timeup> builder)
        {
            builder.ToTable("TIMEUP_LOOP_TBL");
            //  builder.HasKey(s => s.Id).HasName("DECISION_MAIN_STORY_ID");
            builder.Property(s => s.MainStoryname).HasColumnName("Main_Story_NAME");
            builder.Property(s => s.Substoryid).HasColumnName("SUB_STORY_ID");
            builder.Property(s => s.Substoryname).HasColumnName("SUB_STORY_NAME");
            builder.Property(s => s.QuestionId).HasColumnName("QUESTION_ID");
            builder.Property(s => s.Questionname).HasColumnName("QUESTION_NAME");
            builder.Property(s => s.Option1).HasColumnName("OPTION1");
            builder.Property(s => s.Option2).HasColumnName("OPTION2");
            builder.Property(s => s.Option3).HasColumnName("OPTION3");
            builder.Property(s => s.Option4).HasColumnName("OPTION4");
            builder.Property(s => s.Result).HasColumnName("RESULT");
            builder.Property(s => s.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(s => s.ModifiedOn).HasColumnName("MODIFIED_ON");
            builder.Property(s => s.TimeStart).HasColumnName("TIME_START_ON");
            builder.Property(s => s.TimeEnd).HasColumnName("TIME_END_ON");

        }

    }
}
