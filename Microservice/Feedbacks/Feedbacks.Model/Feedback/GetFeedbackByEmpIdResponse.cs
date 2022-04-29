using System;
using System.Collections.Generic;
using System.Text;

namespace Feedbacks.Model.Feedback
{
    public class GetFeedbackByEmpIdResponse
    {
        public List<ReviewList> Review { get; set; }
    }

    public class ReviewList
    {
        public string Question { get; set; }
        public string Feedbacks { get; set; }
        public int Rating { get; set; }
        
    }
}
