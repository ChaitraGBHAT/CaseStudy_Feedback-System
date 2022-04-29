using System;
using System.Collections.Generic;
using System.Text;

namespace Feedbacks.Model.Feedback
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Feedbacks { get; set; }
        public int Rating { get; set; }
        public string Question { get; set; }
        public int EmpId { get; set; }
    }
}
