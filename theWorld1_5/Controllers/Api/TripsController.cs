using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [Route("api/trips")]
    public class TripsController : Controller
    {
        private IWorldRepository _repository;
        private ILogger<TripsController> _logger;

        public TripsController(IWorldRepository repository, ILogger<TripsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //GET

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetTripsByUsername(this.User.Identity.Name); 
                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));

            }
            catch (Exception ex)
            {
              
                _logger.LogError($"Failed to get all trips: {ex }");
                return BadRequest("Error occured");
               
            }
        }

        //POST
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]TripViewModel theTrip)
        {
            if (ModelState.IsValid)

            {
                //Save to Database
                var newTrip = Mapper.Map<Trip>(theTrip);


                newTrip.UserName = User.Identity.Name;

                _repository.AddTrip(newTrip);


                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
                }

                //else
                //{
                //    return BadRequest("Save changes Failed in database....");
                //}
            }

            return BadRequest("failed to save the trip");
        }

    }
}
