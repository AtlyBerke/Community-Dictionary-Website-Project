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
    public class LoginManager : ILoginBL
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public Admin Login(Admin admin)
        {
            return _loginDal.Loginin(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
        }

        public Writer LoginWriter(Writer writer)
        {
            return _loginDal.LoginWriter(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        }
    }
}
