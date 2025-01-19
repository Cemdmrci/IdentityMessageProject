using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _MessageLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
