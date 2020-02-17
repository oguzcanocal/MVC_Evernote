using MyEvernote.BusinessLayer.Abstract;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class CategoriesManager:ManagerBase<Category> 
    {
        public override int Delete(Category category)
        {
            //Kategori ile ilişkili notların silinmesi gerekiyor.

            return base.Delete(category);
        }
    }
}
