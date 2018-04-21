using System.Collections.Generic;

namespace theWorld1_5.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
    }
}