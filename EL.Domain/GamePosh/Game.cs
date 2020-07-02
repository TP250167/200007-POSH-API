using EL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EL.Domain.GamePosh
{
  public  class Game : IBaseEntity
    {
        public Guid Id { get; set; }
        //  public string UserName { get; set; }       
        public string GameName { get; set; }
        public string Description  { get; set; }
        public string BackgroundAudio { get; set; }
        public string MaxScore { get; set; }
        public string Noofcases { get; set; }
        public string Objective { get; set; }
        public string Outcome { get; set; }
        public string Duration { get; set; }
        public string GameType { get; set; }          
        public string Active { get; set; }
        [NotMapped]
        public int count { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
