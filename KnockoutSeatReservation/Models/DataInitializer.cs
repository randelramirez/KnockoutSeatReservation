using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnockoutSeatReservation.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var meals = new List<Meal>();
            meals.Add(new Meal { Name = "Quarter Pouder", Price = 200.765 });
            meals.Add(new Meal { Name = "Cheesy Bacon Mushroom Champ", Price = 199 });
            meals.Add(new Meal { Name = "Big Mac", Price = 250 });
            meals.Add(new Meal { Name = "Coke Float", Price = 40 });
            meals.Add(new Meal { Name = "Two Piece Chicken", Price = 147.897 });

            var seats = new List<SeatReservation>();
            seats.Add(new SeatReservation { Name = "Randel Ramirez", Meal = meals[0] });
            seats.Add(new SeatReservation { Name = "Stephen Curry", Meal = meals[1] });
            seats.Add(new SeatReservation { Name = "Kyrie Irving", Meal = meals[1] });
            seats.Add(new SeatReservation { Name = "LeBron James", Meal = meals[2] });
            seats.Add(new SeatReservation { Name = "Kevin Durant", Meal = meals[3] });
            seats.Add(new SeatReservation { Name = "Andrew Wiggins", Meal = meals[1] });
            seats.Add(new SeatReservation { Name = "Anthony Davis", Meal = meals[4] });
            seats.Add(new SeatReservation { Name = "Russel Westbrook", Meal = meals[1] });

            meals.ForEach(m => context.Meals.Add(m));
            seats.ForEach(s => context.SeatReservations.Add(s));
            context.SaveChanges();
        }
    }
}