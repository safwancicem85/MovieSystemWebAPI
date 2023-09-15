using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSystem.DataAccessLayer.Context;
using MovieSystem.DataAccessLayer.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _context;
        
        public MovieController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _context.Movies
                .Where(x => x.IsActive && !x.IsDeleted).ToListAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive && !x.IsDeleted);
            return Ok(movie);
        }


        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie value)
        {
            await _context.AddAsync(value);
            await _context.SaveChangesAsync();

            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie value)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive && !x.IsDeleted);

            if (movie is null) return NotFound("Movie is not found!");

            movie.Title = value.Title;
            movie.Description = value.Description;
            movie.Rating = value.Rating;
            movie.Image = value.Image;
            movie.ModifiedTime = DateTime.Now;

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive && !x.IsDeleted);

            if (movie is null) return NotFound("Movie is not found!");

            movie.ModifiedTime = DateTime.Now;
            movie.IsDeleted = true;

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
