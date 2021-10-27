using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using midTerm.Data.Entities;

namespace midTerm.Data.DataTransferObjects
{
    public class AnswersDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }

        public virtual Option Option { get; set; }

        public SurveyUser User { get; set; }
    }
}
