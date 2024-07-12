document.addEventListener('DOMContentLoaded', function () {
    const registerButton = document.getElementById('register-button');
    const moviesButton = document.getElementById('movies-button');
    const registrationSection = document.getElementById('registration-section');
    const moviesSection = document.getElementById('movies-section');
    const commentsSection = document.getElementById('comments-section');
    const registrationForm = document.getElementById('registration-form');
    const commentForm = document.getElementById('comment-form');
    const genreSelect = document.getElementById('genre-select');
    const moviesList = document.getElementById('movies-list');
    const commentsList = document.getElementById('comments-list');

    registerButton.addEventListener('click', () => {
        registrationSection.classList.remove('hidden');
        moviesSection.classList.add('hidden');
        commentsSection.classList.add('hidden');
    });

    moviesButton.addEventListener('click', async () => {
        registrationSection.classList.add('hidden');
        moviesSection.classList.remove('hidden');
        commentsSection.classList.add('hidden');
        await loadMovies();
    });

    registrationForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const formData = new FormData(registrationForm);
        const data = Object.fromEntries(formData.entries());

        const response = await fetch('/api/users', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert('Регистрация успешна');
            registrationForm.reset();
        } else {
            alert('Ошибка регистрации');
        }
    });

    commentForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const formData = new FormData(commentForm);
        const data = Object.fromEntries(formData.entries());

        const response = await fetch('/api/reviews', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            alert('Комментарий добавлен');
            commentForm.reset();
            await loadComments(data['comment-movie-id']);
        } else {
            alert('Ошибка добавления комментария');
        }
    });

    genreSelect.addEventListener('change', async () => {
        await loadMovies();
    });

    async function loadMovies() {
        const genre = genreSelect.value;
        const response = await fetch('/api/movies');
        const movies = await response.json();

        moviesList.innerHTML = '';

        movies.forEach(movie => {
            if (genre === 'all' || movie.movieGenres.some(g => g.genre.name === genre)) {
                const movieElement = document.createElement('div');
                movieElement.className = 'movie';
                movieElement.dataset.id = movie.movieID;

                const title = document.createElement('h2');
                title.textContent = movie.title;
                movieElement.appendChild(title);

                const description = document.createElement('p');
                description.textContent = movie.description;
                movieElement.appendChild(description);

                const genres = document.createElement('p');
                genres.textContent = 'Жанры: ' + movie.movieGenres.map(g => g.genre.name).join(', ');
                movieElement.appendChild(genres);

                const commentButton = document.createElement('button');
                commentButton.textContent = 'Комментарии';
                commentButton.addEventListener('click', async () => {
                    registrationSection.classList.add('hidden');
                    moviesSection.classList.add('hidden');
                    commentsSection.classList.remove('hidden');
                    document.getElementById('comment-movie-id').value = movie.movieID;
                    await loadComments(movie.movieID);
                });
                movieElement.appendChild(commentButton);

                moviesList.appendChild(movieElement);
            }
        });
    }

    async function loadComments(movieID) {
        const response = await fetch(`/api/reviews?movieID=${movieID}`);
        const comments = await response.json();

        commentsList.innerHTML = '';

        comments.forEach(comment => {
            const commentElement = document.createElement('div');
            commentElement.className = 'comment';

            const user = document.createElement('p');
            user.textContent = 'Пользователь: ' + comment.user.userName;
            commentElement.appendChild(user);

            const text = document.createElement('p');
            text.textContent = 'Комментарий: ' + comment.reviewText;
            commentElement.appendChild(text);

            const rating = document.createElement('p');
            rating.textContent = 'Оценка: ' + comment.rating;
            commentElement.appendChild(rating);

            commentsList.appendChild(commentElement);
        });
    }

    async function loadGenres() {
        const response = await fetch('/api/genres');
        const genres = await response.json();

        genres.forEach(genre => {
            const option = document.createElement('option');
            option.value = genre.name;
            option.textContent = genre.name;
            genreSelect.appendChild(option);
        });
    }

    loadGenres();
});
