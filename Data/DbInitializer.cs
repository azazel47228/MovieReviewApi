
using MovieReviewApi.Data;
using MovieReviewApi.Models;

namespace MovieReviewApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MovieContext context)
        {
            if (context.Users.Any())
            {
                return; // БД уже инициализирована
            }

            var users = new User[]
            {
                new User { UserName = "user1", Email = "user1@example.com", Password = "password1", RegistrationDate = DateTime.Now },
                new User { UserName = "user2", Email = "user2@example.com", Password = "password2", RegistrationDate = DateTime.Now },
                new User { UserName = "user3", Email = "user3@example.com", Password = "password3", RegistrationDate = DateTime.Now },
                new User { UserName = "user4", Email = "user4@example.com", Password = "password4", RegistrationDate = DateTime.Now },
                new User { UserName = "user5", Email = "user5@example.com", Password = "password5", RegistrationDate = DateTime.Now }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var genres = new Genre[]
            {
                new Genre { Name = "Action" },
                new Genre { Name = "Comedy" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Sci-Fi" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Thriller" }
            };

            context.Genres.AddRange(genres);
            context.SaveChanges();

            var movies = new Movie[]
            {
                new Movie { Title = "Inception", Description = "A thief who steals corporate secrets through the use of dream-sharing technology.", ReleaseDate = new DateTime(2010, 7, 16), Rating = 5 },
                new Movie { Title = "The Dark Knight", Description = "Batman faces the Joker, a criminal mastermind.", ReleaseDate = new DateTime(2008, 7, 18), Rating = 5 },
                new Movie { Title = "Interstellar", Description = "A team of explorers travel through a wormhole in space.", ReleaseDate = new DateTime(2014, 11, 7), Rating = 5 },
                new Movie { Title = "The Godfather", Description = "The aging patriarch of an organized crime dynasty transfers control to his reluctant son.", ReleaseDate = new DateTime(1972, 3, 24), Rating = 5 },
                new Movie { Title = "Pulp Fiction", Description = "The lives of two mob hitmen, a boxer, and a pair of diner bandits intertwine.", ReleaseDate = new DateTime(1994, 10, 14), Rating = 5 },
                new Movie { Title = "The Matrix", Description = "A computer hacker learns about the true nature of reality and his role in the war against its controllers.", ReleaseDate = new DateTime(1999, 3, 31), Rating = 5 },
                new Movie { Title = "Forrest Gump", Description = "The presidencies of Kennedy and Johnson through the eyes of an Alabama man.", ReleaseDate = new DateTime(1994, 7, 6), Rating = 5 },
                new Movie { Title = "Fight Club", Description = "An insomniac office worker and a soap salesman form an underground fight club.", ReleaseDate = new DateTime(1999, 10, 15), Rating = 5 },
                new Movie { Title = "The Shawshank Redemption", Description = "Two imprisoned men bond over a number of years.", ReleaseDate = new DateTime(1994, 9, 23), Rating = 5 },
                new Movie { Title = "The Lord of the Rings: The Return of the King", Description = "Gandalf and Aragorn lead the World of Men against Sauron's army.", ReleaseDate = new DateTime(2003, 12, 17), Rating = 5 }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();

            var movieGenres = new MovieGenre[]
            {
                new MovieGenre { MovieID = movies[0].MovieID, GenreID = genres[4].GenreID }, // Inception - Sci-Fi
                new MovieGenre { MovieID = movies[1].MovieID, GenreID = genres[0].GenreID }, // The Dark Knight - Action
                new MovieGenre { MovieID = movies[2].MovieID, GenreID = genres[4].GenreID }, // Interstellar - Sci-Fi
                new MovieGenre { MovieID = movies[3].MovieID, GenreID = genres[2].GenreID }, // The Godfather - Drama
                new MovieGenre { MovieID = movies[4].MovieID, GenreID = genres[1].GenreID }, // Pulp Fiction - Comedy
                new MovieGenre { MovieID = movies[5].MovieID, GenreID = genres[4].GenreID }, // The Matrix - Sci-Fi
                new MovieGenre { MovieID = movies[6].MovieID, GenreID = genres[2].GenreID }, // Forrest Gump - Drama
                new MovieGenre { MovieID = movies[7].MovieID, GenreID = genres[5].GenreID }, // Fight Club - Romance
                new MovieGenre { MovieID = movies[8].MovieID, GenreID = genres[2].GenreID }, // The Shawshank Redemption - Drama
                new MovieGenre { MovieID = movies[9].MovieID, GenreID = genres[6].GenreID }  // The Lord of the Rings: The Return of the King - Thriller
            };

            context.MoviesGenres.AddRange(movieGenres);
            context.SaveChanges();

            var reviews = new Review[]
            {
                new Review { MovieID = movies[0].MovieID, UserID = users[0].UserID, ReviewText = "Amazing movie with mind-blowing visuals!", Rating = 5 },
                new Review { MovieID = movies[1].MovieID, UserID = users[1].UserID, ReviewText = "Best Batman movie ever!", Rating = 5 },
                new Review { MovieID = movies[2].MovieID, UserID = users[2].UserID, ReviewText = "A great exploration of space and time.", Rating = 5 },
                new Review { MovieID = movies[3].MovieID, UserID = users[3].UserID, ReviewText = "A masterpiece of crime drama.", Rating = 5 },
                new Review { MovieID = movies[4].MovieID, UserID = users[4].UserID, ReviewText = "Quentin Tarantino's best work.", Rating = 5 },
                new Review { MovieID = movies[5].MovieID, UserID = users[0].UserID, ReviewText = "A revolutionary sci-fi film.", Rating = 5 },
                new Review { MovieID = movies[6].MovieID, UserID = users[1].UserID, ReviewText = "A heartwarming story.", Rating = 5 },
                new Review { MovieID = movies[7].MovieID, UserID = users[2].UserID, ReviewText = "A dark yet captivating film.", Rating = 5 },
                new Review { MovieID = movies[8].MovieID, UserID = users[3].UserID, ReviewText = "One of the best films of all time.", Rating = 5 },
                new Review { MovieID = movies[9].MovieID, UserID = users[4].UserID, ReviewText = "An epic conclusion to the trilogy.", Rating = 5 }
            };

            context.Reviews.AddRange(reviews);
            context.SaveChanges();
        }
    }
}
