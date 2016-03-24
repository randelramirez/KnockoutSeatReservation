using KnockoutSeatReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutSeatReservation.Controllers
{
    public class MealsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Meals
        public JsonResult GetAllMeals()
        {
            var x = db.Meals.ToList();
            return Json(x, JsonRequestBehavior.AllowGet);
        }
    }
}