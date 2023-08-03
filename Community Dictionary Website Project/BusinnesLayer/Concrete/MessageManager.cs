using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class MessageManager : IMessageBL
    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByIDBL(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetInboxMessageListBL(string p)
        {
            return _messageDal.List(x=>x.ReceiverMail== p);
        }

        public List<Message> GetSendboxMessageListBL(string p)
        {
            return _messageDal.List(x => x.SenderMail==p);
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDeleteBL(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdateBL(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
