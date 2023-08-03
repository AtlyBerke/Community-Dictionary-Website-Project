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
    public class HeadingManager : IHeadingBL
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByIDBL(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetHeadingList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetHeadingListByCategory(int id)
        {
            return _headingDal.List(x => x.CategoryID == id);
        }

        public List<Heading> GetHeadingListByIDBL(int id)
        {
            return _headingDal.List(x=>x.WriterID==id);
        }

        public void HeadingAddBL(Heading heading)
        {
            heading.HeadingStatus = true;
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            heading.HeadingStatus = false;
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            heading.HeadingStatus = true;
            _headingDal.Update(heading);
        }
    }
}
