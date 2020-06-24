using System;
using System.Collections.Generic;
using System.Text;

namespace EL.ViewModel.ViewModels.Complain
{
  public  class ComplainAddViewModel
    {
        public string Complaintname { get; set; }
        public Int64 Complaintdesc { get; set; }
        public string ComplaintFrom { get; set; }
        //public Int64 ComplaintTo { get; set; }
        public string Compstatus { get; set; }
        public string Complaintdate { get; set; }
    }
}
