using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
   public interface IAdminBL
    {
        List<Admin> GetAdminListBL();
        void AdminAddBL(Admin admin);
        Admin GetByIDBL(int id);
        void AdminDeleteBL(Admin admin);
        void AdminUpdateBL(Admin admin);
    }
}
