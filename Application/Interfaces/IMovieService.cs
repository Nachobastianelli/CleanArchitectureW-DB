using Domain.Entities;
using Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        Movie Create(CreateMovie dto);
        void Update (int id, UpdateMovie dto);
        void Delete (int id);
    }
}
