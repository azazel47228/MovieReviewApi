using MovieReviewApi.Models;

namespace MovieReviewApi.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int MovieID { get; set; }
        public int UserID { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
