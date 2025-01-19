using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _MessageLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
