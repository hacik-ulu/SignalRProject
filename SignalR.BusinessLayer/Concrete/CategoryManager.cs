using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        // EfCategoryDal Repositories ile contexte(dbye bağlanıyor.)
        private readonly ICategoryDal _categoryService;

        public CategoryManager(ICategoryDal categoryService)
        {
            _categoryService = categoryService;
        }

        public void TAdd(Category entity)
        {
            _categoryService.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryService.Delete(entity);
        }

        public Category TGetById(int id)
        {
            return _categoryService.GetById(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryService.GetListAll();
        }

        public void TUpdate(Category entity)
        {
            _categoryService.Update(entity);
        }
    }
}
