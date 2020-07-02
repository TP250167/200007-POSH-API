using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace EL.Domain.Entities.DecisionloopEntity
{
   public class Decisionloop : IBaseEntity
    {
      
        public Guid Id { get; set; }
        public string MainStoryname { get; set; }
        public Int64 Substoryid { get; set; }
        public string Substoryname { get; set; }
        public Int64 QuestionId { get; set; }
        public string Questionname { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Result { get; set; }
       
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        
[NotMapped]
        public List<Decisionloop> ParentsItems { get; set; }
        [NotMapped]
        public List<Decisionloop> ChildItems { get; set; }


    }
}

