using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _MessageLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}

