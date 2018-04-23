using System.Collections.Generic;
using System.Threading.Tasks;

namespace theWorld1_5.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetTripsByUsername(string username);

        Trip GetTripNyName(string tripName);
        Trip GetUserTripByName(string tripName, string username);

        void AddTrip(Trip trip);
        void AddStop(string tripName, Stop newStop, string username );
        void AddComment(string tripName, Comment newComment);
        Task <bool> SaveChangesAsync();
     
    }
}