using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultSkillsComponentPartial:ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultSkillsComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Services.ToList();
            return View(values);
        }
    }
}
