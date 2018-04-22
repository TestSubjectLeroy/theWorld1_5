using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theWorld1_5.Models;
using theWorld1_5.ViewModels;

namespace theWorld1_5.Controllers.Api
{
    [Route("/api/trips/{tripName}/Comments")]
    public class CommentsController : Controller
    {
        private IWorldRepository _repository;
        private ILogger<CommentsController> _logger;

        public CommentsController(IWorldRepository repository, ILogger<CommentsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = _repository.GetTripNyName(tripName);
                return Ok(Mapper.Map<IEnumerable<CommentViewModel>>(trip.Comments.OrderBy(s => s.Order).ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get the Comments: {0}", ex);
            }
            return BadRequest("Failed to get Comments");
        }


        public async Task<IActionResult> Post(string tripName, [FromBody]CommentViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var newComment = Mapper.Map<Comment>(vm);

                    //looking the geocode

                    //saving to database
                    _repository.AddComment(tripName, newComment);

                    if (await _repository.SaveChangesAsync())
                    {

                        return Created($"/api/trips.{tripName}/Comments/{newComment.UserName}",
                        Mapper.Map<CommentViewModel>(newComment));

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get comment: {0}", ex);
            }
            return BadRequest("Failed to get comment");
        }
    }
}
