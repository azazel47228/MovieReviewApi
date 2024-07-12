using System;
using System.Collections.Generic;

namespace MovieReviewApi.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }

        public ICollection<Session> Sessions { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
