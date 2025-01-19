using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> TGetMessagesInbox(int userId);
        List<Message> TGetMessagesSendbox(string senderMail);
        Message TGetByIdWithSender(int id);

        Message TMessageDetails(int id);
		List<Message> TGetTrashMessages(string receiverMail);
        List<Message> TGetMessagesByAppUserId(int UserId);
        List<Message> TGetUnreadMessagesByAppUserId(int UserId);
        List<Message> TGetLastMessageByAppUserId(int UserId);


    }
}
