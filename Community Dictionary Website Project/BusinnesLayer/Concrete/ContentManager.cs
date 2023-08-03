using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class ContentManager : IContentServiceBL
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAddBL(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDeleteBL(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdateBL(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetContentListBL()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriterID(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        //ARAMA İŞLEMİ
        public List<Content> GetSearchList(string p)
        {
            return _contentDal.List(x => x.ContentValue.Contains(p));
        }
    }
}
