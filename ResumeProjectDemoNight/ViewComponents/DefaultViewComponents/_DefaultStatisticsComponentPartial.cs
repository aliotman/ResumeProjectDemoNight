using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultStatisticsComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Portfolios.Count();
            ViewBag.v2 = _context.Portfolios.Where(x => x.Status == true).Count();
            ViewBag.v3 = _context.Portfolios.Where(x => x.Status == false).Count();
            ViewBag.v4 = _context.Testimonials.Count();
            return View();
        }
    }
}
