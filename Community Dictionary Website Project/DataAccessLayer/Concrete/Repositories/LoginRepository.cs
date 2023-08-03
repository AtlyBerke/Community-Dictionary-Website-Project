using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class LoginRepository : ILoginDal
    {

        Context c = new Context();
        DbSet<Admin> _object;

        public LoginRepository()
        {
            _object = c.Set<Admin>();
        }

        public Admin Loginin(Expression<Func<Admin, bool>> filter)
        {
           return c.Admins.FirstOrDefault(filter);
        }

        public Writer LoginWriter(Expression<Func<Writer, bool>> filter)
        {
            return c.Writers.FirstOrDefault(filter);
        }
    }
}
