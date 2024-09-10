using Domain.Entities;
using Domain.Interfaces;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ReviewMovieRepository : IReviewMovieRepository
    {
        private readonly AppDbContext _context;

        public ReviewMovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create( ReviewMovie review)
        {

            _context.Reviews.Add(review);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = _context.Reviews.Find(id) ?? throw new KeyNotFoundException($"No se encontró la resenia con ID {id}");

            _context.Reviews.Remove(comment);

            _context.SaveChanges();
        }

        public ReviewMovie Get(int id)
        {
            var comment = _context.Reviews.Find(id) ?? throw new KeyNotFoundException($"No se encontró la resenia con ID {id}");

            return comment;
        }

        public List<ReviewMovie> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public void Update(int id, ReviewMovie review)
        {
            var comment = _context.Reviews.Find(id) ?? throw new KeyNotFoundException($"No se encontró la resenia con ID {id}");


            comment.Valoration = review.Valoration;
            comment.Comment = review.Comment;

            _context.SaveChanges();
        }
    }
}
