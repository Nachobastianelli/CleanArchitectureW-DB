using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;
        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<Movie> GetById([FromRoute] int id)
        {
            return _service.GetById(id);
        }

        [HttpGet("[action]")]
        public ActionResult<List<Movie>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpDelete("[action]/{id}")]
        public ActionResult Delete([FromRoute] int id) 
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPost("[action]")]
        public ActionResult Create(CreateMovie movie)
        {
            _service.Create(movie);
            return NoContent();
        }

        [HttpPut("[action]/{id}")]
        public ActionResult Update(int id,UpdateMovie movie) 
        {
            _service.Update(id, movie);
            return NoContent();
        }
    }
}
