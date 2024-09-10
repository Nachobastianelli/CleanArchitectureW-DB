using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewMovieRepository _repository;
        private readonly IMovieRepository _movieRepository;
        public ReviewService( IReviewMovieRepository repository, IMovieRepository movieRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;

        }
        public void Create(int id, CreateReview dto)
        {
            if (dto == null) { throw new ArgumentNullException(nameof(dto));}

            var movie = _movieRepository.GetById(id) ?? throw new KeyNotFoundException("Movie not found");

            var review = new ReviewMovie
            {
                IdMovie = id,
                Comment = dto.Comment,
                Valoration = dto.Valoration,     
            };

            
            _movieRepository.AddReview(id, review);

        }

        public void Delete(int id)
        {
            var review = _repository.Get(id)
                ?? throw new KeyNotFoundException($"No se encontró la reseña con ID {id}");

            
            _repository.Delete(id);
        }

        public List<ReviewMovie> GetAll()
        {
            return _repository.GetAll();
        }

        public ReviewMovie GetById(int id)
        {
            return _repository.Get(id)
                ?? throw new KeyNotFoundException($"No se encontró la reseña con ID {id}");
        }

        public void Update(int id, UpdateReview dto)
        {

            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var review = _repository.Get(id) ?? throw new KeyNotFoundException($"No se encontró la reseña con ID {id}");

            if (!string.IsNullOrEmpty(dto.Comment))
            {
                review.Comment = dto.Comment;
            }

            if (dto.Valoration.HasValue) 
            {
                review.Valoration = dto.Valoration.Value;
            }

            _repository.Update(id, review);
        }
    }
}
