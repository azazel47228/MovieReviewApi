using System;
using System.Collections.Generic;

namespace MovieReviewApi.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Session> Sessions { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
