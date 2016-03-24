using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutSeatReservation.Models
{
    public class SeatReservation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MealId { get; set; }

        public Meal Meal { get; set; }
    }
}