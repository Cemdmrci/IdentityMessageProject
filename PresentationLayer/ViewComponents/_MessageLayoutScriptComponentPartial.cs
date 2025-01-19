using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents
{
    public class _MessageLayoutScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
