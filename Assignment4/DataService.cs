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
                    Id = db.Categories.Max(x => x.Id)+1,
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

        public bool UpdateCategory(int inputCatId, string updateName, string updateDesc) {

            using (var db = new NorthwindContex()) {

                var record = db.Categories.FirstOrDefault(r => r.Id == inputCatId);
                if (record != null)
                {
                    var chosenCategory = from cat in db.Categories
                                         where cat.Id == inputCatId
                                         select cat;

                    foreach (Category cat in chosenCategory)
                    {
                        cat.Name = updateName;
                        cat.Description = updateDesc;
                    }
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Product GetProduct(int inputProductId) {

            using (var db = new NorthwindContex())
            {
                Product tempProduct = db.Products.Find(inputProductId);
                tempProduct.Category = db.Categories.Find(tempProduct.CategoryId);
                return tempProduct;
            }

        }

		public List<Product> GetProductByName(string searchQueryString){
			using (var db = new NorthwindContex()){
				var productList = new List<Product>{};
				foreach (Product p in db.Products){
					if(p.Name.ToLower().Contains(searchQueryString)){
						productList.Add(p);
					}
				}
				return productList;
			}
		}

		public List<Product> GetProductByCategory(int inputCategoryId) {

			using (var db = new NorthwindContex()) {
                
                //OrderBy fordi databasen var lidt fucked med underlige tegn og rækkefølger..
                var listByCategory = db.Products.OrderBy(x => x.Id)
                    .Where(p => p.CategoryId == inputCategoryId);
  

                foreach (Product prod in listByCategory) {

					prod.Category = db.Categories.Find(prod.CategoryId);
				}

				var outputListByCategory = listByCategory.ToList();


				return outputListByCategory;
			}

		}

		public Order GetOrder(int inputOrderId ) {

			using (var db = new NorthwindContex()) {
				Order tempOrder = db.Orders.Find(inputOrderId);
				foreach (OrderDetails OrdDet in db.OrderDetailsTable) {
					if(OrdDet.OrderId == inputOrderId) {
						tempOrder.OrderDetails.Add(OrdDet);
					}
				}
				return tempOrder;
			}
		}
		
	}
}
