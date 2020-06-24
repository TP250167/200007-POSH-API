using System;
using System.Collections.Generic;
using System.Text;

namespace EL.ViewModel.ViewModels.TimeupSeq
{
  public  class TimeUpCreateViewModel
    {
        public Int64 QuestionId { get; set; }
        public string Questionname { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public Guid Id { get; set; }
    }
}
