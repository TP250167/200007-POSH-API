using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.GamePosh
{
  public  class GameMap
    {
        public GameMap(EntityTypeBuilder<Game> builder)
        {          
            builder.ToTable("POSH_GAME_PLAY_TBL");            
            builder.Property(s => s.GameName).HasColumnName("GAME_NAME");
            builder.Property(s => s.Description).HasColumnName("DESCRIPTION");
            builder.Property(s => s.BackgroundAudio).HasColumnName("BACKGROUND_AUDIO");
            builder.Property(s => s.MaxScore).HasColumnName("MAX_SCORE");
            builder.Property(s => s.Noofcases).HasColumnName("NO_OF_CASES");
            builder.Property(s => s.Outcome).HasColumnName("OUTCOME");
            builder.Property(s => s.Objective).HasColumnName("OBJECTIVE");           
            builder.Property(s => s.Duration).HasColumnName("DURATION");          
            builder.Property(s => s.GameType).HasColumnName("GAME_TYPE");
            builder.Property(s => s.Active).HasColumnName("IS_ACTIVE");
            builder.Property(s => s.CreatedOn).HasColumnName("CREATED_ON");
            builder.Property(s => s.ModifiedOn).HasColumnName("MODIFIED_ON");
        }
    }
}
