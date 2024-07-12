using MovieReviewApi.Models;
using System;

namespace MovieReviewApi.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public int MovieID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
