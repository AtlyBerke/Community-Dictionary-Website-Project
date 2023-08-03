using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IAboutBL
    {
        List<About> ListAboutBL();
        void AboutAddBL(About about);
        void AboutDeleteBL(About about);
        void AboutUpdateBL(About about);
        About GetByID(int id);
    }
}
