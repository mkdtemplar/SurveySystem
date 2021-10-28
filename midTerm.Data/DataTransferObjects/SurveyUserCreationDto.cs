using System;
using System.Collections.Generic;
using System.Text;
using midTerm.Data.Enums;

namespace midTerm.Data.DataTransferObjects
{
    public class SurveyUserCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DoB { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
    }
}
