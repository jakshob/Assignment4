﻿using System;
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

        public Category GetCategory(int inputCatId) {

            using (var db = new NorthwindContex())
            {
                return db.Categories.Find(inputCatId);
            }
        }

        public Category CreateCategory(string categoryName, string catDescription) {

            using (var db = new NorthwindContex())
            {
                /*
                int newId = Convert.ToInt32(from cat in db.Categories
                             orderby cat.Id descending
                             select cat.Id);
                */
                Category newCat;
                db.Categories.Add(newCat = new Category()
                {

                    //ÆNDRE! Det må ikke være hardcoded
                    Id = 9,
                    Name = categoryName,
                    Description = catDescription

                });
                db.SaveChanges();
                return newCat;
            }
            
        }

        public bool DeleteCategory(int inputCatId) {

            using (var db = new NorthwindContex())
            {

                var record = db.Categories.FirstOrDefault(r => r.Id == inputCatId);
                if (record != null)
                {

                    var cat = db.Categories.First(c => c.Id == inputCatId);
                    db.Categories.Remove(cat);
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }




        }
    }
}
