using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface ILoginDal
    {
        Admin Loginin(Expression<Func<Admin, bool>> filter);

        Writer LoginWriter(Expression<Func<Writer, bool>> filter);
    }
}
