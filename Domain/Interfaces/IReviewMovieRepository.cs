using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReviewMovieRepository
    {
        public List<ReviewMovie> GetAll();
        public ReviewMovie Get(int id);
        public void Create (ReviewMovie reviewMovie);
        public void Update (int id ,ReviewMovie reviewMovie);
        public void Delete (int id);
    }
}
