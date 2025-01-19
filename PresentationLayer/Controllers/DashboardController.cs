using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;
        private readonly IMessageService _messageService;

        public DashboardController(UserManager<AppUser> userManager, ICategoryService categoryService, IMessageService messageService)
        {
            _userManager = userManager;
            _categoryService = categoryService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            // Kullanıcıyı al
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            // Kullanıcıya ait mesajların sayısını al
            var myMessagesCount = _messageService.TGetMessagesByAppUserId(user.Id).Count().ToString();
            ViewBag.MessagesCount = myMessagesCount;

            // Okunmamış mesaj sayısını al
            var unreadMessagesCount = _messageService.TGetUnreadMessagesByAppUserId(user.Id).Count().ToString();
            ViewBag.UnreadMessagesCount = unreadMessagesCount;

            // Kullanıcının son mesajının kategorisini al
            var lastMessage = _messageService.TGetLastMessageByAppUserId(user.Id);
            ViewBag.LastMessagesCount =lastMessage;

            // Inbox mesaj sayısı
            var inboxMessagesCount = _messageService
                .TGetAll()
                .Count(); // Kullanıcının alıcı olduğu mesajların sayısı
            ViewBag.InboxMessagesCount = inboxMessagesCount;

            // Sendbox mesaj sayısı
            var sendboxMessagesCount = _messageService
                .TGetAll()
                .Count(); // Kullanıcının gönderici olduğu mesajların sayısı
            ViewBag.SentMessagesCount = sendboxMessagesCount;

            return View();
        }
    }
}
