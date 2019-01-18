using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task2.Models
{
    public class ConferenceRoomContext : DbContext
    {
        public ConferenceRoomContext(DbContextOptions<ConferenceRoomContext> options) : base(options)
        {

        }

        //zbiór pokoi?
        public DbSet<ConferenceRoom> Rooms {get; set;}
    }
}
