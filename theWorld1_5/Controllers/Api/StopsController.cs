using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theWorld1_5.Models;
using theWorld1_5.Services;
using theWorld1_5.ViewModels;

namespace theWorld1_5.Controllers.Api
{
    [Route("/api/trips/{tripName}/Stops")]
    public class StopsController :Controller
    {
        private GeoCoordsService _coordsService;
        private IWorldRepository _repository;
        private ILogger<StopsController> _logger;

        public StopsController(IWorldRepository repository, 
            ILogger<StopsController> logger,
            GeoCoordsService coordsService)
        {
            _coordsService = coordsService;
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = _repository.GetTripNyName(tripName);
                return Ok(Mapper.Map<IEnumerable<StopViewModel>>( trip.Stops.OrderBy(s => s.Order).ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get stops: {0}", ex);
            }
            return BadRequest("Failed to get stops");
        }
        [HttpPost("")]
        public async Task <IActionResult> Post(string tripName,[FromBody]StopViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var newStop = Mapper.Map<Stop>(vm);

                    //looking the geocode
                    var result = await _coordsService.GeoCoordsAsync(newStop.Name);
                    if (!result.Success)
                    {
                        _logger.LogError(result.Message);
                    }
                    else
                    {
                        newStop.Latitude = result.Latitude;
                        newStop.Longitude = result.Longitude;


                        //saving to database
                        _repository.AddStop(tripName, newStop);

                        if (await _repository.SaveChangesAsync())
                        {

                            return Created($"/api/trips.{tripName}/Stop/{newStop.Name}",
                            Mapper.Map<StopViewModel>(newStop));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get stops: {0}", ex);
            }
            return BadRequest("Failed to get stops");
        }
    }
}
