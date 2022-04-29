using System;
using System.Collections.Generic;
using System.Text;

namespace Feedbacks.Model.Questions
{
    public class GetQuestionsByIdResponse
    {
        public string CategoryName { get; set; }
        public List<Questions> questions { get; set; }
    }
}
