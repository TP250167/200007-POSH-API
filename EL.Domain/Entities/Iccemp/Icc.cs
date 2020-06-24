using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities.Iccemp
{
  public  class Icc: IBaseEntity
    {
        public Guid Id { get; set; }
        //public Guid IccempId { get; set; }
        public string Iccempname { get; set; }
        public string Iccempjobtitle { get; set; }
        public string Iccempemail { get; set; }
        public Int64 Iccempphoneno { get; set; }
        public string Iccempdeparttype { get; set; }
        public string Iccempqulification { get; set; }
        public string Iccempstatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

