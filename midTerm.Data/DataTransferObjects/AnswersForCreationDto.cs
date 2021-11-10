using System;
using System.Collections.Generic;
using System.Text;
using midTerm.Data.Entities;

namespace midTerm.Data.DataTransferObjects
{
    public class AnswersForCreationDto
    {
        public ICollection<OptionDto> Option { get; set; }
    }
}
