using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Domain.Entities.comp
{
 public class Complain: IBaseEntity
    {
        public Guid Id { get; set; }

        //public int ComplaintId { get; set; }
        public string Complaintname { get; set; }
        public Int64 Complaintdesc { get; set; }
        public string ComplaintFrom { get; set; }
        //public Int64 ComplaintTo { get; set; }
        public string Compstatus { get; set; }
        public string Complaintdate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
