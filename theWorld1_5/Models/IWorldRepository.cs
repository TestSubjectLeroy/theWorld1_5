using System.Collections.Generic;
using System.Threading.Tasks;

namespace theWorld1_5.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        Trip GetTripNyName(string tripName);

        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop);
        void AddComment(string tripName, Comment newComment);
        Task <bool> SaveChangesAsync();
       
    }
}