using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theWorld1_5.Models
{
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; } 
    }
}
