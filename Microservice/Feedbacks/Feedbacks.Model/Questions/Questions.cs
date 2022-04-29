using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Feedbacks.Model.Questions
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int CategoryId { get; set; }
    }
}
