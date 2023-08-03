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
    public class WriterManager : IWriterBL
    {

        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public Writer GetByID(int id)
        {
            return _writerdal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetListBL()
        {
          return  _writerdal.List();
        }

        public List<Writer> GetListByIDBL(int id)
        {
            return _writerdal.List(x => x.WriterID == id && x.WriterStatus==true);
        }

        public void WriterAddBL(Writer writer)
        {
            _writerdal.Insert(writer);
        }

        public void WriterDeleteBL(Writer writer)
        {
            Context c = new Context();
            var writervalue = c.Writers.Where(x => x.WriterID == writer.WriterID);
            writer.WriterStatus = false;
            _writerdal.Update(writer);
        }

        public void WriterUpdateBL(Writer writer)
        {
            _writerdal.Update(writer);
        }
    }
}
