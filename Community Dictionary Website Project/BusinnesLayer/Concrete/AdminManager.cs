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
   public class AdminManager : IAdminBL
    {

        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAddBL(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDeleteBL(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void AdminUpdateBL(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public List<Admin> GetAdminListBL()
        {
            return _adminDal.List();
        }

        public Admin GetByIDBL(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }
    }
}
