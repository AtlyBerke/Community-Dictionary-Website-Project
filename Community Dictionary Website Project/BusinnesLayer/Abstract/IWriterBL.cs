using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
   public interface IWriterBL
    {
        List<Writer> GetListBL();
        void WriterAddBL(Writer writer);
        void WriterDeleteBL(Writer writer);
        void WriterUpdateBL(Writer writer);
        Writer GetByID(int id);
        List<Writer> GetListByIDBL(int id);

    }
}
