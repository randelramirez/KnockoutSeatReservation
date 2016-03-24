using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnockoutSeatReservation.Models
{
    public class DataContext : DbContext
    {
        public DbSet<SeatReservation> SeatReservations { get; set; }

        public DbSet<Meal> Meals { get; set; }
    }
}