using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.Controllers
{
    public class MessageController : Controller
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            ViewData["ActiveMenu"] = "MessageList";
            ViewData["PageTitle"] = "Mesajlar";
            var values = _context.Messages.ToList();
            return View(values);
        }
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }
        public IActionResult MessageDetails(int id)
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            var value= _context.Messages.Find(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult ChangeIsRead(int id)
        {
            var values = _context.Messages.Find(id);

            // Eğer mesaj varsa
            if (values != null)
            {
                // Durumu tam tersine çevir
                values.IsRead = !values.IsRead;
                _context.SaveChanges();
            }

            // İşlem bitince tekrar detay sayfasına (veya listeye) geri dön
            return RedirectToAction("MessageList");
        }
    }
}
