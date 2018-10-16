using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4;
using Remotion.Linq.Utilities;

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

        public Category GetCategory(int index)
        {

            using (var db = new NorthwindContex())
            {
                return db.Categories.Find(index);
            }

        }

        public Category CreateCategory(string name, string description)
        {
            using (var db = new NorthwindContex())
            {
                var cat = new Category();
                List<Category> tempList = db.Categories.ToList<Category>();

                var item = tempList[tempList.Count - 1];


                db.Categories.Add(new Category()
                {
                    Id = item.Id + 1,
                    Name = name,
                    Description = description
                });

                db.SaveChanges();

                foreach (var category in db.Categories)
                {
                    if (category.Name == name) return category;
                }

                return cat;

            }
        }
        
        public bool DeleteCategory(int i)
        {
            using (var db = new NorthwindContex())
            {
                foreach (var elem in db.Categories)
                {
                    if (elem.Id == i)
                    {
                        db.Categories.Remove(elem);
                        db.SaveChanges();
                        return true;
                    }
                    else return false;
                }

                return false;

            }
        }
    }
}
