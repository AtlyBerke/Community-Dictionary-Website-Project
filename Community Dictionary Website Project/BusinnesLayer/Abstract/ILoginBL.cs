using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
   public interface ILoginBL
    {
        Admin Login(Admin admin);

        Writer LoginWriter(Writer writer);

    }
}
