using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContex())
            {
                //Categories(db);

                foreach (var elem in db.Products.Include(x => x.Category).Take(5))
                {
                    Console.WriteLine(elem.Category.Name);   
                }
            }
        }

        private static void Categories(NorthwindContex db)
        {
            ShowCategories(db);

            //CreateCategory(db);

            var cat = db.Categories.FirstOrDefault(x => x.Id == 12);

            if (cat != null)
            {
                cat.Name = "Testing updated";

                db.SaveChanges();
            }


            ShowCategories(db);
        }

        private static void CreateCategory(NorthwindContex db)
        {
            db.Categories.Add(new Category()
            {
                Id = 12,
                Name = "Testing"
            });

            db.SaveChanges();
        }

        private static void ShowCategories(NorthwindContex db)
        {
            foreach (var elem in db.Categories)
            {
                Console.WriteLine(elem.Name);
            }
        }
    }
}
