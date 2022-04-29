using System;
using System.Collections.Generic;
using System.Text;

namespace Feedbacks.Model.Feedback
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string Feedbacks { get; set; }
        public int Rating { get; set; }
        public int QuestionId { get; set; }


    }
}
