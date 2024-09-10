using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMovieRepository
    {
        public Movie GetById(int id);
        public List<Movie> GetAll();
        public void Delete(int id);
        public void Update(int id,Movie movie);
        public Movie Create (Movie movie);  
        public void AddReview (int id, ReviewMovie review);
    }
}
