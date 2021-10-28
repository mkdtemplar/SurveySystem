using System;
using System.Collections.Generic;
using System.Text;
using midTerm.Data.Entities;

namespace midTerm.Data.DataTransferObjects
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OptionDto> Options { get; set; }
    }
}
