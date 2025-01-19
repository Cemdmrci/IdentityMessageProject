using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using MyBlogNight.EntityLayer.Concrete;
//using MyBlogNight.PresentationLayer.Models;
using PresentationLayer.Models;

namespace MyBlogNight.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() //.Net core projesi olduğundan IActionresult
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model) //programlamada birden fazla işin yapılması async
        {
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                UserName = model.Username,
                ImageUrl = "test"
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);//password appuserla beraber kabul edilmedğinden böyle yaptık şifreyi şifreler formatta göndermek istiyorum.heşleyerek göndermesiiçin createasync içinde gönderiyoruz.

            if (result.Succeeded) //Kullanıcı başarılı bir şekilde kayıt işlemi gerçekleştirirse
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)//resulttan gelen hataları bana gösterir.
                {
                    ModelState.AddModelError("", item.Description);//Modelstate bize formumuzdaki şeylerin doğru olup olmadığını belirler.
                }
            }
            return View();
        }
    }
}

