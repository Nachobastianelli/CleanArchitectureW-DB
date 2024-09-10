using Domain.Entities;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReviewService
    {
        List<ReviewMovie> GetAll();
        ReviewMovie GetById(int id);
        void Create(int id, CreateReview dto);
        void Update (int id, UpdateReview dto);
        void Delete (int id);
    }
}
