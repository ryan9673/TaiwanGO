using Microsoft.AspNetCore.Mvc;
using TaiwanGo.Models.Domain;
using TaiwanGo.ViewModels;

namespace TaiwanGo.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult List(CKeywordViewModel p)
        {
            TaiwanGoContext db = new TaiwanGoContext();
            IEnumerable<TTicket> datas = null;
            if (string.IsNullOrEmpty(p.txtKeyword))
            {
                datas = from ticket in db.TTickets
                        select ticket;
            }
            else
                datas = db.TTickets.Where(ticket => ticket.FTicketName.Contains(p.txtKeyword));
                
            return View(datas);
        }
    }
}
