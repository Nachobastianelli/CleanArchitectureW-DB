using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public Movie Create(Movie movie)
        {

            _context.Movies.Add(movie);

            _context.SaveChanges();

            return movie;
        }

        public void AddReview (int id, ReviewMovie review)
        {
            var movie = _context.Movies
                .Include(m => m.Review)
                .FirstOrDefault(x => x.Id == id)
                ?? throw new KeyNotFoundException($"Película con ID {id} no encontrada");

            movie.Review.Add(review);
            _context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();  
            }

        }

        public List<Movie> GetAll()
        {
            return _context.Movies
                 .Include(m => m.Review) 
                 .ToList();
        }

        public Movie GetById(int id)
        {
            var movie = _context.Movies
                .Include (m => m.Review)
                .FirstOrDefault(x => x.Id == id)
                ?? throw new KeyNotFoundException($"No se encontró la película con ID {id}");

            return movie;
        }

        public void Update(int id, Movie movie)
        {
            var existingMovie = _context.Movies.Find(id) ?? throw new KeyNotFoundException($"No se encontró la película con ID {id}");


            existingMovie.Description = movie.Description;
            existingMovie.Duration = movie.Duration;
            existingMovie.Name = movie.Name;
            
            _context.SaveChanges();
        }
    }
}
