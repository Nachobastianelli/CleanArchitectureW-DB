using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public Movie Create(CreateMovie dto)
        {
            if (dto == null) 
                throw new ArgumentNullException(nameof(dto));

            if (!ComporobarDuracion(dto.Duration))
                throw new ArgumentException("Duration must be between 1 and 300 minutes.");

            if (string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Description))
                throw new ArgumentException("All fiels must be complet!");

            var movie = new Movie
            {
                Description = dto.Description,
                Name = dto.Name,
                Duration = dto.Duration,
            };

            return _repository.Create(movie);
        }

        public void Delete(int id)
        {
            var movie = _repository.GetById(id) ?? throw new ArgumentNullException(nameof(id));

            _repository.Delete(id);
        }

        public List<Movie> GetAll()
        {
            return _repository.GetAll() ?? throw new ArgumentNullException(nameof(GetAll));
        }

        public Movie GetById(int id) 
        {
            return _repository.GetById(id) ?? throw new ArgumentNullException(nameof(GetById));
        }

        private const int _MaxDuracion = 300;

        private bool ComporobarDuracion(int duration)
        {
            return (duration > 0 && duration < _MaxDuracion);
        }

        public void Update(int id, UpdateMovie dto)
        {
            var movie = _repository.GetById(id) ?? throw new ArgumentNullException(nameof(id));

            if (!string.IsNullOrEmpty(dto.Description))
                movie.Description = dto.Description;

            if (!string.IsNullOrEmpty(dto.Name))
                movie.Name = dto.Name;
            if (dto.Duration == 0)
                dto.Duration = movie.Duration;

            if (ComporobarDuracion(dto.Duration)) 
                movie.Duration = dto.Duration;
            else
                throw new ArgumentException("Duration must be between 1 and 300 minutes.");

            _repository.Update(id, movie);
        }
    }
}
