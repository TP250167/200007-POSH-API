using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EL.ViewModel.ViewModels.Game
{
  public  class GameAddViewModel 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Objective { get; set; }
        public string Outcome { get; set; }
        public string Noofcases { get; set; }
        public string Duration { get; set; }
        public string BackgroundAudio { get; set; }
        public string MaxScore { get; set; }
        public string Active { get; set; }
    //    public DateTime CreatedOn { get; set; }
     //   public DateTime ModifiedOn { get; set; }
    }
}
