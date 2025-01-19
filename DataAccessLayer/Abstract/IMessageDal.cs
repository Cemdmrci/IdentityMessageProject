using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IMessageDal:IGenericDal<Message>
    {
        List<Message> GetMessagesInbox(int userId);
        List<Message> GetMessagesSendbox(string senderMail);
        Message GetByIdWithSender(int id);
        Message MessageDetails(int id);
		List<Message> GetTrashMessages(string receiverMail);
        List<Message> GetMessagesByAppUserId(int UserId);
        List<Message> GetUnreadMessagesByAppUserId(int UserId);
        List<Message> GetLastMessageByAppUserId(int UserId);

        Message DeleteMessage(int userid,int messageid);

    }
}
