using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using BusinessLayer.ValidationRules.MessageValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        private readonly ICategoryService _categoryService;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageService.TGetMessagesInbox(user.Id);
            return View(messages);
        }
        public async Task<IActionResult> Sendbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var message = _messageService.TGetMessagesSendbox(user.Email);
            return View(message);
        }
        [HttpGet]
        public IActionResult Send()
        {
			// Kategorileri al ve ViewBag'e gönder
			var categories = _categoryService.TGetAll();
			List<SelectListItem> categoryTypes = categories.Select(x => new SelectListItem
			{
				Text = x.CategoryName.ToString(),
				Value = x.CategoryId.ToString()
			}).ToList();
			ViewBag.CategoryTypes = categoryTypes;

			// Kullanıcıları al ve ViewBag'e gönder
			var users = _userManager.Users.Select(user => new SelectListItem
			{
				Text = user.Email, // Kullanıcı e-posta adresi veya ismi
				Value = user.Email // Kullanıcının e-posta adresi
			}).ToList();
			ViewBag.Receiver = users;

			return View();
		}
		[HttpPost]
        public async Task<IActionResult> Send(Message message)
        {
			var user = await _userManager.FindByNameAsync(User.Identity.Name);

			message.SenderMail = user.Email;
			message.CreatedAt = DateTime.Now;
			message.AppUserId = user.Id;
			_messageService.TGetMessagesSendbox(message.SenderMail);
			return RedirectToAction("Sendbox");
		}
        public IActionResult MessageDetail(int id)
        {
            var message = _messageService.TGetById(id);
            return View(message);
        }
		public async Task<IActionResult> Trash()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);  // Kullanıcıyı bul
			var trashMessages = _messageService.TGetTrashMessages(user.Email);  // Çöp kutusundaki mesajları al

			return View(trashMessages);  // View'e çöp kutusu mesajlarını gönder
		}

	}
	}
	
	
    





