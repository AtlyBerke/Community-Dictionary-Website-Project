using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
   public interface IContentServiceBL
    {
        List<Content> GetContentListBL();
        List<Content> GetSearchList(string p);
        List<Content> GetListByHeadingID(int id);
        void ContentAddBL(Content content);
        void ContentDeleteBL(Content content);
        void ContentUpdateBL(Content content);
        Content GetByID(int id);
        List<Content> GetListByWriterID(int id);
    }
}
