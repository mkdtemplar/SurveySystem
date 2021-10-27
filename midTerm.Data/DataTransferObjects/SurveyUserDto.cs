using System;
using System.Collections.Generic;
using System.Text;
using midTerm.Data.Entities;
using midTerm.Data.Enums;

namespace midTerm.Data.DataTransferObjects
{
    public class SurveyUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DoB { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }

        public ICollection<AnswersDto> AnswersDtos { get; set; }
    }
}
