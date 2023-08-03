using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IRepository<T>
    {
        //CRUD İŞLEMLER

        //LİSTELE
        List<T> List();

        //EKLEME
        void Insert(T p);

        //IDYE GÖRE DEĞER BULMA
        T Get(Expression<Func<T, bool>> filter);

        //SİLME
        void Delete(T p);

        //GÜNCELLEME
        void Update(T p);

        //ŞARTLI LİSTELEME
        List<T> List(Expression<Func<T, bool>> filter);

   
    }
}
