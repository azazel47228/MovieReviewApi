using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReviewApi.Data;
using MovieReviewApi.Models;

namespace MovieReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenresController : ControllerBase
    {
        private readonly MovieContext _context;

        public MovieGenresController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/MovieGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGenre>>> GetMoviesGenres()
        {
            return await _context.MoviesGenres.ToListAsync();
        }

        // GET: api/MovieGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGenre>> GetMovieGenre(int id)
        {
            var movieGenre = await _context.MoviesGenres.FindAsync(id);

            if (movieGenre == null)
            {
                return NotFound();
            }

            return movieGenre;
        }

        // PUT: api/MovieGenres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieGenre(int id, MovieGenre movieGenre)
        {
            if (id != movieGenre.MovieID)
            {
                return BadRequest();
            }

            _context.Entry(movieGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieGenreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieGenres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieGenre>> PostMovieGenre(MovieGenre movieGenre)
        {
            _context.MoviesGenres.Add(movieGenre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieGenreExists(movieGenre.MovieID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieGenre", new { id = movieGenre.MovieID }, movieGenre);
        }

        // DELETE: api/MovieGenres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieGenre(int id)
        {
            var movieGenre = await _context.MoviesGenres.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            _context.MoviesGenres.Remove(movieGenre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieGenreExists(int id)
        {
            return _context.MoviesGenres.Any(e => e.MovieID == id);
        }
    }
}
