using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddMessage(Message message)
        {
            _messageDal.Insert(message);
        }

        public Message GetMessageById(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetMessagesListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetMessagesListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void RemoveMessage(Message message)
        {
            _messageDal.Delete(message);
        }

        public void UpdateMessage(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
