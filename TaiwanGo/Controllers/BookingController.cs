using Microsoft.AspNetCore.Mvc;
using TaiwanGo.Models.Domain;
using TaiwanGo.Models.Wrap;

namespace TaiwanGo.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult List()
        {
            TaiwanGoContext db = new TaiwanGoContext();
            var bookings = db.TBookings
               .Select(b => new CBookingWrap(b))
               .ToList();
            return View(bookings);
        }
    }
}
