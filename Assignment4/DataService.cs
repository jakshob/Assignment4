using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4;

namespace Assignment4
{
    public class DataService
    {


        public List<Category> GetCategories()
        {
            using (var db = new NorthwindContex())
            {
                return db.Categories.ToList();
            }
        }

    }
}
