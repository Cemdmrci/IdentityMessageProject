using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> EditMyProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);//parantez bize oturum açan kullanıcının ismini verir
            UserEditViewModel model = new UserEditViewModel();
            model.Surname = values.Surname; //valueste oturum açan kullanıcının bilgileri vardır.
            model.Name = values.Name;
            model.Username = values.UserName;
            model.Email = values.Email;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMyProfile(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.UserName = model.Username;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);//bu kullanıcıyı bu şifreyle eşleştir.
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("CategoryList", "Category"/*, new { Area = "AreaAdı" }*/);//areaya gitmek istersek yaparız.
            }
            return View();
        }
    }
}
    
