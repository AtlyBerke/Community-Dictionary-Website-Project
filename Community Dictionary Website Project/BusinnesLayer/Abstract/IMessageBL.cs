using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
   public interface IMessageBL
    {
        List<Message> GetInboxMessageListBL(string p);
        List<Message> GetSendboxMessageListBL(string p);
        void MessageAddBL(Message message);
        Message GetByIDBL(int id);
        void MessageDeleteBL(Message message);
        void MessageUpdateBL(Message message);
    }
}
