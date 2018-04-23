using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theWorld1_5.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;

        public WorldRepository(WorldContext context)
        {
            _context = context;

        }

        public void AddComment(string tripName, Comment newComment)
        {
            var trip = GetTripNyName(tripName);
            if (trip != null)

            {
                trip.Comments.Add(newComment);
                _context.Comments.Add(newComment);
            }
        }

        public void AddStop(string tripName, Stop newStop, string username)
        {
            var trip = GetUserTripByName(tripName, username);
            if (trip != null)

            {
                trip.Stops.Add(newStop);
              //  _context.Stops.Add(newStop);
            }
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.Trips.ToList();
        }

        public Trip GetTripNyName(string tripName)
        {
            return _context.Trips
                .Include(t => t.Comments)
                .Include(t => t.Stops)
                .Where(t => t.Name == tripName)
                 .FirstOrDefault();
        }

        public IEnumerable<Trip> GetTripsByUsername(string name)
        {
            return _context
                .Trips
                 .Include(t => t.Comments)
                .Include(t => t.Stops)
                .Where(t => t.UserName == name)
                .ToList();
        }

        public Trip GetUserTripByName(string tripName, string username)
        {

            return _context.Trips
                 .Include(t => t.Comments)
                 .Include(t => t.Stops)
                 .Where(t => t.Name == tripName && t.UserName == username)
                  .FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        
    }
}
