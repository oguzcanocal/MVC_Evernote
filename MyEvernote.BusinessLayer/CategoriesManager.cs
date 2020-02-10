using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class CategoriesManager
    {
        private Repository<Category> repo_cat = new Repository<Category>();

        public List<Category> GetCategories()
        {
            return repo_cat.List();
        }

        public Category GetCategoryId(int id)
        {
            return repo_cat.Find(x => x.Id == id);
        }

    }
}
