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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public ActionResult<List<ReviewMovie>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<ReviewMovie> GetById([FromRoute] int id)
        {
            return _service.GetById(id);
        }

        [HttpPost("[action]/{id}")]
        public ActionResult Post([FromRoute] int id, [FromBody] CreateReview review)
        {
            _service.Create(id, review);
            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("[action]/{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateReview review)
        {
            _service.Update(id, review);
            return NoContent();
        }
    }
}
