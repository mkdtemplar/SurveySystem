using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace midTerm.Data.Entities
{
    public class Answers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OptionId { get; set; }

        [ForeignKey("OptionId")]
        public ICollection<Option>  Option { get; set; }

        [ForeignKey("UserId")]
        public  SurveyUser User { get; set; }
    }
}