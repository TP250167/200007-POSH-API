using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EL.Domain.Entities.Team
{
 public  class TeamEmp : IBaseEntity
    {
        public Guid Id { get; set; }
        //public Guid IccempId { get; set; }
        public string Teamempname { get; set; }
     //   public string TeamempId{ get; set; }
        public string TeamDescription { get; set; }
        public string TeamId { get; set; }
        public string Teamtype { get; set; }
        public string Active { get; set; }
        [NotMapped]
        public int count { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
