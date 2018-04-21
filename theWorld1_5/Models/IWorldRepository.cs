using System.Collections.Generic;
using System.Threading.Tasks;

namespace theWorld1_5.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();

        void AddTrip(Trip trip);

          Task <bool> SaveChangesAsync();
    }
}