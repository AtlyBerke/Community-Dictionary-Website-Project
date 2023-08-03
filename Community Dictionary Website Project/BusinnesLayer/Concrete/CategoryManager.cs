using BusinnesLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;

namespace BusinnesLayer.Concrete
{
    public class CategoryManager : ICategoryBL
    {

        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategoryAddBL(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDeleteBL(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdateBL(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetByIDBL(int id)
        {
            return _categorydal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetCategoryListBL()
        {
            return _categorydal.List();
        }


        

    }
}
