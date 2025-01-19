using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public Message TDeleteMessage(int userid, int messageid)
        {
           return _messageDal.DeleteMessage(userid,messageid);
        }

        public List<Message> TGetAll()
        {
            return _messageDal.GetAll();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public Message TGetByIdWithSender(int id)
        {
            return _messageDal.GetByIdWithSender(id);
        }

        public List<Message> TGetLastMessageByAppUserId(int UserId)
        {
            return _messageDal.GetLastMessageByAppUserId(UserId);
        }

        public List<Message> TGetMessagesByAppUserId(int UserId)
        {
            return _messageDal.GetMessagesByAppUserId(UserId);
        }

        public List<Message> TGetMessagesInbox(int userId)
        {
            return _messageDal.GetMessagesInbox(userId);
        }

        public List<Message> TGetMessagesSendbox(string senderMail)
        {
            return _messageDal.GetMessagesSendbox(senderMail);
        }

        public List<Message> TGetTrashMessages(string receiverMail)
        {
            return _messageDal.GetTrashMessages(receiverMail);
        }

        public List<Message> TGetUnreadMessagesByAppUserId(int UserId)
        {
            return _messageDal.GetUnreadMessagesByAppUserId(UserId);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public Message TMessageDetails(int id)
        {
            return _messageDal.MessageDetails(id);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
