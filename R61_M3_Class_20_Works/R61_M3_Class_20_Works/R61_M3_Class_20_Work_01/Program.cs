using R61_M3_Class_20_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R61_M3_Class_20_Work_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
               new Product{ ProductID = 1,
                Name = "LL Road Frame - Red, 44",
                ProductNumber = "FR-R38R-44",
                Color = "Red",
                StandardCost = 187.1571,
                ListPrice = 337.22,
                Size = 44,
                Weight = 1052.33,
                ProductCategoryID = 1,
                ProductModelID =1 },

 new Product{ProductID = 2,
                Name = "LL Road Frame - Red, 48",
                ProductNumber = "FR-R38R-48",
                Color = "Red",
                StandardCost = 187.1571,
                ListPrice = 337.22,
                Size = 48,
                Weight = 1070.47,
                ProductCategoryID = 1,
                ProductModelID = 2 },

 new Product{ProductID = 3,
                Name = "LL Road Frame - Red, 52",
                ProductNumber = "FR-R38R-52",
                Color = "Red",
                StandardCost = 187.1571,
                ListPrice = 337.22,
                Size = 52,
                Weight = 1088.62,
                ProductCategoryID = 2,
                ProductModelID = 2 },

 new Product{ProductID = 4,
                Name = "LL Road Frame - Red, 58",
                ProductNumber = "FR-R38R-58",
                Color = "Red",
                StandardCost = 187.1571,
                ListPrice = 337.22,
                Size = 58,
                Weight = 1115.83,
                ProductCategoryID = 2,
                ProductModelID = 3 },

 new Product{ProductID = 5,
                Name = "LL Road Frame - Red, 60",
                ProductNumber = "FR-R38R-60",
                Color = "Red",
                StandardCost = 187.1571,
                ListPrice = 337.22,
                Size = 60,
                Weight = 1124.9,
                ProductCategoryID = 3,
                ProductModelID = 3 },

 new Product{ProductID = 6,
                Name = "LL Road Frame - Red, 62",
                ProductNumber = "FR-R38R-62",
                Color = "Red",
                StandardCost = 187.1571,
                ListPrice = 337.22,
                Size = 62,
                Weight = 1133.98,
                ProductCategoryID = 3,
                ProductModelID = 4 },

 new Product{ProductID = 7,
                Name = "ML Road Frame - Red, 44",
                ProductNumber = "FR-R72R-44",
                Color = "Red",
                StandardCost = 352.1394,
                ListPrice = 594.83,
                Size = 44,
                Weight = 1006.97,
                ProductCategoryID = 5,
                ProductModelID = 4 },
 new Product{ProductID = 8,
                Name = "ML Road Frame - Red, 48",
                ProductNumber = "FR-R72R-48",
                Color = "Red",
                StandardCost = 352.1394,
                ListPrice = 594.83,
                Size = 48,
                Weight = 1025.11,
                ProductCategoryID = 5,
                ProductModelID = 5 }
            };
            List<ProductCategory> categories = new List<ProductCategory>()
            {
               new ProductCategory{ ProductCategoryID = 1,
                Name = "Bikes" },
                new ProductCategory{ProductCategoryID = 2,
                Name = "Components" },
                new ProductCategory{ProductCategoryID = 3,
                Name = "Clothing" },
                new ProductCategory{ProductCategoryID = 4,
                Name = "Accessories" },
                new ProductCategory{ProductCategoryID = 5,
                Name = "Mountain Bikes" } 
            };
            List<ProductModel> models = new List<ProductModel>() {
               new ProductModel{ ProductModelID = 1,
                Name = "Classic Vest" },
                new ProductModel{ProductModelID = 2,
                Name = "Cycling Cap" },
                new ProductModel{ProductModelID = 3,
                Name = "Full-Finger Gloves" },
                new ProductModel{ProductModelID = 4,
                Name = "Half-Finger Gloves" },
                new ProductModel{ProductModelID = 5,
                Name = "HL Mountain Frame" }

            };
            //Query
            var q1 = from p in products
                     join c in categories on p.ProductCategoryID equals c.ProductCategoryID
                     join m in models on p.ProductModelID equals m.ProductModelID
                     select new { p.Name, Model = m.Name, Category = c.Name, p.StandardCost, p.ListPrice, p.Color, p.Size, p.Weight };
            foreach (var p in q1)
            {
                Console.WriteLine($"{p.Name}, ModeL: {p.Model}, Category: {p.Category}, {p.StandardCost}, {p.ListPrice}, {p.Size}, {p.Color}, {p.Weight}");
            }
            Console.WriteLine();
            products.Join(categories,
                p => p.ProductCategoryID,
                c => c.ProductCategoryID,
                (p, c) => new { p, c })
                .Join(models,
                pc => pc.p.ProductModelID,
                m => m.ProductModelID,
                (pc, m) => new { pc.p.Name, Model = m.Name, Category = pc.c.Name, pc.p.StandardCost, pc.p.ListPrice, pc.p.Color, pc.p.Size, pc.p.Weight })
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name}, ModeL: {p.Model}, Category: {p.Category}, {p.StandardCost}, {p.ListPrice}, {p.Size}, {p.Color}, {p.Weight}"));
            //Find the number of products of color Red
            var q2 = from p in products
                     where p.Color.ToLower() =="red"
                     select p;
            //Find the number of products of Model "Classic Vest"
            //int mid = (from m in models
            //           where m.Name == "Classic Vest"
            //           select m.ProductModelID).First();
            //var q3 = (from p in products
            //         where p.ProductModelID == (from m in models
            //                                    where m.Name == "Classic Vest"
            //                                    select m.ProductModelID).First()
            //         select p).Count();
            var pCount = products.Where(p => p.ProductModelID == models.First(x => x.Name == "Classic Vest").ProductModelID).Count();
            Console.WriteLine( pCount.ToString() );
            //Find the number of products of Category "Bikes"
            var pCount1 = products.Where(p => p.ProductCategoryID == categories.First(x => x.Name.ToLower() =="bikes").ProductCategoryID).Count();
            Console.WriteLine(pCount1);
            Console.ReadLine();
        }
    }
}
