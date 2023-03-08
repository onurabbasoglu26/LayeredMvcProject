using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessagesListInbox(string p);
        List<Message> GetMessagesListSendbox(string p);
        Message GetMessageById(int id);
        void AddMessage(Message message);
        void RemoveMessage(Message message);
        void UpdateMessage(Message message);
    }
}
