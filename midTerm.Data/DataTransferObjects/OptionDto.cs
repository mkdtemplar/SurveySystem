using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using midTerm.Data.Entities;

namespace midTerm.Data.DataTransferObjects
{
    public class OptionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? Order { get; set; }

        public int QuestionId { get; set; }

        
        public ICollection<QuestionDto>  Question { get; set; }
    }
}
