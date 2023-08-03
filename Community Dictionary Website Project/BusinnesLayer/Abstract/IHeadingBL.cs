using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
   public interface IHeadingBL
    {
        List<Heading> GetHeadingList();
        List<Heading> GetHeadingListByIDBL(int id);
        List<Heading> GetHeadingListByCategory(int id);
        void HeadingAddBL(Heading heading);
        Heading GetByIDBL(int id);
        void HeadingUpdate(Heading heading);
        void HeadingDelete(Heading heading);

    }
}
