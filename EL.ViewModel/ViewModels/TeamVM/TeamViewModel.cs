using System;
using System.Collections.Generic;
using System.Text;

namespace EL.ViewModel.ViewModels.TeamVM
{
  public  class TeamViewModel
    {
        public Guid Id { get; set; }
        //public Guid IccempId { get; set; }
        public string Teamempname { get; set; }
     //   public string TeamempId { get; set; }
        public string TeamDescription { get; set; }
        public string TeamId { get; set; }
        public string Teamtype { get; set; }
        public string Active { get; set; }
    }
}
