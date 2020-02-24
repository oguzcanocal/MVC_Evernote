using MyEvernote.BusinessLayer;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace MVC_Evernote.Models
{
    public class CacheHelper
    {

        public static List<Category> GetCategoriesFromCache()
        {
            var result = WebCache.Get("category-cache") as List<Category>;

            if (result == null)
            {
                CategoriesManager categoryManager = new CategoriesManager();
                result = categoryManager.List();
                WebCache.Set("category-cache", result, 20, true);

                
            }

            return result;

        }

        public static void RemoveCategoriesFromCache()
        {
            Remove("category-cache");
        }


        public static void Remove(string key)
        {
            WebCache.Remove(key);
        } 
    }
}