using System;
using System.Collections.Generic;
using System.Text;

namespace Feedbacks.Model.Feedback
{
    public class PostFeedbackResponse
    {
        public List<Feedback> feedbacks { get; set; }
        public string message { get; set; }
    }
}
